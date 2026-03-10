# 🧠 GamesDev Factory - Memória de Longuíssimo Prazo

**Metodologia de Armazenamento e Recuperação de Dados Históricos**

---

## 🎯 OBJETIVO:

Armazenar dados históricos dos jogos por **anos**, permitindo:
- Análise de tendências de longo prazo
- Comparação ano a ano (YoY)
- Machine Learning e previsões
- Auditoria e compliance

---

## 📁 ESTRATÉGIA DE ARMAZENAMENTO:

### **Camadas de Memória:**

```
┌─────────────────────────────────────────┐
│  Memória de Curto Prazo (30 dias)      │
│  - Banco principal (MongoDB/Postgres)  │
│  - Acesso rápido                        │
│  - Dados brutos                         │
└─────────────────────────────────────────┘
              ↓ (após 30 dias)
┌─────────────────────────────────────────┐
│  Memória de Médio Prazo (1 ano)        │
│  - Data Warehouse (BigQuery/Redshift)  │
│  - Dados agregados por dia              │
│  - Acesso médio                         │
└─────────────────────────────────────────┘
              ↓ (após 1 ano)
┌─────────────────────────────────────────┐
│  Memória de Longo Prazo (5+ anos)      │
│  - Data Lake (S3/GCS)                  │
│  - Dados agregados por mês/ano         │
│  - Acesso frio (archive)                │
│  - Compressão (Parquet/ORC)            │
└─────────────────────────────────────────┘
```

---

## 📊 ESTRUTURA DE DADOS:

### **1. Raw Data (Curto Prazo):**
```json
{
  "gameId": "teenpatti",
  "date": "2026-03-10",
  "period": "morning",
  "accesses": 1234,
  "revenue": 45.67,
  "impressions": 5678,
  "clicks": 123,
  "timestamp": "2026-03-10T09:00:00Z"
}
```

### **2. Aggregated Day (Médio Prazo):**
```json
{
  "gameId": "teenpatti",
  "date": "2026-03-10",
  "totalAccesses": 3702,
  "totalRevenue": 137.01,
  "totalImpressions": 17034,
  "totalClicks": 369,
  "avgECPM": 8.05,
  "peakPeriod": "afternoon"
}
```

### **3. Aggregated Month (Longo Prazo):**
```json
{
  "gameId": "teenpatti",
  "month": "2026-03",
  "totalAccesses": 114762,
  "totalRevenue": 4247.31,
  "totalImpressions": 528054,
  "totalClicks": 11439,
  "avgECPM": 8.05,
  "peakDay": "2026-03-15",
  "growth": 12.5
}
```

### **4. Aggregated Year (Longuíssimo Prazo):**
```json
{
  "gameId": "teenpatti",
  "year": "2026",
  "totalAccesses": 1377144,
  "totalRevenue": 50967.72,
  "totalImpressions": 6336648,
  "totalClicks": 137268,
  "avgECPM": 8.05,
  "peakMonth": "2026-03",
  "growth": 15.3,
  "userRetention": 45.2
}
```

---

## 🗄️ TECNOLOGIAS:

### **Curto Prazo (0-30 dias):**
```
- MongoDB Atlas (principal)
- Redis (cache)
- Acesso: < 100ms
```

### **Médio Prazo (30 dias - 1 ano):**
```
- Google BigQuery
- Amazon Redshift
- Acesso: < 1s
- Agregação diária automática
```

### **Longo Prazo (1-5+ anos):**
```
- Amazon S3 / Google Cloud Storage
- Formato: Parquet (comprimido)
- Acesso: < 5s (cold storage)
- Partition: year/month
```

---

## ⏰ DATA LIFECYCLE:

### **Dia 1-30:**
```
✅ Dados brutos no MongoDB
✅ Acesso rápido
✅ Atualização 3x/dia
```

### **Dia 31:**
```
📊 Agregação diária automática
📦 Movido para BigQuery/Redshift
🗑️ Deletado do MongoDB
```

### **Dia 365:**
```
📊 Agregação mensal automática
📦 Movido para S3/GCS (Parquet)
🗑️ Deletado do BigQuery/Redshift
```

### **Ano 5+:**
```
📊 Agregação anual
📦 Archive profundo (Glacier/Coldline)
🗑️ Opcional: deletar após 10 anos
```

---

## 🔄 AUTOMATION:

### **Daily Aggregation (01:00):**
```javascript
// Agregar dados do dia anterior
cron.schedule('0 1 * * *', async () => {
  const yesterday = new Date();
  yesterday.setDate(yesterday.getDate() - 1);
  
  await aggregateDailyMetrics(yesterday);
  await moveToDataWarehouse(yesterday);
  await deleteFromMongoDB(yesterday);
});
```

### **Monthly Aggregation (Dia 1, 02:00):**
```javascript
// Agregar dados do mês anterior
cron.schedule('0 2 1 * *', async () => {
  const lastMonth = new Date();
  lastMonth.setMonth(lastMonth.getMonth() - 1);
  
  await aggregateMonthlyMetrics(lastMonth);
  await moveToDataLake(lastMonth);
  await deleteFromDataWarehouse(lastMonth);
});
```

### **Yearly Aggregation (Jan 1, 03:00):**
```javascript
// Agregar dados do ano anterior
cron.schedule('0 3 1 1 *', async () => {
  const lastYear = new Date();
  lastYear.setFullYear(lastYear.getFullYear() - 1);
  
  await aggregateYearlyMetrics(lastYear);
  await moveToArchive(lastYear);
});
```

---

## 📊 QUERY EXAMPLES:

### **Curto Prazo (MongoDB):**
```javascript
// Últimos 7 dias
db.metrics.find({
  gameId: 'teenpatti',
  date: { $gte: new Date('2026-03-03') }
}).sort({ date: -1 });
```

### **Médio Prazo (BigQuery):**
```sql
-- Últimos 6 meses
SELECT 
  date,
  SUM(totalAccesses) as accesses,
  SUM(totalRevenue) as revenue
FROM `gamesdev.metrics.daily`
WHERE gameId = 'teenpatti'
  AND date >= DATE_SUB(CURRENT_DATE(), INTERVAL 6 MONTH)
GROUP BY date
ORDER BY date DESC;
```

### **Longo Prazo (S3 + Athena):**
```sql
-- Ano inteiro
SELECT 
  month,
  SUM(totalAccesses) as accesses,
  SUM(totalRevenue) as revenue,
  AVG(avgECPM) as avgECPM
FROM s3_gamesdev_metrics.monthly
WHERE gameId = 'teenpatti'
  AND year = '2026'
GROUP BY month
ORDER BY month;
```

---

## 💾 BACKUP STRATEGY:

### **Backup Diário:**
```
- Backup completo do MongoDB
- S3 (versão atual)
- Retenção: 30 dias
```

### **Backup Semanal:**
```
- Backup completo do Data Warehouse
- Glacier (archive)
- Retenção: 1 ano
```

### **Backup Mensal:**
```
- Backup completo do Data Lake
- Glacier Deep Archive
- Retenção: 5 anos
```

### **Backup Anual:**
```
- Snapshot completo
- Múltiplas regiões
- Retenção: 10 anos
```

---

## 🔍 RECOVERY:

### **Recuperar Dados Recentes (< 30 dias):**
```
Tempo: < 1 minuto
Fonte: MongoDB
```

### **Recuperar Dados Antigos (30 dias - 1 ano):**
```
Tempo: < 5 minutos
Fonte: BigQuery/Redshift
```

### **Recuperar Dados Antigos (1-5 anos):**
```
Tempo: < 1 hora (cold storage)
Fonte: S3/GCS
```

### **Recuperar Dados Históricos (5+ anos):**
```
Tempo: 2-4 horas (deep archive)
Fonte: Glacier Deep Archive
```

---

## 📈 ANALYTICS:

### **Trends de Longo Prazo:**
```
- Crescimento ano a ano (YoY)
- Sazonalidade mensal
- Retenção de usuários
- LTV (Lifetime Value)
- Churn analysis
```

### **Machine Learning:**
```
- Previsão de receita
- Detecção de anomalias
- Otimização de eCPM
- Churn prediction
```

---

## 🚀 IMPLEMENTAÇÃO:

### **Fase 1 (Imediato):**
```
✅ MongoDB (curto prazo)
✅ Cron jobs de agregação
✅ Backup diário
```

### **Fase 2 (30 dias):**
```
⏳ BigQuery/Redshift (médio prazo)
⏳ Agregação diária automática
⏳ Migração automática
```

### **Fase 3 (1 ano):**
```
⏳ S3/GCS Data Lake (longo prazo)
⏳ Formato Parquet
⏳ Compressão
```

### **Fase 4 (5 anos):**
```
⏳ Glacier Deep Archive
⏳ Archive profundo
⏳ Retenção 10 anos
```

---

**Memória de longuíssimo prazo pronta!** 🧠
