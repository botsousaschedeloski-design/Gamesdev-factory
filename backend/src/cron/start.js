// GamesDev Factory - Start All Cron Jobs

const log = require('../utils/logger');

log.info('🚀 Starting GamesDev Factory Cron Jobs...');

// Import cron jobs
const updateMetrics = require('./updateMetrics');
const dailyBackup = require('./dailyBackup');
const weeklyCleanup = require('./weeklyCleanup');

// Log startup
log.info('✅ All cron jobs started successfully!');
log.info('📊 Schedule:');
log.info('   - Metrics Update: 09:00, 15:00, 21:00 (3x daily)');
log.info('   - Daily Backup: 00:00 (daily)');
log.info('   - Weekly Cleanup: Sunday 03:00 (weekly)');

// Keep process running
process.on('SIGTERM', () => {
  log.info('👋 Shutting down cron jobs...');
  process.exit(0);
});

process.on('SIGINT', () => {
  log.info('👋 Interrupt received, shutting down...');
  process.exit(0);
});

// Log heartbeat every hour
setInterval(() => {
  log.info('💓 Cron jobs heartbeat - all jobs running');
}, 60 * 60 * 1000);
