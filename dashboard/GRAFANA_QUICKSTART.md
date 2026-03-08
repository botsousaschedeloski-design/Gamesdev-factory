# 🎯 Setup do Grafana - Guia Rápido (15 minutos)

**Siga estes passos EXATAMENTE na ordem!**

---

## ⏱️ Tempo Total: 15-20 minutos

---

## 📋 PASSO 1: Criar Conta (5 minutos)

### 1.1 Acesse:
```
🔗 https://grafana.com/auth/sign-up/create-user
```

### 1.2 Preencha:
```
Email:        botsousaschedeloski@gmail.com
Username:     gamesdev-factory
Password:     [Crie uma senha forte]
First Name:   Afonso
Last Name:    Sousa
```

### 1.3 Click:
```
[Create account]
```

### 1.4 Verifique Email:
```
1. Abra seu email (botsousaschedeloski@gmail.com)
2. Procure email do Grafana
3. Click no link de confirmação
```

### 1.5 Login:
```
1. Volte em https://grafana.com
2. Click "Sign in"
3. Login com email/senha
```

---

## 📋 PASSO 2: Acessar Grafana Cloud (2 minutos)

### 2.1 No Dashboard:
```
1. Click "Grafana Cloud" (canto superior direito)
2. OU acesse: https://grafana.net
```

### 2.2 Selecione Organização:
```
Nome: gamesdev-factory
Region: US (padrão)
```

### 2.3 Click:
```
[Launch Grafana]
```

---

## 📋 PASSO 3: Instalar SimpleJSON Plugin (3 minutos)

### 3.1 No Menu Lateral:
```
1. Click "Connections" (ícone de plugue)
2. Click "Add new connection"
```

### 3.2 Search:
```
Digite: SimpleJSON
```

### 3.3 Click:
```
[Install]
```

### 3.4 Aguarde:
```
✅ "Plugin installed successfully"
```

---

## 📋 PASSO 4: Configurar Datasource (5 minutos)

### 4.1 Adicionar Datasource:
```
1. Connections → Data sources
2. Click "+ Add data source"
3. Select: "SimpleJSON"
```

### 4.2 Configurar:
```
Name:         GamesDev API
URL:          https://jamesdev-factory.onrender.com/grafana
```

### 4.3 Click:
```
[Save & Test]
```

### 4.4 Verifique:
```
✅ "Data source is working"
```

**Se der erro:**
- Verifique se URL está correta
- Teste no navegador: https://jamesdev-factory.onrender.com/grafana/health
- Deve aparecer: {"status":"ok",...}

---

## 📋 PASSO 5: Importar Dashboard (5 minutos)

### 5.1 Baixar JSON:
```
1. Acesse: https://github.com/botsousaschedeloski-design/Gamesdev-factory/blob/main/dashboard/grafana-dashboard.json
2. Click "Raw" (botão no topo direito)
3. Ctrl+S (ou Cmd+S) para salvar
4. Salve como: grafana-dashboard.json
```

### 5.2 Importar no Grafana:
```
1. Click "Dashboards" (menu lateral)
2. Click "Import dashboard"
3. Click "Upload dashboard JSON"
4. Selecione o arquivo: grafana-dashboard.json
5. Click "Upload"
```

### 5.3 Selecionar Datasource:
```
1. Em "GamesDev API", select: "GamesDev API"
2. Click "Import"
```

### 5.4 Dashboard Pronto!
```
✅ Dashboard carregado com:
   - 4 stat panels
   - 2 time series charts
   - 1 table
```

---

## 📋 PASSO 6: Verificar Dados (2 minutos)

### 6.1 Verifique Panels:
```
✅ Downloads Today: [número]
✅ Revenue Today: $[valor]
✅ Daily Active Users: [número]
✅ ARPDAU: $[valor]
```

### 6.2 Se aparecer "No data":
```
1. Click no panel
2. Click "Edit"
3. Verifique query: target = "downloads" (ou revenue, dau, etc)
4. Click "Run query"
5. Click "Save"
```

### 6.3 Refresh Automático:
```
1. Top right: Click "1h"
2. Select: "1m" (auto-refresh a cada 1 minuto)
```

---

## 📋 PASSO 7: Configurar Alertas (Opcional, 5 minutos)

### 7.1 Criar Alerta de Revenue:
```
1. Click "Alerting" (menu lateral)
2. Click "New alert rule"
3. Select metric: "revenue"
4. Condition: "Is below" → 100
5. Evaluate every: "1h"
6. Pending for: "5m"
7. Click "Next"
8. Add notification: Email → botsousaschedeloski@gmail.com
9. Click "Save rule"
```

### 7.2 Criar Alerta de DAU:
```
1. New alert rule
2. Select metric: "dau"
3. Condition: "Is below" → 1000
4. Evaluate every: "1h"
5. Pending for: "10m"
6. Add notification: Email
7. Save rule
```

---

## ✅ CHECKLIST FINAL

Marque cada item conforme completar:

- [ ] **Conta Grafana criada**
- [ ] **Email confirmado**
- [ ] **Login feito**
- [ ] **SimpleJSON instalado**
- [ ] **Datasource configurado**
- [ ] **Dashboard importado**
- [ ] **Dados aparecendo**
- [ ] **Auto-refresh configurado (1m)**
- [ ] **Alertas configurados (opcional)**

---

## 🎨 RESULTADO FINAL

Após completar todos os passos, você terá:

```
┌──────────────────────────────────────────────────┐
│  🎮 GamesDev Factory Dashboard      [🔔] [⚙️]  │
├──────────────────────────────────────────────────┤
│                                                  │
│  📥 Downloads    💰 Revenue    👥 DAU  📊 ARPDAU│
│   12,450 ▲15%   $1,234 ▲22%  8,450▲8% $0.06▲5%│
│                                                  │
├──────────────────────────────────────────────────┤
│  📈 Revenue (7 Days)   │  👥 Users (7 Days)     │
│  [Gráfico sobe/desce]  │  [Gráfico sobe/desce]  │
│                                                  │
├──────────────────────────────────────────────────┤
│  🌍 Performance por Mercado                      │
│  Índia      │ $456  │ 3,450 ↓ │ 45% │ ✅       │
│  Indonésia  │ $312  │ 2,890 ↓ │ 42% │ ⏳       │
└──────────────────────────────────────────────────┘
```

---

## 🔗 URLs Importantes

| Recurso | URL |
|---------|-----|
| **Seu Dashboard** | https://gamesdev-factory.grafana.net |
| **API Backend** | https://jamesdev-factory.onrender.com/grafana/health |
| **Setup Guide** | https://github.com/botsousaschedeloski-design/Gamesdev-factory/blob/main/dashboard/GRAFANA_SETUP.md |

---

## 🆘 Problemas Comuns

### "Data source is not working"
```
Solução:
1. Verifique URL: https://jamesdev-factory.onrender.com/grafana
2. Teste no navegador: https://jamesdev-factory.onrender.com/grafana/health
3. Se aparecer erro, backend pode estar off
4. Aguarde 2-3 minutos e tente novamente
```

### "No data" nos panels
```
Solução:
1. Click no panel → Edit
2. Verifique query (target: "downloads", "revenue", etc)
3. Click "Run query"
4. Click "Save"
```

### Dashboard não carrega
```
Solução:
1. Refresh da página (F5)
2. Logout e login novamente
3. Verifique se datasource está selecionado
```

---

## 📞 Precisa de Ajuda?

Se travou em algum passo:

1. **Me avise qual passo**
2. **Me mande screenshot do erro**
3. **Eu ajudo a resolver!**

---

**Tempo estimado: 15-20 minutos**  
**Custo: $0**  
**Resultado: Dashboard profissional!** 🚀

**BOA SORTE! 🎯**
