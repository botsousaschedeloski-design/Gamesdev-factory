# 📊 Grafana Dashboard Setup Guide

**GamesDev Factory Dashboard**

---

## 🎯 Passo 1: Criar Conta no Grafana Cloud

### 1. Acesse:
```
https://grafana.com/auth/sign-up/create-user
```

### 2. Preencha:
```
Email: botsousaschedeloski@gmail.com
Username: gamesdev-factory
Password: (crie uma senha forte)
First Name: Afonso
Last Name: Sousa
```

### 3. Escolha Plano:
```
✅ FREE (Grátis para sempre)
- 3 usuários
- 10,000 séries de métricas
- 14 dias retention
- $0/mês
```

### 4. Confirme Email:
```
- Verifique seu email
- Click no link de confirmação
- Login no Grafana
```

---

## 🔧 Passo 2: Adicionar Datasource

### 1. No Grafana Dashboard:
```
1. Click "Connections" (menu lateral)
2. Click "Add new connection"
3. Search: "SimpleJSON"
4. Click "Install"
```

### 2. Configurar Datasource:
```
1. Click "Add new data source"
2. Select "SimpleJSON"
3. Configurar:

   Name: GamesDev API
   URL: https://jamesdev-factory.onrender.com/grafana
   
4. Click "Save & Test"
5. Deve aparecer: "Data source is working"
```

---

## 📈 Passo 3: Importar Dashboards

### Opção A: Importar JSON Pronto

1. **Download do Dashboard JSON**:
   - Baixe o arquivo `grafana-dashboard.json` deste repositório

2. **No Grafana**:
   ```
   1. Click "Dashboards" (menu lateral)
   2. Click "Import dashboard"
   3. Click "Upload dashboard JSON"
   4. Selecione o arquivo `grafana-dashboard.json`
   5. Select datasource: "GamesDev API"
   6. Click "Import"
   ```

### Opção B: Criar Dashboard Manual

1. **Criar Novo Dashboard**:
   ```
   1. Click "Dashboards" → "New dashboard"
   2. Click "Add visualization"
   3. Select datasource: "GamesDev API"
   ```

2. **Adicionar Panels**:

   **Panel 1: Downloads (24h)**
   ```
   Title: Downloads Today
   Query: downloads
   Visualization: Stat
   Unit: short
   ```

   **Panel 2: Revenue (24h)**
   ```
   Title: Revenue Today
   Query: revenue
   Visualization: Stat
   Unit: currency USD
   ```

   **Panel 3: DAU**
   ```
   Title: Daily Active Users
   Query: dau
   Visualization: Stat
   Unit: short
   ```

   **Panel 4: ARPDAU**
   ```
   Title: ARPDAU
   Query: arpdau
   Visualization: Stat
   Unit: currency USD
   ```

---

## 🔔 Passo 4: Configurar Alertas

### 1. Criar Alerta de Revenue:
```
1. Vá em "Alerting" → "New alert rule"
2. Select metric: revenue
3. Condition: revenue < 100 (threshold)
4. Evaluate every: 1h
5. Pending for: 5m
6. Add notification: Email
7. Click "Save rule"
```

### 2. Criar Alerta de DAU:
```
1. New alert rule
2. Select metric: dau
3. Condition: dau < 1000
4. Evaluate every: 1h
5. Pending for: 10m
6. Add notification: Email
7. Save rule
```

---

## 🎨 Passo 5: Customizar Dashboard

### Temas Disponíveis:
```
- Light theme
- Dark theme (recomendado)
```

### Layout Sugerido:
```
┌─────────────────────────────────────────────┐
│  GamesDev Factory Dashboard                 │
├─────────────────────────────────────────────┤
│  [Downloads] [Revenue] [DAU] [ARPDAU]      │
├─────────────────────────────────────────────┤
│  📈 Revenue (7 days)                        │
│  [Gráfico de linha]                         │
├─────────────────────────────────────────────┤
│  🌍 Por Mercado                             │
│  [Tabela com métricas por país]            │
├─────────────────────────────────────────────┤
│  🎮 Jogos Ativos                            │
│  [Cards com status de cada jogo]           │
└─────────────────────────────────────────────┘
```

---

## 📊 Endpoints da API para Grafana

| Endpoint | Método | Descrição |
|----------|--------|-----------|
| `/grafana/metrics` | GET | Time series metrics |
| `/grafana/health` | GET | Health check |
| `/api/metrics/overview` | GET | Overview metrics |
| `/api/games` | GET | Lista de jogos |
| `/api/alerts/active` | GET | Alertas ativos |

---

## 🔗 URLs Úteis

| Recurso | URL |
|---------|-----|
| **Grafana Cloud** | https://grafana.com |
| **Seu Dashboard** | https://gamesdev-factory.grafana.net |
| **API Backend** | https://jamesdev-factory.onrender.com |
| **Docs Grafana** | https://grafana.com/docs/ |

---

## ✅ Checklist de Setup

- [ ] Conta Grafana Cloud criada
- [ ] Plano Free ativado
- [ ] Datasource SimpleJSON instalado
- [ ] Datasource configurado (URL da API)
- [ ] Dashboard importado/criado
- [ ] Panels configurados
- [ ] Alertas configurados
- [ ] Email de notificação configurado
- [ ] Dashboard compartilhado (URL pública)

---

## 🎯 Resultado Final

Após configurar, você terá:

✅ **Dashboard Visual Profissional**
- Gráficos em tempo real
- Cards com métricas
- Tables com dados detalhados

✅ **Alertas Automáticos**
- Email quando revenue cair
- Email quando DAU cair
- Notificações configuráveis

✅ **Compartilhamento Fácil**
- URL pública do dashboard
- Embed em outros sites
- Export PNG/PDF

✅ **Custo: $0/mês**
- Free tier suficiente
- Upgrade só se precisar

---

## 🤖 Precisa de Ajuda?

Se tiver problemas:

1. **Datasource não conecta**:
   - Verifique URL da API
   - Teste no navegador: https://jamesdev-factory.onrender.com/grafana/health

2. **Dashboard não carrega**:
   - Verifique se backend está no ar
   - Teste endpoint: https://jamesdev-factory.onrender.com/api/metrics/overview

3. **Alertas não funcionam**:
   - Verifique email configurado
   - Teste com threshold baixo

---

**Dashboard pronto em 1-2 dias!** 🚀
