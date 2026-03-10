# GamesDev Factory - Backend

**API + Cron Jobs para Dashboard**

---

## 🚀 DEPLOY NA RAILWAY:

### **Passo 1: Instalar Dependências**
```bash
npm install
```

### **Passo 2: Configurar Variáveis**
```bash
# .env
DATABASE_URL=mongodb+srv://...
ADMOB_API_KEY=...
PORT=3000
```

### **Passo 3: Deploy na Railway**
```bash
# Instalar Railway CLI
npm install -g @railway/cli

# Login
railway login

# Deploy
railway init
railway up
```

### **Passo 4: Configurar Cron Jobs**
```bash
# Na Railway, adicionar:
RAILWAY_CRON_ENABLED=true
```

---

## 🚀 DEPLOY NA RENDER:

### **Passo 1: Criar Web Service**
```
1. https://render.com
2. New → Web Service
3. Connect repo: Gamesdev-factory
4. Root Directory: backend
5. Build Command: npm install
6. Start Command: npm start
```

### **Passo 2: Configurar Variáveis**
```
DATABASE_URL=mongodb+srv://...
ADMOB_API_KEY=...
PORT=3000
```

### **Passo 3: Deploy Cron Jobs**
```
1. Render → Cron Jobs
2. New Cron Job
3. Name: update-metrics
4. Command: node src/cron/updateMetrics.js
5. Schedule: 0 9,15,21 * * *
```

---

## 🚀 DEPLOY NA VERCEL:

### **Dashboard Frontend**
```bash
cd frontend/public
vercel --prod
```

---

## 📊 VARIÁVEIS DE AMBIENTE:

```bash
# Database
DATABASE_URL=mongodb+srv://user:pass@cluster.mongodb.net/gamesdev

# AdMob API
ADMOB_API_KEY=your-api-key

# Server
PORT=3000
NODE_ENV=production

# Logging
LOG_LEVEL=info
```

---

## 📁 ESTRUTURA:

```
backend/
├── src/
│   ├── routes/
│   │   └── dashboard.ts
│   ├── cron/
│   │   ├── updateMetrics.js
│   │   ├── dailyBackup.js
│   │   ├── weeklyCleanup.js
│   │   └── start.js
│   ├── services/
│   │   ├── metricsService.js
│   │   └── admobService.js
│   ├── utils/
│   │   └── logger.js
│   └── index.js
├── package.json
└── .env.example
```

---

## 🔧 SETUP:

### **1. Instalar Dependências:**
```bash
npm install
```

### **2. Configurar .env:**
```bash
cp .env.example .env
# Editar .env com suas credenciais
```

### **3. Rodar Local:**
```bash
# API + Cron
npm run dev

# Só Cron
npm run cron
```

---

## 📊 API ENDPOINTS:

```
GET  /api/dashboard/overview
GET  /api/dashboard/games
GET  /api/dashboard/games/:id/metrics
GET  /api/dashboard/daily-access
GET  /api/dashboard/revenue-by-region
POST /api/track/download
POST /api/track/access
```

---

**Backend pronto para deploy!** 🚀
