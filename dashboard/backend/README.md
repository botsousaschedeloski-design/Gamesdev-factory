# Backend API - GamesDev Factory Dashboard

**Node.js + Express + Firebase**

---

## 🚀 Setup

```bash
cd dashboard/backend
npm install
cp .env.example .env
# Edit .env with your API keys
npm run dev
```

---

## 📁 Estrutura

```
backend/
├── src/
│   ├── index.js              # Entry point
│   ├── routes/
│   │   ├── metrics.js        # Metrics endpoints
│   │   ├── decisions.js      # Decision engine
│   │   ├── alerts.js         # Alerts system
│   │   └── games.js          # Games management
│   ├── services/
│   │   ├── google-play.js    # Google Play API
│   │   ├── admob.js          # AdMob API
│   │   ├── firebase.js       # Firebase Analytics
│   │   ├── facebook-ads.js   # Facebook Ads API
│   │   ├── google-ads.js     # Google Ads API
│   │   └── decision-engine.js # Auto-decisions
│   ├── cron/
│   │   ├── fetch-metrics.js  # Scheduled metrics fetch
│   │   └── auto-decisions.js # Scheduled decisions
│   ├── middleware/
│   │   ├── auth.js           # Authentication
│   │   └── rate-limit.js     # Rate limiting
│   └── utils/
│       ├── logger.js         # Winston logger
│       └── helpers.js        # Utility functions
├── .env
├── .env.example
└── package.json
```

---

## 🔑 Environment Variables

```bash
# .env.example

# Firebase
FIREBASE_PROJECT_ID=gamesdev-factory
FIREBASE_CLIENT_EMAIL=your-service-account@projects.iam.gserviceaccount.com
FIREBASE_PRIVATE_KEY=-----BEGIN PRIVATE KEY-----\n...\n-----END PRIVATE KEY-----\n

# Google Play
GOOGLE_PLAY_PACKAGE_NAME=com.afonso.fxtrade.gamesdev
GOOGLE_PLAY_CLIENT_EMAIL=your-api@developer.gserviceaccount.com
GOOGLE_PLAY_PRIVATE_KEY=-----BEGIN PRIVATE KEY-----\n...\n-----END PRIVATE KEY-----\n

# AdMob
ADMOB_ACCOUNT_ID=pub-xxxxxxxxxxxxxxxx

# Facebook Ads
FACEBOOK_ACCESS_TOKEN=EAAB...

# Google Ads
GOOGLE_ADS_DEVELOPER_TOKEN=xxxxxxxxxxxxxxxxxxxxx
GOOGLE_ADS_CLIENT_ID=xxxxxxxxxxxxx.apps.googleusercontent.com
GOOGLE_ADS_CLIENT_SECRET=xxxxxxxxxxxxxxxxxxxxx

# Server
PORT=3001
NODE_ENV=development

# Dashboard
DASHBOARD_URL=http://localhost:3000
ALERT_EMAIL=afonso@email.com
ALERT_PHONE=+XX XXX XXX XXXX
ALERT_TELEGRAM=@afonso
```

---

## 📡 API Endpoints

### Metrics

| Endpoint | Method | Description |
|----------|--------|-------------|
| `/api/metrics/overview` | GET | Overview metrics (24h) |
| `/api/metrics/market/:marketId` | GET | Market-specific metrics |
| `/api/metrics/game/:gameId` | GET | Game-specific metrics |
| `/api/metrics/revenue` | GET | Revenue breakdown |
| `/api/metrics/downloads` | GET | Downloads breakdown |
| `/api/metrics/retention` | GET | Retention metrics |

### Decisions

| Endpoint | Method | Description |
|----------|--------|-------------|
| `/api/decisions` | GET | List all decisions |
| `/api/decisions/auto` | GET | Auto-decisions (24h) |
| `/api/decisions/pending` | GET | Pending approval |
| `/api/decisions/:id/approve` | POST | Approve decision |
| `/api/decisions/:id/reject` | POST | Reject decision |

### Alerts

| Endpoint | Method | Description |
|----------|--------|-------------|
| `/api/alerts` | GET | List all alerts |
| `/api/alerts/active` | GET | Active alerts |
| `/api/alerts/:id/dismiss` | POST | Dismiss alert |
| `/api/alerts/config` | GET | Alert configuration |
| `/api/alerts/config` | PUT | Update alert config |

### Games

| Endpoint | Method | Description |
|----------|--------|-------------|
| `/api/games` | GET | List all games |
| `/api/games/:id` | GET | Game details |
| `/api/games/:id/metrics` | GET | Game metrics |
| `/api/games/:id/update` | POST | Update game info |

---

## 🔄 Cron Jobs

| Job | Schedule | Description |
|-----|----------|-------------|
| `fetch-metrics` | */15 * * * * | Fetch metrics from all APIs (every 15 min) |
| `analyze-data` | */30 * * * * | Analyze data for anomalies (every 30 min) |
| `auto-decisions` | 0 * * * * | Execute auto-decisions (every hour) |
| `daily-report` | 0 9 * * * | Send daily report (9 AM) |
| `weekly-report` | 0 9 * * 1 | Send weekly report (Monday 9 AM) |

---

## 📊 Data Models

### Game

```javascript
{
  id: "domino-qq-indonesia",
  name: "Domino QQ Online",
  market: "indonesia",
  genre: "domino",
  launchDate: "2026-03-10",
  version: "1.0.3",
  status: "active", // active, development, paused
  packageName: "com.afonso.fxtrade.dominoqq",
  metrics: {
    downloads: {
      today: 1234,
      d7: 8456,
      d30: 34567,
      total: 34567
    },
    revenue: {
      today: 189,
      d7: 1323,
      d30: 5670,
      total: 5670
    },
    retention: {
      d1: 0.45,
      d7: 0.25,
      d30: 0.10
    },
    engagement: {
      dau: 1045,
      mau: 8456,
      sessionsPerDau: 8.5,
      sessionLength: 22.5
    }
  }
}
```

### Market

```javascript
{
  id: "indonesia",
  name: "Indonésia",
  flag: "🇮🇩",
  currency: "IDR",
  timezone: "Asia/Jakarta",
  games: ["domino-qq", "slot-wayang", "capsa-online"],
  metrics: {
    downloads: { today: 3450, d7: 24150, d30: 80000 },
    revenue: { today: 456, d7: 3192, d30: 11000 },
    dau: 2340,
    arpdau: 0.08
  }
}
```

### Decision

```javascript
{
  id: "dec-001",
  type: "auto", // auto, manual
  category: "budget", // budget, campaign, optimization, expansion
  gameId: "domino-qq",
  marketId: "indonesia",
  title: "Aumentar budget Facebook +20%",
  description: "ROAS atual: 4.2x (meta: 3x)",
  condition: "roas > 4.0",
  action: "increase_budget_20_percent",
  estimatedImpact: {
    revenue: "+$50/dia",
    budget: "+$30/dia",
    roi: "3.5x"
  },
  status: "executed", // pending, executed, approved, rejected
  executedAt: "2026-03-15T10:30:00Z",
  result: {
    actualImpact: {
      revenue: "+$55/dia",
      roi: "3.8x"
    }
  }
}
```

### Alert

```javascript
{
  id: "alert-001",
  type: "warning", // critical, warning, info
  category: "revenue", // revenue, retention, cpi, bug
  gameId: "capsa-online",
  marketId: "indonesia",
  title: "Retention D1 abaixo da meta",
  description: "Retention D1: 38% (meta: 45%)",
  condition: "retention_d1 < 0.45",
  currentValue: 0.38,
  targetValue: 0.45,
  status: "active", // active, dismissed, resolved
  autoAction: "optimize_onboarding",
  createdAt: "2026-03-15T08:00:00Z",
  dismissedAt: null
}
```

---

## 🔌 API Integrations

### Google Play Console API

```javascript
// src/services/google-play.js
const { google } = require('googleapis');

async function getDownloads(packageName, startDate, endDate) {
  const auth = await getGooglePlayAuth();
  const androidpublisher = google.androidpublisher({ version: 'v3', auth });
  
  const response = await androidpublisher.reports.get({
    packageName,
    startDate,
    endDate,
    metrics: ['totalUserDownloads']
  });
  
  return response.data;
}

async function getRevenue(packageName, startDate, endDate) {
  // Similar implementation
}
```

### AdMob API

```javascript
// src/services/admob.js
async function getAdMobRevenue(accountId, startDate, endDate) {
  const auth = await getAdMobAuth();
  
  const response = await fetch(
    `https://admob.googleapis.com/v1/accounts/${accountId}/reports:generate`,
    {
      method: 'POST',
      headers: { Authorization: `Bearer ${auth.accessToken}` },
      body: JSON.stringify({
        startDate: { year, month, day },
        endDate: { year, month, day },
        metrics: ['ESTIMATED_EARNINGS', 'IMPRESSIONS', 'ECPM']
      })
    }
  );
  
  return response.json();
}
```

### Firebase Analytics API

```javascript
// src/services/firebase.js
const admin = require('firebase-admin');

async function getRetention(gameId, startDate, endDate) {
  const analytics = admin.analytics();
  
  const response = await analytics.runReport({
    dateRanges: [{ startDate, endDate }],
    dimensions: [{ name: 'date' }],
    metrics: [
      { name: 'retentionD1' },
      { name: 'retentionD7' },
      { name: 'retentionD30' }
    ],
    dimensionFilter: {
      propertyName: `games/${gameId}`
    }
  });
  
  return response;
}

async function getDAU(gameId) {
  // Similar implementation
}
```

---

## 🤖 Decision Engine

### Rules Engine

```javascript
// src/services/decision-engine.js

const decisionRules = [
  {
    id: 'roas-high',
    condition: (metrics) => metrics.roas > 4.0,
    action: 'increase_budget',
    params: { percentage: 20 },
    requiresApproval: false
  },
  {
    id: 'roas-low',
    condition: (metrics) => metrics.roas < 2.0,
    action: 'decrease_budget',
    params: { percentage: 30 },
    requiresApproval: false
  },
  {
    id: 'cpi-high',
    condition: (metrics) => metrics.cpi > 2.0 * metrics.targetCpi,
    action: 'pause_campaign',
    params: {},
    requiresApproval: false
  },
  {
    id: 'retention-low',
    condition: (metrics) => metrics.retentionD1 < 0.30,
    action: 'optimize_onboarding',
    params: {},
    requiresApproval: false
  },
  {
    id: 'revenue-high',
    condition: (metrics) => metrics.revenue > 1.5 * metrics.targetRevenue,
    action: 'expand_market',
    params: {},
    requiresApproval: true
  }
];

async function evaluateDecisions(gameId, marketId) {
  const metrics = await getMetrics(gameId, marketId);
  const decisions = [];
  
  for (const rule of decisionRules) {
    if (rule.condition(metrics)) {
      decisions.push({
        ruleId: rule.id,
        action: rule.action,
        params: rule.params,
        requiresApproval: rule.requiresApproval,
        estimatedImpact: calculateImpact(rule, metrics)
      });
    }
  }
  
  return decisions;
}
```

---

## 🔔 Alert System

### Alert Rules

```javascript
// src/services/alert-engine.js

const alertRules = [
  {
    id: 'revenue-critical',
    severity: 'critical',
    condition: (metrics) => metrics.revenue < 0.50 * metrics.targetRevenue,
    channels: ['email', 'sms', 'telegram'],
    autoAction: 'analyze'
  },
  {
    id: 'cpi-critical',
    severity: 'critical',
    condition: (metrics) => metrics.cpi > 2.0 * metrics.targetCpi,
    channels: ['email', 'sms'],
    autoAction: 'pause_campaign'
  },
  {
    id: 'retention-warning',
    severity: 'warning',
    condition: (metrics) => metrics.retentionD1 < 0.30,
    channels: ['email'],
    autoAction: 'optimize_onboarding'
  },
  {
    id: 'revenue-info',
    severity: 'info',
    condition: (metrics) => metrics.revenue > 1.50 * metrics.targetRevenue,
    channels: ['email'],
    autoAction: 'celebrate'
  }
];

async function checkAlerts(gameId, marketId) {
  const metrics = await getMetrics(gameId, marketId);
  const alerts = [];
  
  for (const rule of alertRules) {
    if (rule.condition(metrics)) {
      alerts.push({
        ruleId: rule.id,
        severity: rule.severity,
        gameId,
        marketId,
        channels: rule.channels,
        autoAction: rule.autoAction
      });
    }
  }
  
  return alerts;
}
```

---

## 📝 Logging

```javascript
// src/utils/logger.js
const winston = require('winston');

const logger = winston.createLogger({
  level: 'info',
  format: winston.format.combine(
    winston.format.timestamp(),
    winston.format.json()
  ),
  transports: [
    new winston.transports.File({ filename: 'logs/error.log', level: 'error' }),
    new winston.transports.File({ filename: 'logs/combined.log' }),
    new winston.transports.Console({
      format: winston.format.simple()
    })
  ]
});

module.exports = logger;
```

---

## 🚀 Start Server

```bash
# Development
npm run dev

# Production
npm start

# Server will start on http://localhost:3001
```

---

**Backend pronto para integrar com todas as APIs!** 🚀
