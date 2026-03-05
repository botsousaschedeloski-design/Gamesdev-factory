/**
 * Cron: Auto-Decisions
 * Runs every hour to evaluate and execute auto-decisions
 */

const { db } = require('../index');
const logger = require('../utils/logger');

// Decision rules
const decisionRules = [
  {
    id: 'roas-high',
    condition: (metrics) => metrics.roas > 4.0,
    action: 'increase_budget',
    params: { percentage: 20 },
    requiresApproval: false,
    title: 'Aumentar budget Facebook +20%',
    description: 'ROAS atual acima da meta'
  },
  {
    id: 'roas-low',
    condition: (metrics) => metrics.roas < 2.0,
    action: 'decrease_budget',
    params: { percentage: 30 },
    requiresApproval: false,
    title: 'Reduzir budget Facebook -30%',
    description: 'ROAS atual abaixo da meta'
  },
  {
    id: 'cpi-high',
    condition: (metrics) => metrics.cpi > 2.0 * (metrics.targetCpi || 0.30),
    action: 'pause_campaign',
    params: {},
    requiresApproval: false,
    title: 'Pausar campanha (CPI alto)',
    description: 'CPI acima de 200% da meta'
  },
  {
    id: 'retention-low',
    condition: (metrics) => metrics.retentionD1 < 0.30,
    action: 'optimize_onboarding',
    params: {},
    requiresApproval: false,
    title: 'Otimizar onboarding',
    description: 'Retention D1 abaixo de 30%'
  },
  {
    id: 'revenue-high',
    condition: (metrics) => metrics.revenue > 1.5 * (metrics.targetRevenue || 1000),
    action: 'expand_market',
    params: {},
    requiresApproval: true,
    title: 'Expandir para mercado similar',
    description: 'Revenue acima de 150% da meta'
  }
];

async function runAutoDecisions() {
  try {
    logger.info('Running auto-decisions...');
    
    // Get all active games
    const gamesRef = db.collection('games');
    const snapshot = await gamesRef.where('status', '==', 'active').get();
    
    for (const gameDoc of snapshot.docs) {
      const game = { id: gameDoc.id, ...gameDoc.data() };
      
      // Get game metrics
      const metricsRef = db.collection('metrics').doc(`game-${game.id}`);
      const metricsDoc = await metricsRef.get();
      
      if (!metricsDoc.exists) continue;
      
      const metrics = metricsDoc.data();
      
      // Evaluate each rule
      for (const rule of decisionRules) {
        if (rule.condition(metrics)) {
          // Create decision
          const decision = {
            type: 'auto',
            category: getDecisionCategory(rule.action),
            gameId: game.id,
            marketId: game.market,
            title: rule.title,
            description: rule.description,
            condition: rule.id,
            action: rule.action,
            params: rule.params,
            requiresApproval: rule.requiresApproval,
            estimatedImpact: calculateImpact(rule, metrics),
            status: rule.requiresApproval ? 'pending' : 'executed',
            createdAt: new Date().toISOString()
          };
          
          // Save decision
          await db.collection('decisions').add(decision);
          
          // Execute if auto
          if (!rule.requiresApproval) {
            await executeDecision(decision);
          }
          
          logger.info(`Decision created: ${rule.id} for ${game.id}`);
        }
      }
    }
    
    logger.info('✅ Auto-decisions completed');
  } catch (error) {
    logger.error('Error running auto-decisions:', error);
  }
}

function getDecisionCategory(action) {
  const categories = {
    increase_budget: 'budget',
    decrease_budget: 'budget',
    pause_campaign: 'campaign',
    optimize_onboarding: 'optimization',
    expand_market: 'expansion'
  };
  return categories[action] || 'other';
}

function calculateImpact(rule, metrics) {
  // Simplified impact calculation
  const impacts = {
    increase_budget: { revenue: '+$50/dia', budget: '+$30/dia', roi: '3.5x' },
    decrease_budget: { revenue: '-$20/dia', budget: '-$45/dia', roi: '2.5x' },
    pause_campaign: { revenue: '-$30/dia', budget: '-$60/dia', roi: '0x' },
    optimize_onboarding: { retention: '+7%', revenue: '+$40/dia' },
    expand_market: { revenue: '+$5000 D30', investment: '$500', roi: '3-4x' }
  };
  
  return impacts[rule.action] || {};
}

async function executeDecision(decision) {
  // TODO: Implement actual execution logic
  // For now, just log it
  logger.info('Executing decision:', decision);
  
  // Update decision status
  await db.collection('decisions').add({
    ...decision,
    executedAt: new Date().toISOString(),
    status: 'executed'
  });
}

module.exports = { runAutoDecisions };
