# 🚀 Deploy Dashboard Backend

**Railway.app** (Recommended) ou **Render.com**

---

## 📋 Pré-Deploy

### 1. Criar Projeto Firebase

```bash
1. Acesse: https://console.firebase.google.com
2. Click "Add project"
3. Nome: gamesdev-factory
4. Enable Google Analytics: Yes
5. Click "Create project"
6. Aguardar criação (~30 segundos)
```

### 2. Gerar Service Account Key

```bash
1. Firebase Console → Settings → Service Accounts
2. Click "Generate new private key"
3. Download JSON file
4. Extrair valores para .env:
   - project_id
   - client_email
   - private_key
```

### 3. Configurar .env

```bash
cd dashboard/backend
cp .env.example .env
# Edit .env com suas chaves reais
```

---

## 🚀 Deploy no Railway

### Opção A: Via GitHub (Recomendado)

```bash
# 1. Push para GitHub
git add .
git commit -m "Dashboard backend ready for deploy"
git push origin main

# 2. Railway
1. Acesse: https://railway.app
2. Click "New Project"
3. Select "Deploy from GitHub repo"
4. Select repo: gamesdev-factory
5. Select branch: main
6. Root directory: dashboard/backend
7. Click "Deploy"

# 3. Configurar variáveis de ambiente
1. Railway → Settings → Variables
2. Add all variables from .env
3. Click "Save"

# 4. Deploy automático
- Railway deploya automaticamente a cada push
- URL: https://your-app.railway.app
```

### Opção B: Via CLI

```bash
# 1. Instalar Railway CLI
npm install -g @railway/cli

# 2. Login
railway login

# 3. Inicializar projeto
cd dashboard/backend
railway init

# 4. Deploy
railway up

# 5. Adicionar variáveis de ambiente
railway variables set FIREBASE_PROJECT_ID=xxx
railway variables set FIREBASE_CLIENT_EMAIL=xxx
# ... repetir para todas as variáveis

# 6. Deploy com variáveis
railway up
```

---

## 🚀 Deploy no Render

```bash
# 1. Acesse: https://render.com
2. Click "New +" → "Web Service"
3. Connect GitHub repo
4. Select repo: gamesdev-factory
5. Configure:
   - Name: gamesdev-dashboard-backend
   - Root Directory: dashboard/backend
   - Runtime: Node
   - Build Command: npm install
   - Start Command: npm start
   - Environment: Production

6. Add Environment Variables:
   - Click "Advanced" → "Add Environment Variable"
   - Add all variables from .env

7. Click "Create Web Service"
8. Aguardar deploy (~2-5 minutos)
9. URL: https://your-app.onrender.com
```

---

## 🔧 Configurar APIs

### Google Play Console API

```bash
# 1. Enable API
https://console.cloud.google.com/apis/library/androidpublisher.googleapis.com

# 2. Create Service Account
https://console.cloud.google.com/apis/credentials

# 3. Grant access in Play Console
https://play.google.com/console/developers
→ Settings → API access
→ Link service account
→ Grant access to "View financial reports" and "View download reports"
```

### AdMob API

```bash
# 1. Enable API
https://admob.google.com/home/api-access/

# 2. Get Account ID
AdMob → Account → Settings → Account ID (pub-xxxxxxxxxxxxxxxx)
```

### Firebase Analytics API

```bash
# Já habilitado com Firebase Admin SDK
# Service account já tem acesso automático
```

---

## ✅ Testar Deploy

### Health Check

```bash
curl https://your-app.railway.app/health

# Expected response:
{
  "status": "ok",
  "timestamp": "2026-03-05T09:00:00.000Z",
  "uptime": 123.456
}
```

### Test Endpoints

```bash
# Overview metrics
curl https://your-app.railway.app/api/metrics/overview

# Market metrics
curl https://your-app.railway.app/api/metrics/market/indonesia

# Game metrics
curl https://your-app.railway.app/api/metrics/game/domino-qq

# Decisions
curl https://your-app.railway.app/api/decisions

# Alerts
curl https://your-app.railway.app/api/alerts/active

# Games
curl https://your-app.railway.app/api/games
```

---

## 📊 Monitorar Deploy

### Railway

```bash
# Dashboard
https://railway.app/project/your-project

# Logs
railway logs

# Metrics
https://railway.app/project/your-project → Metrics
```

### Render

```bash
# Dashboard
https://dashboard.render.com/web/your-service

# Logs
https://dashboard.render.com/web/your-service → Logs
```

---

## 🔒 Security

### Production Checklist

- [ ] `.env` não commitado no Git
- [ ] Variáveis de ambiente configuradas no Railway/Render
- [ ] HTTPS habilitado (automático)
- [ ] CORS configurado para domínio do frontend
- [ ] Rate limiting habilitado
- [ ] Error logging ativo
- [ ] Health check endpoint funcionando

### Environment Variables (Production)

```bash
NODE_ENV=production
PORT=3001
FIREBASE_PROJECT_ID=xxx
FIREBASE_CLIENT_EMAIL=xxx
FIREBASE_PRIVATE_KEY="xxx"
DASHBOARD_URL=https://gamesdev-dashboard.vercel.app
ALERT_EMAIL=afonso@email.com
LOG_LEVEL=info
```

---

## 📈 Scaling

### Railway

- Auto-scaling incluso
- Upgrade para mais recursos: $5-20/mês
- Database: Railway Postgres ou Firebase

### Render

- Free tier: 750 hours/month
- Starter: $7/mês (mais recursos)
- Auto-scaling disponível

---

## 🎯 Post-Deploy

### 1. Configurar Frontend

```bash
# Atualizar API URL no frontend
cd dashboard/frontend
# Edit: src/services/api.js
const API_URL = 'https://your-app.railway.app/api';
```

### 2. Testar Integrações

```bash
# Verificar se cron jobs estão rodando
railway logs | grep "Fetching metrics"

# Devem aparecer a cada 15 minutos
```

### 3. Configurar Alertas

```bash
# Testar sistema de alertas
curl -X POST https://your-app.railway.app/api/alerts/test

# Verificar se email/SMS foram enviados
```

---

## 💡 Troubleshooting

### Deploy falhou

```bash
# Verificar logs
railway logs

# Erros comuns:
# - Variáveis de ambiente faltando
# - Dependências não instaladas
# - Porta não configurada
```

### API não responde

```bash
# Verificar health check
curl https://your-app.railway.app/health

# Verificar logs em tempo real
railway logs --follow
```

### Cron jobs não rodam

```bash
# Verificar logs de cron
railway logs | grep "cron"

# Verificar se timezone está correto
# Railway usa UTC por padrão
```

---

**Backend pronto para deploy em produção!** 🚀
