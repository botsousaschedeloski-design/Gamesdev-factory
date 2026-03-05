/**
 * Metrics Routes
 * GET /api/metrics/overview - Overview metrics (24h)
 * GET /api/metrics/market/:marketId - Market-specific metrics
 * GET /api/metrics/game/:gameId - Game-specific metrics
 */

const express = require('express');
const router = express.Router();
const { db } = require('../index');

// GET /api/metrics/overview
router.get('/overview', async (req, res) => {
  try {
    const overviewRef = db.collection('metrics').doc('overview');
    const doc = await overviewRef.get();
    
    if (!doc.exists) {
      return res.json({
        downloadsToday: 0,
        downloadsTrend: 0,
        revenueToday: 0,
        revenueTrend: 0,
        dau: 0,
        dauTrend: 0,
        arpdau: 0,
        arpdauTrend: 0,
        lastUpdated: new Date().toISOString()
      });
    }
    
    res.json(doc.data());
  } catch (error) {
    res.status(500).json({ error: error.message });
  }
});

// GET /api/metrics/market/:marketId
router.get('/market/:marketId', async (req, res) => {
  try {
    const { marketId } = req.params;
    const marketRef = db.collection('metrics').doc(`market-${marketId}`);
    const doc = await marketRef.get();
    
    if (!doc.exists) {
      return res.json({
        marketId,
        downloads: { today: 0, d7: 0, d30: 0, total: 0 },
        revenue: { today: 0, d7: 0, d30: 0, total: 0 },
        dau: 0,
        arpdau: 0,
        games: [],
        lastUpdated: new Date().toISOString()
      });
    }
    
    res.json(doc.data());
  } catch (error) {
    res.status(500).json({ error: error.message });
  }
});

// GET /api/metrics/game/:gameId
router.get('/game/:gameId', async (req, res) => {
  try {
    const { gameId } = req.params;
    const gameRef = db.collection('metrics').doc(`game-${gameId}`);
    const doc = await gameRef.get();
    
    if (!doc.exists) {
      return res.json({
        gameId,
        downloads: { today: 0, d7: 0, d30: 0, total: 0 },
        revenue: { today: 0, d7: 0, d30: 0, total: 0 },
        retention: { d1: 0, d7: 0, d30: 0 },
        engagement: { dau: 0, mau: 0, sessionsPerDau: 0, sessionLength: 0 },
        lastUpdated: new Date().toISOString()
      });
    }
    
    res.json(doc.data());
  } catch (error) {
    res.status(500).json({ error: error.message });
  }
});

// GET /api/metrics/revenue
router.get('/revenue', async (req, res) => {
  try {
    const revenueRef = db.collection('metrics').doc('revenue');
    const doc = await revenueRef.get();
    
    res.json(doc.data() || {
      total: { today: 0, d7: 0, d30: 0 },
      byMarket: {},
      byGame: {},
      bySource: { admob: 0, iap: 0 },
      lastUpdated: new Date().toISOString()
    });
  } catch (error) {
    res.status(500).json({ error: error.message });
  }
});

// GET /api/metrics/downloads
router.get('/downloads', async (req, res) => {
  try {
    const downloadsRef = db.collection('metrics').doc('downloads');
    const doc = await downloadsRef.get();
    
    res.json(doc.data() || {
      total: { today: 0, d7: 0, d30: 0 },
      byMarket: {},
      byGame: {},
      lastUpdated: new Date().toISOString()
    });
  } catch (error) {
    res.status(500).json({ error: error.message });
  }
});

// GET /api/metrics/retention
router.get('/retention', async (req, res) => {
  try {
    const retentionRef = db.collection('metrics').doc('retention');
    const doc = await retentionRef.get();
    
    res.json(doc.data() || {
      average: { d1: 0, d7: 0, d30: 0 },
      byGame: {},
      lastUpdated: new Date().toISOString()
    });
  } catch (error) {
    res.status(500).json({ error: error.message });
  }
});

module.exports = router;
