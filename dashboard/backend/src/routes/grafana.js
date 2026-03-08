/**
 * Grafana SimpleJSON API
 * Formato compatível com Grafana datasource plugin
 */

const express = require('express');
const router = express.Router();
const { db } = require('../index');

/**
 * POST /search
 * Grafana query endpoint
 */
router.post('/search', async (req, res) => {
  try {
    const { target, refId } = req.body;
    
    // Get latest metrics from Firebase
    const overviewRef = db.collection('metrics').doc('overview');
    const overviewDoc = await overviewRef.get();
    const overview = overviewDoc.exists ? overviewDoc.data() : {};
    
    const now = Date.now();
    
    // Build response based on target
    let datapoints = [];
    
    switch(target) {
      case 'downloads':
        datapoints = [[overview.downloadsToday || 0, now]];
        break;
      case 'revenue':
        datapoints = [[overview.revenueToday || 0, now]];
        break;
      case 'dau':
        datapoints = [[overview.dau || 0, now]];
        break;
      case 'arpdau':
        datapoints = [[overview.arpdau || 0, now]];
        break;
      case 'markets':
        // Return market data
        const markets = overview.markets || {};
        datapoints = Object.entries(markets).map(([market, data]) => [data.revenue || 0, now]);
        break;
      default:
        datapoints = [[0, now]];
    }
    
    res.json([{
      target: target || 'metrics',
      refId: refId || 'A',
      datapoints: datapoints
    }]);
    
  } catch (error) {
    console.error('Grafana search error:', error);
    res.status(500).json({ error: error.message, datapoints: [] });
  }
});

/**
 * GET /metrics
 * Time series metrics for Grafana
 */
router.get('/metrics', async (req, res) => {
  try {
    const now = Date.now();
    
    // Get overview metrics
    const overviewRef = db.collection('metrics').doc('overview');
    const overviewDoc = await overviewRef.get();
    const overview = overviewDoc.exists ? overviewDoc.data() : {};
    
    // Format for Grafana time series
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
    console.error('Grafana metrics error:', error);
    res.status(500).json({ error: error.message });
  }
});

/**
 * GET /health
 * Health check for Grafana datasource
 */
router.get('/health', (req, res) => {
  res.json({
    status: 'ok',
    timestamp: new Date().toISOString(),
    service: 'gamesdev-factory-grafana-api',
    version: '1.0.0'
  });
});

/**
 * GET /
 * API info
 */
router.get('/', (req, res) => {
  res.json({
    name: 'GamesDev Factory Grafana API',
    version: '1.0.0',
    endpoints: {
      health: '/health',
      metrics: '/metrics',
      search: '/search (POST)'
    },
    documentation: 'https://github.com/botsousaschedeloski-design/Gamesdev-factory/blob/main/dashboard/GRAFANA_SETUP.md'
  });
});

module.exports = router;
