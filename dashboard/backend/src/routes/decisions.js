/**
 * Decisions Routes
 * GET /api/decisions - List all decisions
 * GET /api/decisions/auto - Auto-decisions (24h)
 * GET /api/decisions/pending - Pending approval
 * POST /api/decisions/:id/approve - Approve decision
 * POST /api/decisions/:id/reject - Reject decision
 */

const express = require('express');
const router = express.Router();
const { db } = require('../index');

// GET /api/decisions
router.get('/', async (req, res) => {
  try {
    const decisionsRef = db.collection('decisions');
    const snapshot = await decisionsRef.orderBy('createdAt', 'desc').limit(100).get();
    
    const decisions = snapshot.docs.map(doc => ({
      id: doc.id,
      ...doc.data()
    }));
    
    res.json(decisions);
  } catch (error) {
    res.status(500).json({ error: error.message });
  }
});

// GET /api/decisions/auto
router.get('/auto', async (req, res) => {
  try {
    const decisionsRef = db.collection('decisions');
    const snapshot = await decisionsRef
      .where('type', '==', 'auto')
      .where('createdAt', '>=', new Date(Date.now() - 24 * 60 * 60 * 1000))
      .orderBy('createdAt', 'desc')
      .get();
    
    const decisions = snapshot.docs.map(doc => ({
      id: doc.id,
      ...doc.data()
    }));
    
    res.json(decisions);
  } catch (error) {
    res.status(500).json({ error: error.message });
  }
});

// GET /api/decisions/pending
router.get('/pending', async (req, res) => {
  try {
    const decisionsRef = db.collection('decisions');
    const snapshot = await decisionsRef
      .where('status', '==', 'pending')
      .where('requiresApproval', '==', true)
      .orderBy('createdAt', 'desc')
      .get();
    
    const decisions = snapshot.docs.map(doc => ({
      id: doc.id,
      ...doc.data()
    }));
    
    res.json(decisions);
  } catch (error) {
    res.status(500).json({ error: error.message });
  }
});

// POST /api/decisions/:id/approve
router.post('/:id/approve', async (req, res) => {
  try {
    const { id } = req.params;
    const decisionRef = db.collection('decisions').doc(id);
    
    await decisionRef.update({
      status: 'approved',
      approvedAt: new Date().toISOString(),
      approvedBy: 'afonso'
    });
    
    // Execute the decision
    const decision = (await decisionRef.get()).data();
    await executeDecision(decision);
    
    res.json({ success: true, message: 'Decision approved' });
  } catch (error) {
    res.status(500).json({ error: error.message });
  }
});

// POST /api/decisions/:id/reject
router.post('/:id/reject', async (req, res) => {
  try {
    const { id } = req.params;
    const decisionRef = db.collection('decisions').doc(id);
    
    await decisionRef.update({
      status: 'rejected',
      rejectedAt: new Date().toISOString(),
      rejectedBy: 'afonso'
    });
    
    res.json({ success: true, message: 'Decision rejected' });
  } catch (error) {
    res.status(500).json({ error: error.message });
  }
});

// Execute decision
async function executeDecision(decision) {
  // TODO: Implement actual execution logic
  // For now, just log it
  console.log('Executing decision:', decision);
}

module.exports = router;
