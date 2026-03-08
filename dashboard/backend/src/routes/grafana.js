/**
 * Grafana Metrics Endpoint
 * Formato compatível com Grafana SimpleJSON datasource
 */

const express = require('express');
const router = express.Router();
const { db } = require('../index');

// Grafana datasource query endpoint
router.post('/search', async (req, res) => {
  try {
    const { target } = req.body;
    
    // Query metrics from Firebase
    const metricsRef = db.collection('metrics');
    const snapshot = await metricsRef.orderBy('timestamp', 'desc').limit(1).get();
    
    const data = snapshot.docs.map(doc => ({
      target: target || 'metrics',
      datapoints: []
    }));
    
    res.json(data);
  } catch (error) {
    res.status(500).json({ error: error.message });
  }
});

// Grafana metrics endpoint (time series)
router.get('/metrics', async (req, res) => {
  try {
    const now = Date.now();
    const from = parseInt(req.query.from) || now - 24 * 60 * 60 * 1000; // 24h
    const to = parseInt(req.query.to) || now;
    
    // Get overview metrics
    const overviewRef = db.collection('metrics').doc('overview');
    const overviewDoc = await overviewRef.get();
    const overview = overviewDoc.exists ? overviewDoc.data() : {};
    
    // Format for Grafana
    const metrics = [
      {
        target: 'downloads',
        datapoints: [[overview.downloadsToday || 0, now]]
      },
      {
        target: 'revenue',
        datapoints: [[overview.revenueToday || 0, now]]
      },
      {
        target: 'dau',
        datapoints: [[overview.dau || 0, now]]
      },
      {
        target: 'arpdau',
        datapoints: [[overview.arpdau || 0, now]]
      }
    ];
    
    res.json(metrics);
  } catch (error) {
    res.status(500).json({ error: error.message });
  }
});

// Health check for Grafana
router.get('/health', (req, res) => {
  res.json({
    status: 'ok',
    timestamp: new Date().toISOString(),
    service: 'gamesdev-factory-api'
  });
});

module.exports = router;
