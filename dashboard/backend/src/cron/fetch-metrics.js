/**
 * Cron: Fetch Metrics
 * Runs every 15 minutes to fetch metrics from all APIs
 */

const { db, admin } = require('../index');
const logger = require('../utils/logger');

// Mock data for development (replace with actual API calls)
const mockMetrics = {
  overview: {
    downloadsToday: 12450,
    downloadsTrend: 15,
    revenueToday: 1234,
    revenueTrend: 22,
    dau: 8450,
    dauTrend: 8,
    arpdau: 0.06,
    arpdauTrend: 5,
    lastUpdated: new Date().toISOString()
  },
  markets: {
    indonesia: {
      downloads: { today: 3450, d7: 24150, d30: 80000, total: 80000 },
      revenue: { today: 456, d7: 3192, d30: 11000, total: 11000 },
      dau: 2340,
      arpdau: 0.08,
      games: ['domino-qq', 'slot-wayang', 'capsa-online']
    },
    pakistan: {
      downloads: { today: 2890, d7: 20230, d30: 60000, total: 60000 },
      revenue: { today: 312, d7: 2184, d30: 8000, total: 8000 },
      dau: 1890,
      arpdau: 0.05,
      games: ['cricket-sim', 'teenpatti-cricket', 'rummy-pakistan']
    },
    bangladesh: {
      downloads: { today: 2340, d7: 16380, d30: 50000, total: 50000 },
      revenue: { today: 234, d7: 1638, d30: 6500, total: 6500 },
      dau: 1450,
      arpdau: 0.04,
      games: ['teenpatti-bd', 'cricket-quiz', 'ludo-bd']
    },
    nigeria: {
      downloads: { today: 3770, d7: 26390, d30: 40000, total: 40000 },
      revenue: { today: 232, d7: 1624, d30: 5500, total: 5500 },
      dau: 2770,
      arpdau: 0.05,
      games: ['football-quiz', 'afro-slots', 'ayo-board']
    }
  }
};

async function fetchMetrics() {
  try {
    logger.info('Fetching metrics from APIs...');
    
    // Save overview metrics
    await db.collection('metrics').doc('overview').set(mockMetrics.overview, { merge: true });
    
    // Save market metrics
    for (const [marketId, metrics] of Object.entries(mockMetrics.markets)) {
      await db.collection('metrics').doc(`market-${marketId}`).set({
        marketId,
        ...metrics,
        lastUpdated: new Date().toISOString()
      }, { merge: true });
    }
    
    // Save games (mock)
    const games = [
      { id: 'domino-qq', name: 'Domino QQ Online', market: 'indonesia', status: 'active' },
      { id: 'slot-wayang', name: 'Slot Wayang', market: 'indonesia', status: 'active' },
      { id: 'capsa-online', name: 'Capsa Online', market: 'indonesia', status: 'active' },
      { id: 'cricket-sim', name: 'Cricket Betting Sim', market: 'pakistan', status: 'development' },
      { id: 'teenpatti-cricket', name: 'Teen Patti Cricket', market: 'pakistan', status: 'development' },
      { id: 'rummy-pakistan', name: 'Rummy Pakistan', market: 'pakistan', status: 'development' },
      { id: 'teenpatti-bd', name: 'Teen Patti Bangladesh', market: 'bangladesh', status: 'planning' },
      { id: 'cricket-quiz', name: 'Cricket Quiz', market: 'bangladesh', status: 'planning' },
      { id: 'ludo-bd', name: 'Ludo Bangladesh', market: 'bangladesh', status: 'planning' },
      { id: 'football-quiz', name: 'Football Quiz', market: 'nigeria', status: 'planning' },
      { id: 'afro-slots', name: 'Afro Slots', market: 'nigeria', status: 'planning' },
      { id: 'ayo-board', name: 'Ayo Board', market: 'nigeria', status: 'planning' }
    ];
    
    for (const game of games) {
      await db.collection('games').doc(game.id).set({
        ...game,
        updatedAt: new Date().toISOString()
      }, { merge: true });
    }
    
    logger.info('✅ Metrics fetched successfully');
  } catch (error) {
    logger.error('Error fetching metrics:', error);
  }
}

module.exports = { fetchMetrics };
