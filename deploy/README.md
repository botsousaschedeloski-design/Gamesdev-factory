# 🚀 Deploy Configuration Files

**Railway + Render + Vercel**

---

## 🚂 RAILWAY:

### **railway.toml**
```toml
[build]
builder = "NODEJS"

[deploy]
startCommand = "npm start"
restartPolicyType = "ON_FAILURE"
healthcheckPath = "/api/dashboard/overview"
healthcheckTimeout = 100

[cron]
# Update Metrics (3x daily)
updateMetrics = "0 9,15,21 * * *"
updateMetricsCommand = "node src/cron/updateMetrics.js"

# Daily Backup
dailyBackup = "0 0 * * *"
dailyBackupCommand = "node src/cron/dailyBackup.js"

# Weekly Cleanup
weeklyCleanup = "0 3 * * 0"
weeklyCleanupCommand = "node src/cron/weeklyCleanup.js"
```

### **Deploy Steps:**
```bash
# 1. Install Railway CLI
npm install -g @railway/cli

# 2. Login
railway login

# 3. Init project
railway init

# 4. Deploy
railway up

# 5. Add environment variables
railway variables set DATABASE_URL=...
railway variables set ADMOB_API_KEY=...
```

---

## 🎨 RENDER:

### **render.yaml**
```yaml
services:
  - type: web
    name: gamesdev-dashboard-api
    env: node
    region: oregon
    plan: free
    buildCommand: npm install
    startCommand: npm start
    envVars:
      - key: DATABASE_URL
        sync: false
      - key: ADMOB_API_KEY
        sync: false
      - key: PORT
        value: 3000

  - type: cron
    name: update-metrics-cron
    env: node
    schedule: "0 9,15,21 * * *"
    command: node src/cron/updateMetrics.js

  - type: cron
    name: daily-backup-cron
    env: node
    schedule: "0 0 * * *"
    command: node src/cron/dailyBackup.js

  - type: cron
    name: weekly-cleanup-cron
    env: node
    schedule: "0 3 * * 0"
    command: node src/cron/weeklyCleanup.js
```

### **Deploy Steps:**
```bash
# 1. Push to GitHub
git push origin main

# 2. Connect on Render
# https://render.com → New → Web Service
# Select repo: Gamesdev-factory
# Root Directory: backend
```

---

## ▲ VERCEL:

### **vercel.json**
```json
{
  "version": 2,
  "builds": [
    {
      "src": "backend/src/index.js",
      "use": "@vercel/node"
    },
    {
      "src": "frontend/public/**",
      "use": "@vercel/static"
    }
  ],
  "routes": [
    {
      "src": "/api/(.*)",
      "dest": "backend/src/index.js"
    },
    {
      "src": "/(.*)",
      "dest": "frontend/public/$1"
    }
  ],
  "env": {
    "DATABASE_URL": "@database_url",
    "ADMOB_API_KEY": "@admob_api_key",
    "NODE_ENV": "production"
  }
}
```

### **Deploy Steps:**
```bash
# 1. Install Vercel CLI
npm install -g vercel

# 2. Login
vercel login

# 3. Deploy
cd frontend/public
vercel --prod

# 4. Deploy Backend
cd ../../backend
vercel --prod
```

---

## 📊 ENVIRONMENT VARIABLES:

### **Required:**
```bash
DATABASE_URL=mongodb+srv://user:pass@cluster.mongodb.net/gamesdev
ADMOB_API_KEY=your-admob-api-key
PORT=3000
NODE_ENV=production
```

### **Optional:**
```bash
LOG_LEVEL=info
BACKUP_ENABLED=true
CLEANUP_DAYS=30
```

---

## 🗄️ MONGODB SETUP:

### **MongoDB Atlas (Free Tier):**
```
1. https://mongodb.com/cloud/atlas
2. Create Cluster (Free M0)
3. Create Database User
4. Whitelist IP: 0.0.0.0/0
5. Connection String:
   mongodb+srv://user:pass@cluster.mongodb.net/gamesdev
```

---

## 📁 FILES CREATED:

```
✅ railway.toml
✅ render.yaml
✅ vercel.json
✅ backend/package.json
✅ backend/README.md
```

---

**Ready to deploy!** 🚀
