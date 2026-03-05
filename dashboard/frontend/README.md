# Frontend - GamesDev Factory Dashboard

**React.js + Tailwind CSS + Recharts**

---

## 🚀 Setup

```bash
cd dashboard/frontend
npm install
npm start
```

Access: http://localhost:3000

---

## 📁 Estrutura

```
frontend/
├── src/
│   ├── App.js                # Main app component
│   ├── index.js              # Entry point
│   ├── components/
│   │   ├── Overview/
│   │   │   ├── Overview.js
│   │   │   ├── MetricCard.js
│   │   │   ├── MarketSummary.js
│   │   │   └── AlertsPanel.js
│   │   ├── Market/
│   │   │   ├── Market.js
│   │   │   ├── MarketMetrics.js
│   │   │   ├── GamesList.js
│   │   │   └── MarketCharts.js
│   │   ├── Games/
│   │   │   ├── Games.js
│   │   │   ├── GameDetails.js
│   │   │   ├── GameMetrics.js
│   │   │   └── GameCharts.js
│   │   ├── Decisions/
│   │   │   ├── Decisions.js
│   │   │   ├── AutoDecisions.js
│   │   │   ├── PendingDecisions.js
│   │   │   └── DecisionCard.js
│   │   └── Development/
│   │       ├── Development.js
│   │       ├── ProjectStatus.js
│   │       └── TasksList.js
│   ├── hooks/
│   │   ├── useMetrics.js
│   │   ├── useDecisions.js
│   │   ├── useAlerts.js
│   │   └── useGames.js
│   ├── services/
│   │   ├── api.js
│   │   ├── firebase.js
│   │   └── integrations.js
│   ├── utils/
│   │   ├── formatters.js
│   │   └── helpers.js
│   └── styles/
│       └── index.css
├── public/
│   └── index.html
└── package.json
```

---

## 🎨 Components

### Overview Page

```javascript
// components/Overview/Overview.js
import React from 'react';
import MetricCard from './MetricCard';
import MarketSummary from './MarketSummary';
import AlertsPanel from './AlertsPanel';

function Overview({ metrics, markets, alerts }) {
  return (
    <div className="p-6">
      <h1 className="text-3xl font-bold mb-6">📊 Visão Geral</h1>
      
      {/* Metric Cards */}
      <div className="grid grid-cols-4 gap-4 mb-6">
        <MetricCard 
          title="Downloads (24h)" 
          value={metrics.downloadsToday} 
          trend={metrics.downloadsTrend}
          icon="📥"
        />
        <MetricCard 
          title="Revenue (24h)" 
          value={`$${metrics.revenueToday}`} 
          trend={metrics.revenueTrend}
          icon="💰"
        />
        <MetricCard 
          title="DAU" 
          value={metrics.dau} 
          trend={metrics.dauTrend}
          icon="👥"
        />
        <MetricCard 
          title="ARPDAU" 
          value={`$${metrics.arpdau}`} 
          trend={metrics.arpdauTrend}
          icon="📈"
        />
      </div>
      
      {/* Market Summary */}
      <MarketSummary markets={markets} />
      
      {/* Alerts */}
      <AlertsPanel alerts={alerts} />
    </div>
  );
}
```

### Market Page

```javascript
// components/Market/Market.js
import React from 'react';
import MarketMetrics from './MarketMetrics';
import GamesList from './GamesList';
import MarketCharts from './MarketCharts';

function Market({ marketId, metrics, games }) {
  return (
    <div className="p-6">
      <h1 className="text-3xl font-bold mb-6">🌍 {marketId}</h1>
      
      <MarketMetrics metrics={metrics} />
      <GamesList games={games} />
      <MarketCharts metrics={metrics} />
    </div>
  );
}
```

### Decisions Page

```javascript
// components/Decisions/Decisions.js
import React from 'react';
import AutoDecisions from './AutoDecisions';
import PendingDecisions from './PendingDecisions';

function Decisions({ autoDecisions, pendingDecisions }) {
  return (
    <div className="p-6">
      <h1 className="text-3xl font-bold mb-6">🤖 Decision Engine</h1>
      
      <AutoDecisions decisions={autoDecisions} />
      <PendingDecisions decisions={pendingDecisions} />
    </div>
  );
}
```

---

## 🔗 API Integration

```javascript
// services/api.js
import axios from 'axios';

const API_URL = 'http://localhost:3001/api';

const api = axios.create({
  baseURL: API_URL,
  timeout: 10000
});

export const metricsAPI = {
  getOverview: () => api.get('/metrics/overview'),
  getMarket: (marketId) => api.get(`/metrics/market/${marketId}`),
  getGame: (gameId) => api.get(`/metrics/game/${gameId}`),
  getRevenue: () => api.get('/metrics/revenue'),
  getDownloads: () => api.get('/metrics/downloads'),
  getRetention: () => api.get('/metrics/retention')
};

export const decisionsAPI = {
  getAll: () => api.get('/decisions'),
  getAuto: () => api.get('/decisions/auto'),
  getPending: () => api.get('/decisions/pending'),
  approve: (id) => api.post(`/decisions/${id}/approve`),
  reject: (id) => api.post(`/decisions/${id}/reject`)
};

export const alertsAPI = {
  getAll: () => api.get('/alerts'),
  getActive: () => api.get('/alerts/active'),
  dismiss: (id) => api.post(`/alerts/${id}/dismiss`)
};

export const gamesAPI = {
  getAll: () => api.get('/games'),
  getById: (id) => api.get(`/games/${id}`),
  getMetrics: (id) => api.get(`/games/${id}/metrics`)
};
```

---

## 🎣 Custom Hooks

```javascript
// hooks/useMetrics.js
import { useQuery } from '@tanstack/react-query';
import { metricsAPI } from '../services/api';

export function useOverviewMetrics() {
  return useQuery({
    queryKey: ['metrics', 'overview'],
    queryFn: metricsAPI.getOverview,
    refetchInterval: 15 * 60 * 1000 // 15 minutes
  });
}

export function useMarketMetrics(marketId) {
  return useQuery({
    queryKey: ['metrics', 'market', marketId],
    queryFn: () => metricsAPI.getMarket(marketId),
    refetchInterval: 15 * 60 * 1000
  });
}

export function useGameMetrics(gameId) {
  return useQuery({
    queryKey: ['metrics', 'game', gameId],
    queryFn: () => metricsAPI.getGame(gameId),
    refetchInterval: 15 * 60 * 1000
  });
}
```

---

## 📊 Charts (Recharts)

```javascript
// components/Overview/RevenueChart.js
import React from 'react';
import { LineChart, Line, XAxis, YAxis, Tooltip, ResponsiveContainer } from 'recharts';

function RevenueChart({ data }) {
  return (
    <ResponsiveContainer width="100%" height={300}>
      <LineChart data={data}>
        <XAxis dataKey="date" />
        <YAxis />
        <Tooltip />
        <Line type="monotone" dataKey="revenue" stroke="#8884d8" />
      </LineChart>
    </ResponsiveContainer>
  );
}
```

---

## 🎨 Tailwind Config

```javascript
// tailwind.config.js
module.exports = {
  content: [
    "./src/**/*.{js,jsx,ts,tsx}"
  ],
  theme: {
    extend: {
      colors: {
        primary: '#3B82F6',
        success: '#10B981',
        warning: '#F59E0B',
        danger: '#EF4444'
      }
    }
  },
  plugins: []
}
```

---

## 🚀 Start Frontend

```bash
# Development
npm start

# Build for production
npm run build

# Frontend will start on http://localhost:3000
```

---

**Frontend pronto para visualizar todos os dados!** 🎨
