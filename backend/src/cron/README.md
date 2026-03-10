# 🤖 GamesDev Factory - Cron Job de Atualização

**Atualização Automática do Dashboard**

---

## ⏰ CRON JOBS:

### **1. Atualização de Métricas (3x ao dia):**
```
09:00 - Atualização Matinal
15:00 - Atualização Vespertina
21:00 - Atualização Noturna
```

### **2. Backup de Dados (Diário):**
```
00:00 - Backup diário
```

### **3. Limpeza de Cache (Semanal):**
```
Domingo 03:00 - Limpeza semanal
```

---

## 📁 ESTRUTURA:

```
backend/
├── src/
│   ├── cron/
│   │   ├── updateMetrics.js      (3x/dia)
│   │   ├── dailyBackup.js        (1x/dia)
│   │   └── weeklyCleanup.js      (1x/semana)
│   └── services/
│       ├── metricsService.js
│       └── backupService.js
└── cron-config.json
```

---

## ⏰ CRON CONFIGURATION:

### **updateMetrics.js (3x ao dia):**
```javascript
// 09:00, 15:00, 21:00
const cron = require('node-cron');

// Morning update (09:00)
cron.schedule('0 9 * * *', async () => {
  console.log('🌅 Morning metrics update...');
  await updateAllMetrics('morning');
});

// Afternoon update (15:00)
cron.schedule('0 15 * * *', async () => {
  console.log('☀️ Afternoon metrics update...');
  await updateAllMetrics('afternoon');
});

// Evening update (21:00)
cron.schedule('0 21 * * *', async () => {
  console.log('🌙 Evening metrics update...');
  await updateAllMetrics('evening');
});
```

### **dailyBackup.js (Diário):**
```javascript
// 00:00
const cron = require('node-cron');

cron.schedule('0 0 * * *', async () => {
  console.log('💾 Daily backup...');
  await createDailyBackup();
});
```

### **weeklyCleanup.js (Semanal):**
```javascript
// Domingo 03:00
const cron = require('node-cron');

cron.schedule('0 3 * * 0', async () => {
  console.log('🧹 Weekly cleanup...');
  await cleanupOldData();
});
```

---

## 📊 METRICS UPDATE LOGIC:

```javascript
async function updateAllMetrics(period) {
  const games = await getAllGames();
  
  for (const game of games) {
    // Track access
    await trackAccess(game.id, period);
    
    // Get AdMob metrics
    const admobMetrics = await getAdMobMetrics(game.appId);
    
    // Update database
    await updateGameMetrics(game.id, {
      accesses: admobMetrics.activeUsers,
      revenue: admobMetrics.estimatedEarnings,
      impressions: admobMetrics.impressions
    });
  }
  
  console.log(`✅ Metrics updated for ${games.length} games`);
}
```

---

## 💾 BACKUP LOGIC:

```javascript
async function createDailyBackup() {
  const date = new Date().toISOString().split('T')[0];
  
  // Export all metrics
  const metrics = await getAllMetrics();
  
  // Save to backup file
  const backupPath = `./backups/${date}-metrics.json`;
  await fs.writeFile(backupPath, JSON.stringify(metrics, null, 2));
  
  console.log(`💾 Backup created: ${backupPath}`);
}
```

---

## 🧹 CLEANUP LOGIC:

```javascript
async function cleanupOldData() {
  const thirtyDaysAgo = new Date();
  thirtyDaysAgo.setDate(thirtyDaysAgo.getDate() - 30);
  
  // Delete old metrics
  await db.metrics.deleteMany({
    date: { $lt: thirtyDaysAgo }
  });
  
  console.log('🧹 Old data cleaned up');
}
```

---

## 📁 DEPLOY OPTIONS:

### **Opção 1: Railway/Render (Recomendado):**
```yaml
# railway.toml
[build]
builder = "NODEJS"

[deploy]
startCommand = "node src/cron/start.js"
restartPolicyType = "ON_FAILURE"
```

### **Opção 2: GitHub Actions:**
```yaml
# .github/workflows/update-metrics.yml
name: Update Metrics

on:
  schedule:
    - cron: '0 9 * * *'
    - cron: '0 15 * * *'
    - cron: '0 21 * * *'

jobs:
  update:
    runs-on: ubuntu-latest
    steps:
      - uses: actions/checkout@v2
      - uses: actions/setup-node@v2
      - run: npm install
      - run: node src/cron/updateMetrics.js
```

### **Opção 3: Servidor Próprio:**
```bash
# Instalar no servidor
npm install node-cron

# Adicionar ao crontab
crontab -e

# Adicionar linhas:
0 9 * * * /usr/bin/node /path/to/updateMetrics.js
0 15 * * * /usr/bin/node /path/to/updateMetrics.js
0 21 * * * /usr/bin/node /path/to/updateMetrics.js
0 0 * * * /usr/bin/node /path/to/dailyBackup.js
0 3 * * 0 /usr/bin/node /path/to/weeklyCleanup.js
```

---

## 📊 MONITORING:

### **Health Check:**
```javascript
// Health endpoint
app.get('/api/cron/health', (req, res) => {
  res.json({
    status: 'ok',
    lastUpdate: lastUpdateTime,
    nextUpdate: nextUpdateTime,
    jobs: cronJobs.length
  });
});
```

### **Logging:**
```javascript
const fs = require('fs');

function log(message) {
  const timestamp = new Date().toISOString();
  const logMessage = `[${timestamp}] ${message}\n`;
  fs.appendFileSync('./cron.log', logMessage);
}
```

---

## 🚀 SETUP:

### **1. Instalar Dependências:**
```bash
npm install node-cron
```

### **2. Configurar Variáveis:**
```bash
# .env
DATABASE_URL=mongodb://...
ADMOB_API_KEY=...
```

### **3. Start Cron Jobs:**
```bash
node src/cron/start.js
```

---

**Dashboard com atualização automática!** 🚀
