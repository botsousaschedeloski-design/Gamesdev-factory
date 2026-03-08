# 📊 Sistema de Dados - Guia Rápido

**Como atualizar os dados do dashboard**

---

## 🎯 Como Funciona:

```
1. Você edita: dados/metrics.json
2. Faz commit/push no GitHub
3. Dashboard atualiza automático (5 min)
```

---

## 📝 Passo a Passo:

### Opção 1: Editar no GitHub (Mais Fácil)

```
1. Acesse: https://github.com/botsousaschedeloski-design/Gamesdev-factory/blob/main/dados/metrics.json
2. Click: ✏️ (Edit)
3. Edite os valores
4. Click: "Commit changes"
5. Pronto! Dashboard atualiza em 5 min
```

### Opção 2: Editar Local e Push

```
1. Edite: dados/metrics.json
2. git add dados/metrics.json
3. git commit -m "Update metrics"
4. git push
5. Pronto!
```

---

## 📊 Estrutura do JSON:

```json
{
  "lastUpdate": "2026-03-08T18:00:00Z",
  "metrics": {
    "downloadsToday": 12450,
    "revenueToday": 1234,
    "dau": 8450,
    "arpdau": 0.06
  },
  "markets": [...],
  "games": [...]
}
```

---

## ✏️ O Que Editar:

### Metrics (Geral):
```json
"downloadsToday": 12450,  // Downloads de hoje
"revenueToday": 1234,     // Revenue de hoje ($)
"dau": 8450,              // Usuários ativos hoje
"arpdau": 0.06            // Revenue por usuário
```

### Markets (Por País):
```json
{
  "name": "Índia",
  "flag": "🇮🇳",
  "revenue": 456,         // Revenue do país
  "downloads": 3450,      // Downloads do país
  "retentionD1": 45,      // Retention dia 1 (%)
  "status": "live"        // live, dev, planned
}
```

### Games (Por Jogo):
```json
{
  "name": "Teen Patti",
  "market": "Índia",
  "status": "live",       // live, dev, planned
  "players": 1234,        // Players ativos
  "revenue": 300          // Revenue do jogo
}
```

---

## 🔄 Atualização Automática:

```
- Dashboard atualiza sozinho a cada 5 minutos
- Ou click em "🔄 Atualizar" para refresh manual
```

---

## 📱 Acessar Dashboard:

```
URL: https://botsousaschedeloski-design.github.io/Gamesdev-factory/dashboard-auto/
Código: Alv170623
```

---

## ✏️ Template para Copiar:

```json
{
  "lastUpdate": "2026-03-08T18:00:00Z",
  "metrics": {
    "downloadsToday": 0,
    "revenueToday": 0,
    "dau": 0,
    "arpdau": 0.00
  },
  "markets": [
    {
      "name": "Índia",
      "flag": "🇮🇳",
      "revenue": 0,
      "downloads": 0,
      "retentionD1": 0,
      "status": "live"
    }
  ],
  "games": [
    {
      "name": "Teen Patti",
      "market": "Índia",
      "status": "live",
      "players": 0,
      "revenue": 0
    }
  ]
}
```

---

## 🎯 Resumo:

| Ação | Como Fazer |
|------|------------|
| **Atualizar dados** | Edite metrics.json |
| **Commit** | GitHub UI ou git push |
| **Dashboard atualiza** | Automático (5 min) |
| **Acessar** | URL + código Alv170623 |

---

**Sistema proprietário simples e direto!** 🚀
