// GamesDev Factory - Dashboard API

import express from 'express';
import { gamesConfig } from '../config/games-config.js';

const router = express.Router();

// Mock data (substituir com banco de dados real)
const mockMetrics = {
  overview: {
    totalDownloads: 125450,
    totalAccesses: 45230,
    totalRevenue: 1234,
    activeGames: 15
  },
  games: gamesConfig.games.map(game => ({
    ...game,
    downloads: Math.floor(Math.random() * 30000),
    accesses: Math.floor(Math.random() * 15000),
    revenue: Math.floor(Math.random() * 500)
  })),
  dailyAccess: [
    { date: '2026-03-04', accesses: 45230 },
    { date: '2026-03-05', accesses: 38450 },
    { date: '2026-03-06', accesses: 42100 },
    { date: '2026-03-07', accesses: 48900 },
    { date: '2026-03-08', accesses: 45230 },
    { date: '2026-03-09', accesses: 32450 },
    { date: '2026-03-10', accesses: 28900 }
  ],
  revenueByRegion: {
    india: 456,
    indonesia: 312,
    pakistan: 234,
    bangladesh: 150,
    nigeria: 100
  }
};

/**
 * GET /api/dashboard/overview
 * Get overview metrics
 */
router.get('/overview', (req, res) => {
  res.json({
    success: true,
    data: mockMetrics.overview
  });
});

/**
 * GET /api/dashboard/games
 * Get all games with metrics
 */
router.get('/games', (req, res) => {
  res.json({
    success: true,
    data: mockMetrics.games
  });
});

/**
 * GET /api/dashboard/games/:id/metrics
 * Get metrics for specific game
 */
router.get('/games/:id/metrics', (req, res) => {
  const { id } = req.params;
  const game = mockMetrics.games.find(g => g.id === id);
  
  if (!game) {
    return res.json({
      success: false,
      error: 'Game not found'
    });
  }
  
  res.json({
    success: true,
    data: game
  });
});

/**
 * GET /api/dashboard/daily-access
 * Get daily access (last 7 days)
 */
router.get('/daily-access', (req, res) => {
  res.json({
    success: true,
    data: mockMetrics.dailyAccess
  });
});

/**
 * GET /api/dashboard/revenue-by-region
 * Get revenue by region
 */
router.get('/revenue-by-region', (req, res) => {
  res.json({
    success: true,
    data: mockMetrics.revenueByRegion
  });
});

/**
 * POST /api/track/download
 * Track download
 */
router.post('/track/download', (req, res) => {
  const { gameId, packageName } = req.body;
  
  // TODO: Save to database
  
  res.json({
    success: true,
    message: 'Download tracked'
  });
});

/**
 * POST /api/track/access
 * Track daily access (3x per day)
 */
router.post('/track/access', (req, res) => {
  const { gameId, period } = req.body;
  // period: 'morning' | 'afternoon' | 'evening'
  
  // TODO: Save to database
  
  res.json({
    success: true,
    message: 'Access tracked'
  });
});

export default router;
