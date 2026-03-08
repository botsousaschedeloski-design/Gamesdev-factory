/**
 * GamesDev Factory Dashboard - Backend API
 * Node.js + Express + Firebase
 * 
 * Production-ready server for monitoring all games
 */

require('dotenv').config();
const express = require('express');
const cors = require('cors');
const admin = require('firebase-admin');
const cron = require('node-cron');
const logger = require('./utils/logger');

// Routes
const metricsRoutes = require('./routes/metrics');
const decisionsRoutes = require('./routes/decisions');
const alertsRoutes = require('./routes/alerts');
const gamesRoutes = require('./routes/games');

// Cron jobs
const { fetchMetrics } = require('./cron/fetch-metrics');
const { runAutoDecisions } = require('./cron/auto-decisions');

// Initialize Firebase Admin
const serviceAccount = {
  project_id: process.env.FIREBASE_PROJECT_ID,
  client_email: process.env.FIREBASE_CLIENT_EMAIL,
  private_key: process.env.FIREBASE_PRIVATE_KEY.replace(/\\n/g, '\n')
};

admin.initializeApp({
  credential: admin.credential.cert(serviceAccount)
});

const db = admin.firestore();
const app = express();
const PORT = process.env.PORT || 3001;

// Middleware
app.use(cors());
app.use(express.json());
app.use(express.urlencoded({ extended: true }));

// Request logging
app.use((req, res, next) => {
  logger.info(`${req.method} ${req.path}`, {
    ip: req.ip,
    userAgent: req.get('user-agent')
  });
  next();
});

// Routes
app.use('/api/metrics', metricsRoutes);
app.use('/api/decisions', decisionsRoutes);
app.use('/api/alerts', alertsRoutes);
app.use('/api/games', gamesRoutes);

// Root route - Dashboard status
app.get('/', (req, res) => {
  res.json({
    name: 'GamesDev Factory Dashboard',
    version: '1.0.0',
    status: 'running',
    timestamp: new Date().toISOString(),
    uptime: process.uptime(),
    endpoints: {
      health: '/health',
      metrics: '/api/metrics/overview',
      games: '/api/games',
      decisions: '/api/decisions',
      alerts: '/api/alerts/active'
    }
  });
});

// Health check
app.get('/health', (req, res) => {
  res.json({
    status: 'ok',
    timestamp: new Date().toISOString(),
    uptime: process.uptime()
  });
});

// Error handling
app.use((err, req, res, next) => {
  logger.error('Error:', err);
  res.status(500).json({
    error: 'Internal server error',
    message: process.env.NODE_ENV === 'development' ? err.message : undefined
  });
});

// 404 handler
app.use((req, res) => {
  res.status(404).json({ error: 'Not found' });
});

// Start server
app.listen(PORT, () => {
  logger.info(`🚀 Server running on port ${PORT}`);
  logger.info(`📊 Environment: ${process.env.NODE_ENV}`);
  
  // Start cron jobs
  startCronJobs();
});

// Cron Jobs
function startCronJobs() {
  // Fetch metrics every 15 minutes
  cron.schedule('*/15 * * * *', async () => {
    logger.info('📊 Fetching metrics...');
    await fetchMetrics();
  });
  
  // Run auto-decisions every hour
  cron.schedule('0 * * * *', async () => {
    logger.info('🤖 Running auto-decisions...');
    await runAutoDecisions();
  });
  
  // Daily report at 9 AM
  cron.schedule('0 9 * * *', async () => {
    logger.info('📧 Sending daily report...');
    // TODO: Implement daily report
  });
  
  logger.info('⏰ Cron jobs started');
}

// Graceful shutdown
process.on('SIGTERM', () => {
  logger.info('SIGTERM received, shutting down gracefully...');
  process.exit(0);
});

module.exports = { app, db, admin };
