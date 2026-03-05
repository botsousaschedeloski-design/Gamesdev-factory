/**
 * Alerts Routes
 * GET /api/alerts - List all alerts
 * GET /api/alerts/active - Active alerts
 * POST /api/alerts/:id/dismiss - Dismiss alert
 * GET /api/alerts/config - Alert configuration
 * PUT /api/alerts/config - Update alert config
 */

const express = require('express');
const router = express.Router();
const { db } = require('../index');

// GET /api/alerts
router.get('/', async (req, res) => {
  try {
    const alertsRef = db.collection('alerts');
    const snapshot = await alertsRef.orderBy('createdAt', 'desc').limit(100).get();
    
    const alerts = snapshot.docs.map(doc => ({
      id: doc.id,
      ...doc.data()
    }));
    
    res.json(alerts);
  } catch (error) {
    res.status(500).json({ error: error.message });
  }
});

// GET /api/alerts/active
router.get('/active', async (req, res) => {
  try {
    const alertsRef = db.collection('alerts');
    const snapshot = await alertsRef
      .where('status', '==', 'active')
      .orderBy('severity')
      .orderBy('createdAt', 'desc')
      .get();
    
    const alerts = snapshot.docs.map(doc => ({
      id: doc.id,
      ...doc.data()
    }));
    
    res.json(alerts);
  } catch (error) {
    res.status(500).json({ error: error.message });
  }
});

// POST /api/alerts/:id/dismiss
router.post('/:id/dismiss', async (req, res) => {
  try {
    const { id } = req.params;
    const alertRef = db.collection('alerts').doc(id);
    
    await alertRef.update({
      status: 'dismissed',
      dismissedAt: new Date().toISOString()
    });
    
    res.json({ success: true, message: 'Alert dismissed' });
  } catch (error) {
    res.status(500).json({ error: error.message });
  }
});

// GET /api/alerts/config
router.get('/config', async (req, res) => {
  try {
    const configRef = db.collection('config').doc('alerts');
    const doc = await configRef.get();
    
    res.json(doc.data() || {
      email: { enabled: true, recipients: ['afonso@email.com'] },
      sms: { enabled: true, recipients: ['+XX XXX XXX XXXX'] },
      telegram: { enabled: true, recipients: ['@afonso'] },
      dashboard: { enabled: true, badge: true }
    });
  } catch (error) {
    res.status(500).json({ error: error.message });
  }
});

// PUT /api/alerts/config
router.put('/config', async (req, res) => {
  try {
    const configRef = db.collection('config').doc('alerts');
    await configRef.set(req.body, { merge: true });
    
    res.json({ success: true, message: 'Config updated' });
  } catch (error) {
    res.status(500).json({ error: error.message });
  }
});

module.exports = router;
