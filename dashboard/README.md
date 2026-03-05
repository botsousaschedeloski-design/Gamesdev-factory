# 📊 GamesDev Factory Dashboard

**Dashboard de Controle em Tempo Real para Jogos Mobile**

[![Deploy to Railway](https://railway.app/button.svg)](https://railway.app/new/template?template=https://github.com/your-username/gamesdev-factory)

---

## 🎯 Visão Geral

Dashboard completo para monitorar **12 jogos em 4 mercados** em tempo real:

- ✅ **Indonésia** (Semana 1)
- ✅ **Paquistão** (Semana 2)
- ✅ **Bangladesh** (Semana 3)
- ✅ **Nigéria** (Semana 4)

---

## 🚀 Quick Start

### Backend

```bash
cd dashboard/backend
npm install
cp .env.example .env
# Edit .env with your API keys
npm start
# Server runs on http://localhost:3001
```

### Frontend (Em desenvolvimento)

```bash
cd dashboard/frontend
npm install
npm start
# App runs on http://localhost:3000
```

---

## 📡 API Endpoints

### Metrics

| Endpoint | Description |
|----------|-------------|
| `GET /api/metrics/overview` | Overview metrics (24h) |
| `GET /api/metrics/market/:id` | Market-specific metrics |
| `GET /api/metrics/game/:id` | Game-specific metrics |
| `GET /api/metrics/revenue` | Revenue breakdown |
| `GET /api/metrics/downloads` | Downloads breakdown |
| `GET /api/metrics/retention` | Retention metrics |

### Decisions

| Endpoint | Description |
|----------|-------------|
| `GET /api/decisions` | List all decisions |
| `GET /api/decisions/auto` | Auto-decisions (24h) |
| `GET /api/decisions/pending` | Pending approval |
| `POST /api/decisions/:id/approve` | Approve decision |
| `POST /api/decisions/:id/reject` | Reject decision |

### Alerts

| Endpoint | Description |
|----------|-------------|
| `GET /api/alerts` | List all alerts |
| `GET /api/alerts/active` | Active alerts |
| `POST /api/alerts/:id/dismiss` | Dismiss alert |

### Games

| Endpoint | Description |
|----------|-------------|
| `GET /api/games` | List all games |
| `GET /api/games/:id` | Game details |
| `GET /api/games/:id/metrics` | Game metrics |

---

## 📊 Features

### Real-Time Metrics

- **Downloads**: Hoje, D7, D30, Total
- **Revenue**: AdMob + IAP, por jogo/mercado
- **Retention**: D1, D7, D30
- **Engagement**: DAU, MAU, Sessions, Session Length
- **Monetization**: eCPM, Fill Rate, ARPDAU

### Decision Engine

- **Auto-Decisions**: ROAS, CPI, Retention optimization
- **Pending Decisions**: Require approval
- **Impact Tracking**: Revenue impact, ROI

### Alert System

- **Critical**: Email + SMS + Telegram
- **Warning**: Email
- **Info**: Email

---

## 🏗️ Architecture

```
┌─────────────────────────────────────────┐
│          Frontend (React)               │
│         http://localhost:3000           │
└─────────────────┬───────────────────────┘
                  │
                  ▼
┌─────────────────────────────────────────┐
│          Backend (Node.js)              │
│         http://localhost:3001           │
├─────────────────────────────────────────┤
│  Routes: metrics, decisions, alerts    │
│  Cron: fetch-metrics, auto-decisions   │
└─────────────────┬───────────────────────┘
                  │
                  ▼
┌─────────────────────────────────────────┐
│       Firebase Firestore (DB)           │
│  - Metrics                              │
│  - Decisions                            │
│  - Alerts                               │
│  - Games                                │
└─────────────────────────────────────────┘
                  │
                  ▼
┌─────────────────────────────────────────┐
│         External APIs                   │
│  - Google Play Console                  │
│  - AdMob                                │
│  - Firebase Analytics                   │
│  - Facebook Ads                         │
│  - Google Ads                           │
└─────────────────────────────────────────┘
```

---

## 📁 Project Structure

```
dashboard/
├── backend/
│   ├── src/
│   │   ├── index.js              # Entry point
│   │   ├── routes/
│   │   │   ├── metrics.js
│   │   │   ├── decisions.js
│   │   │   ├── alerts.js
│   │   │   └── games.js
│   │   ├── cron/
│   │   │   ├── fetch-metrics.js
│   │   │   └── auto-decisions.js
│   │   └── utils/
│   │       └── logger.js
│   ├── .env.example
│   ├── package.json
│   └── DEPLOY.md
├── frontend/
│   ├── src/
│   │   ├── components/
│   │   ├── hooks/
│   │   └── services/
│   ├── package.json
│   └── README.md
└── README.md
```

---

## 🔧 Configuration

### Environment Variables

Create `.env` file in `backend/` directory:

```bash
# Firebase
FIREBASE_PROJECT_ID=gamesdev-factory
FIREBASE_CLIENT_EMAIL=your-service-account@...
FIREBASE_PRIVATE_KEY="-----BEGIN PRIVATE KEY-----\n..."

# Google Play
GOOGLE_PLAY_PACKAGE_NAME=com.afonso.fxtrade.gamesdev
GOOGLE_PLAY_CLIENT_EMAIL=your-api@...
GOOGLE_PLAY_PRIVATE_KEY="-----BEGIN PRIVATE KEY-----\n..."

# AdMob
ADMOB_ACCOUNT_ID=pub-xxxxxxxxxxxxxxxx

# Server
PORT=3001
NODE_ENV=production
```

See `.env.example` for full list.

---

## 🚀 Deploy

### Backend (Railway)

```bash
# 1. Push to GitHub
git push origin main

# 2. Deploy on Railway
https://railway.app/new/template

# 3. Add environment variables
# Copy from .env.example

# 4. Deploy
# Automatic on push
```

See `backend/DEPLOY.md` for detailed instructions.

### Frontend (Vercel)

```bash
# 1. Install Vercel CLI
npm install -g vercel

# 2. Deploy
cd frontend
vercel

# 3. Configure API URL
# Edit: src/services/api.js
const API_URL = 'https://your-backend.railway.app/api';
```

---

## 📊 Monitoring

### Logs

```bash
# Railway
railway logs

# Render
https://dashboard.render.com/web/your-service → Logs
```

### Metrics

```bash
# Health check
curl https://your-app.railway.app/health

# Overview metrics
curl https://your-app.railway.app/api/metrics/overview
```

---

## 🤖 Decision Engine

### Auto-Decisions

| Condition | Action | Approval |
|-----------|--------|----------|
| ROAS > 4x | Increase budget +20% | Auto |
| ROAS < 2x | Decrease budget -30% | Auto |
| CPI > 100% meta | Pause campaign | Auto |
| Retention D1 < 30% | Optimize onboarding | Auto |
| Revenue > 150% meta | Expand market | Required |

---

## 🔔 Alerts

### Severity Levels

| Level | Channels | Example |
|-------|----------|---------|
| Critical | Email + SMS + Telegram | Revenue < 50% |
| Warning | Email | Retention D1 < 30% |
| Info | Email | Revenue > 150% |

---

## 📈 Roadmap

- [x] Backend API implementation
- [ ] Frontend React components
- [ ] Google Play API integration
- [ ] AdMob API integration
- [ ] Firebase Analytics integration
- [ ] Facebook Ads integration
- [ ] Deploy to production
- [ ] Mobile app (React Native)

---

## 📝 License

MIT © 2026 Afonso Sousa

---

**Dashboard em produção para monitorar todos os jogos!** 🚀
