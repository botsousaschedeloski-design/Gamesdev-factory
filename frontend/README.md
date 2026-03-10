# 📊 GamesDev Factory - Frontend Dashboard

**Dashboard Admin em React/HTML**

---

## 🚀 DEPLOY NA VERCEL (Recomendado):

### **Passo 1: Instalar Vercel CLI**
```bash
npm install -g vercel
```

### **Passo 2: Deploy**
```bash
cd frontend
vercel --prod
```

### **Passo 3: URL do Dashboard**
```
https://gamesdev-factory-dashboard.vercel.app
```

---

## 📊 O QUE TEM NO DASHBOARD:

### **1. Overview Cards:**
```
📥 Downloads Totais
👥 Acessos Diários
💰 Receita Total
🎮 Jogos Ativos (15/15)
```

### **2. Gráficos:**
```
📊 Acessos Diários (últimos 7 dias)
💰 Receita por Região (pie chart)
```

### **3. Tabela de Jogos:**
```
- Nome do jogo
- Região
- Downloads
- Acessos
- Receita
- Status
```

---

## 🎨 TECNOLOGIAS:

```
✅ TailwindCSS (UI)
✅ Chart.js (Gráficos)
✅ HTML/JS (Simples e rápido)
```

---

## 📁 ESTRUTURA:

```
frontend/
└── public/
    └── index.html    (Dashboard completo)
```

---

## 🚀 DEPLOY OPTIONS:

### **Opção 1: Vercel (Recomendado)**
```bash
cd frontend
vercel --prod
```

### **Opção 2: GitHub Pages**
```bash
# Habilitar GitHub Pages no repo
# Settings → Pages → Source: main branch
# URL: https://botsousaschedeloski-design.github.io/Gamesdev-factory/
```

### **Opção 3: Netlify**
```bash
# Arraste a pasta frontend para netlify.com
# Deploy automático
```

---

## 📊 DADOS MOCK (Atualmente):

O dashboard está usando **dados mock** (fictícios).

**Para conectar com API real:**

1. Substituir `mockData` por chamadas de API
2. Backend: `https://api.gamesdev-factory.com`
3. Endpoints: `/api/dashboard/overview`, `/api/dashboard/games`, etc.

---

## 🎯 PRÓXIMOS PASSOS:

### **1. Deploy na Vercel:**
```bash
cd frontend
vercel --prod
```

### **2. Conectar com API:**
```javascript
// Substituir mockData por:
const response = await fetch('https://api.gamesdev-factory.com/dashboard/overview');
const data = await response.json();
```

### **3. Backend Real:**
```
- Deploy backend (Railway/Render)
- Banco de dados (Supabase/MongoDB)
- API endpoints reais
```

---

**Dashboard pronto para deploy!** 🚀
