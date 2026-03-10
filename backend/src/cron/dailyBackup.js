// GamesDev Factory - Cron Job: Daily Backup

const cron = require('node-cron');
const fs = require('fs').promises;
const path = require('path');
const { getAllMetrics } = require('../services/metricsService');
const log = require('../utils/logger');

const BACKUP_DIR = path.join(__dirname, '../../backups');

/**
 * Create daily backup of all metrics
 * Runs at 00:00 every day
 */
async function createDailyBackup() {
  try {
    log.info('💾 Starting daily backup...');
    
    // Ensure backup directory exists
    await fs.mkdir(BACKUP_DIR, { recursive: true });
    
    // Get current date
    const date = new Date().toISOString().split('T')[0];
    const backupPath = path.join(BACKUP_DIR, `${date}-metrics.json`);
    
    // Get all metrics
    const metrics = await getAllMetrics();
    
    // Create backup object
    const backup = {
      date: date,
      timestamp: new Date().toISOString(),
      totalGames: metrics.games?.length || 0,
      metrics: metrics
    };
    
    // Save to file
    await fs.writeFile(backupPath, JSON.stringify(backup, null, 2), 'utf-8');
    
    log.info(`💾 Backup created: ${backupPath}`);
    log.info(`💾 Total games: ${backup.totalGames}`);
    
    return {
      success: true,
      backupPath: backupPath,
      totalGames: backup.totalGames,
      timestamp: new Date().toISOString()
    };
    
  } catch (error) {
    log.error(`❌ Daily backup failed: ${error.message}`);
    return {
      success: false,
      error: error.message,
      timestamp: new Date().toISOString()
    };
  }
}

// Schedule daily backup at 00:00
cron.schedule('0 0 * * *', async () => {
  log.info('🕐 Scheduling daily backup...');
  await createDailyBackup();
});

log.info('✅ Daily backup cron job scheduled (00:00)');

module.exports = { createDailyBackup };
