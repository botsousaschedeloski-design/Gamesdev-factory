# 🚀 GamesDev Factory - Deploy Guide

**Scripts e Instruções para Deploy**

---

## 📁 SCRIPTS DE DEPLOY:

### **1. Deploy Frontend (Vercel):**
```bash
chmod +x deploy-deploy-vercel.sh
./deploy-deploy-vercel.sh
```

### **2. Deploy Backend (Railway):**
```bash
chmod +x deploy-deploy-railway.sh
./deploy-deploy-railway.sh
```

---

## 🚀 DEPLOY MANUAL:

### **Frontend (Vercel):**

```bash
# 1. Instalar Vercel CLI
npm install -g vercel

# 2. Login
vercel login

# 3. Deploy
cd frontend/public
vercel --prod
```

**URL:** `https://gamesdev-factory-dashboard.vercel.app`

---

### **Backend (Railway):**

```bash
# 1. Instalar Railway CLI
npm install -g @railway/cli

# 2. Login
railway login

# 3. Init
cd backend
railway init

# 4. Add Variables
railway variables set DATABASE_URL=...
railway variables set ADMOB_API_KEY=...

# 5. Deploy
railway up
```

**URL:** `https://gamesdev-factory-api.up.railway.app`

---

### **Backend (Render):**

```
1. https://render.com
2. New → Web Service
3. Connect repo: Gamesdev-factory
4. Root Directory: backend
5. Build: npm install
6. Start: npm start
7. Deploy!
```

**URL:** `https://gamesdev-factory-api.onrender.com`

---

### **Backend (Vercel):**

```bash
cd backend
vercel --prod
```

**URL:** `https://gamesdev-factory-backend.vercel.app`

---

## 🗄️ MONGODB SETUP:

### **MongoDB Atlas (Free):**

```
1. https://mongodb.com/cloud/atlas/register
2. Create Cluster (Free M0)
3. Database Access → Create User
4. Network Access → Add IP: 0.0.0.0/0
5. Connect → Connection String
6. Copy string e substitua user:pass
```

**Connection String:**
```
mongodb+srv://user:password@cluster.mongodb.net/gamesdev
```

---

## ⚙️ ENVIRONMENT VARIABLES:

### **Backend (.env):**
```bash
DATABASE_URL=mongodb+srv://user:pass@cluster.mongodb.net/gamesdev
ADMOB_API_KEY=your-api-key
PORT=3000
NODE_ENV=production
```

### **Frontend (.env.local):**
```bash
NEXT_PUBLIC_API_URL=https://gamesdev-factory-api.up.railway.app
```

---

## 📊 CRON JOBS:

### **Railway:**
```toml
# railway.toml já configurado
# Cron jobs rodam automaticamente
```

### **Render:**
```yaml
# render.yaml já configurado
# Cron jobs rodam automaticamente
```

### **Vercel:**
```json
// vercel.json já configurado
// Cron jobs via Vercel Cron
```

---

## 🔍 MONITORING:

### **Health Check:**
```
GET https://gamesdev-factory-api.up.railway.app/api/dashboard/overview
```

### **Logs:**
```bash
# Railway
railway logs

# Render
# Dashboard → Logs

# Vercel
vercel logs
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

**Deploy pronto!** 🚀
