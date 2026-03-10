// GamesDev Factory - Cron Job: Weekly Cleanup

const cron = require('node-cron');
const { cleanupOldMetrics } = require('../services/metricsService');
const log = require('../utils/logger');

/**
 * Clean up old metrics data
 * Runs every Sunday at 03:00
 */
async function cleanupOldData() {
  try {
    log.info('🧹 Starting weekly cleanup...');
    
    // Delete metrics older than 30 days
    const thirtyDaysAgo = new Date();
    thirtyDaysAgo.setDate(thirtyDaysAgo.getDate() - 30);
    
    const result = await cleanupOldMetrics(thirtyDaysAgo);
    
    log.info(`🧹 Cleanup completed: ${result.deletedCount} old records deleted`);
    
    return {
      success: true,
      deletedCount: result.deletedCount,
      olderThan: thirtyDaysAgo.toISOString(),
      timestamp: new Date().toISOString()
    };
    
  } catch (error) {
    log.error(`❌ Weekly cleanup failed: ${error.message}`);
    return {
      success: false,
      error: error.message,
      timestamp: new Date().toISOString()
    };
  }
}

// Schedule weekly cleanup on Sunday at 03:00
cron.schedule('0 3 * * 0', async () => {
  log.info('📅 Scheduling weekly cleanup...');
  await cleanupOldData();
});

log.info('✅ Weekly cleanup cron job scheduled (Sunday 03:00)');

module.exports = { cleanupOldData };
