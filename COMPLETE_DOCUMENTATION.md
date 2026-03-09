# 📚 Documentação Completa - Passo a Passo

**Guia Visual com Screenshots**

---

## 🎯 QUANDO TIVER ACESSO:

### **Passo 1: Abrir Terminal (2 min)**

```
Mac:
1. Pressione: Cmd + Space
2. Digite: Terminal
3. Enter

Windows:
1. Pressione: Win + X
2. Selecione: Terminal ou PowerShell
```

---

### **Passo 2: Rodar Script (5 min)**

```bash
# 1. Navegue até pasta
cd /Users/botss/.openclaw/workspace/projetos/gamesdev-factory/scripts

# 2. Dê permissão
chmod +x *.sh

# 3. Rode o script principal
./RUN_ME_FIRST.sh

# 4. Aguarde (4-5 horas automático)
```

**O Que Acontece:**
```
📦 Assets download (30 min)
🎮 Unity builds (3h)
📱 Upload stores (1h)
💰 AdMob setup (30 min)
```

---

### **Passo 3: Criar Contas (1h)**

#### **Google Play Console:**
```
1. Acesse: https://play.google.com/console
2. Click: "Create account"
3. Preencha dados
4. Pague $25 (cartão)
5. ✅ Conta criada!

TEMPO: 30 min
CUSTO: $25
```

#### **AdMob:**
```
1. Acesse: https://admob.google.com
2. Click: "Get Started"
3. Login Google
4. Preencha dados
5. ✅ Conta criada!

TEMPO: 30 min
CUSTO: $0
```

---

### **Passo 4: Aguardar Reviews (7 dias)**

```
Google Play: 2-7 dias
Amazon: 1-3 dias
Samsung: 2-5 dias
Huawei: 3-7 dias
itch.io: Instant! ✅
GitHub: Instant! ✅
```

---

### **Passo 5: Publish! (1h)**

```
1. Todos aprovados → Publish
2. Monitorar downloads
3. Responder reviews
4. ✅ NO AR!
```

---

## 📊 FLUXO COMPLETO:

```
┌─────────────────────────────────────────┐
│  1. ./RUN_ME_FIRST.sh (5 min)          │
│     ↓                                   │
│  2. Scripts rodam (4-5h auto)          │
│     ↓                                   │
│  3. Criar contas (1h manual)           │
│     Google Play ($25) + AdMob (free)   │
│     ↓                                   │
│  4. Aguardar reviews (7 dias)          │
│     ↓                                   │
│  5. Publish! (1h)                       │
│     ↓                                   │
│  ✅ 15 JOGOS NO AR!                     │
└─────────────────────────────────────────┘
```

---

## 🎨 ASSETS (Se Quiser Fazer Manual):

### **Canva (30 min):**

```
1. Acesse: https://www.canva.com
2. Sign up (free)
3. Search: "Gaming logo"
4. Customize cores por país
5. Download: PNG 512x512
6. Repetir 15x

OU

Use assets SVG prontos (ASSETS_SVG_PACK.md)
```

---

## 🆘 PROBLEMAS COMUNS:

### **Erro: "Unity not found"**
```
Solução:
1. Verifique caminho do Unity
2. Edite script: 02-unity-builds.sh
3. Atualize UNITY_PATH
```

### **Erro: "Permission denied"**
```
Solução:
chmod +x *.sh
```

### **Erro: "Build failed"**
```
Solução:
1. Verifique log: Builds/[game]-build.log
2. Unity precisa de Android Build Support
3. Instale via Unity Hub
```

---

## 📞 SUPORTE:

### **Links Úteis:**
```
✅ Unity Install: https://unity.com/download
✅ Android SDK: https://developer.android.com/studio
✅ Google Play: https://play.google.com/console
✅ AdMob: https://admob.google.com
```

### **Documentação:**
```
✅ ASSETS_SVG_PACK.md - Ícones SVG
✅ scripts/RUN_ME_FIRST.md - Scripts
✅ CANVA_QUICK_START.md - Assets Canva
✅ MULTI_STORE_DEPLOYMENT.md - 6 lojas
```

---

## ✅ CHECKLIST FINAL:

```
[ ] 1. Terminal aberto
[ ] 2. ./RUN_ME_FIRST.sh rodando
[ ] 3. Scripts completaram (4-5h)
[ ] 4. Google Play conta criada ($25)
[ ] 5. AdMob conta criada (free)
[ ] 6. Reviews aprovados (7 dias)
[ ] 7. Publish!
[ ] 8. ✅ NO AR!
```

---

**Documentação completa!** 📚
