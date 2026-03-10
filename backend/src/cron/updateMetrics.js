// GamesDev Factory - Cron Job: Update Metrics (3x per day)

const cron = require('node-cron');
const { updateGameMetrics, getAllGames } = require('../services/metricsService');
const { getAdMobMetrics } = require('../services/admobService');
const log = require('../utils/logger');

/**
 * Update all games metrics
 * Runs 3 times per day: 09:00, 15:00, 21:00
 */
async function updateAllMetrics(period) {
  try {
    log.info(`📊 Starting ${period} metrics update...`);
    
    const games = await getAllGames();
    log.info(`📊 Found ${games.length} games to update`);
    
    const results = [];
    
    for (const game of games) {
      try {
        // Get AdMob metrics
        const admobMetrics = await getAdMobMetrics(game.appId);
        
        // Update game metrics
        await updateGameMetrics(game.id, {
          date: new Date().toISOString().split('T')[0],
          period: period,
          accesses: admobMetrics.activeUsers || 0,
          revenue: admobMetrics.estimatedEarnings || 0,
          impressions: admobMetrics.impressions || 0,
          clicks: admobMetrics.clicks || 0,
          eCPM: admobMetrics.eCPM || 0
        });
        
        results.push({
          gameId: game.id,
          gameName: game.name,
          success: true,
          accesses: admobMetrics.activeUsers || 0,
          revenue: admobMetrics.estimatedEarnings || 0
        });
        
        log.info(`✅ Updated ${game.name}: ${admobMetrics.activeUsers || 0} accesses, $${admobMetrics.estimatedEarnings || 0}`);
        
      } catch (error) {
        log.error(`❌ Error updating ${game.name}: ${error.message}`);
        results.push({
          gameId: game.id,
          gameName: game.name,
          success: false,
          error: error.message
        });
      }
    }
    
    log.info(`📊 Metrics update completed: ${results.filter(r => r.success).length}/${results.length} successful`);
    
    return {
      success: true,
      period: period,
      results: results,
      timestamp: new Date().toISOString()
    };
    
  } catch (error) {
    log.error(`❌ Metrics update failed: ${error.message}`);
    return {
      success: false,
      error: error.message,
      timestamp: new Date().toISOString()
    };
  }
}

// Schedule cron jobs
// Morning update (09:00)
cron.schedule('0 9 * * *', async () => {
  log.info('🌅 Scheduling morning update...');
  await updateAllMetrics('morning');
});

// Afternoon update (15:00)
cron.schedule('0 15 * * *', async () => {
  log.info('☀️ Scheduling afternoon update...');
  await updateAllMetrics('afternoon');
});

// Evening update (21:00)
cron.schedule('0 21 * * *', async () => {
  log.info('🌙 Scheduling evening update...');
  await updateAllMetrics('evening');
});

log.info('✅ Metrics cron jobs scheduled (09:00, 15:00, 21:00)');

module.exports = { updateAllMetrics };
