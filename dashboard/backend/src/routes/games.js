/**
 * Games Routes
 * GET /api/games - List all games
 * GET /api/games/:id - Game details
 * GET /api/games/:id/metrics - Game metrics
 * POST /api/games/:id/update - Update game info
 */

const express = require('express');
const router = express.Router();
const { db } = require('../index');

// GET /api/games
router.get('/', async (req, res) => {
  try {
    const gamesRef = db.collection('games');
    const snapshot = await gamesRef.orderBy('name').get();
    
    const games = snapshot.docs.map(doc => ({
      id: doc.id,
      ...doc.data()
    }));
    
    res.json(games);
  } catch (error) {
    res.status(500).json({ error: error.message });
  }
});

// GET /api/games/:id
router.get('/:id', async (req, res) => {
  try {
    const { id } = req.params;
    const gameRef = db.collection('games').doc(id);
    const doc = await gameRef.get();
    
    if (!doc.exists) {
      return res.status(404).json({ error: 'Game not found' });
    }
    
    res.json({
      id: doc.id,
      ...doc.data()
    });
  } catch (error) {
    res.status(500).json({ error: error.message });
  }
});

// GET /api/games/:id/metrics
router.get('/:id/metrics', async (req, res) => {
  try {
    const { id } = req.params;
    const metricsRef = db.collection('metrics').doc(`game-${id}`);
    const doc = await metricsRef.get();
    
    if (!doc.exists) {
      return res.json({
        gameId: id,
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

// POST /api/games/:id/update
router.post('/:id/update', async (req, res) => {
  try {
    const { id } = req.params;
    const { status, version, notes } = req.body;
    
    const gameRef = db.collection('games').doc(id);
    await gameRef.update({
      ...(status && { status }),
      ...(version && { version }),
      ...(notes && { notes }),
      updatedAt: new Date().toISOString()
    });
    
    res.json({ success: true, message: 'Game updated' });
  } catch (error) {
    res.status(500).json({ error: error.message });
  }
});

module.exports = router;
