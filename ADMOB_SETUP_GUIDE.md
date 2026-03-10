# 📋 Guia para Criar Apps no AdMob

**Preencha o arquivo `admob-app-ids.csv` com os IDs**

---

## 🚀 PASSO A PASSO:

### **1. Acesse AdMob:**
```
https://admob.google.com
```

### **2. Para CADA um dos 15 jogos:**

#### **Passo A: Criar App**
```
1. Menu lateral: Apps
2. Click: "Adicionar app"
3. Preencha:
   - Nome do app: Teen Patti
   - Plataforma: Android
   - Package name: com.afonso.fxtrade.teenpatti
   - Link do app: (deixe em branco por enquanto)
4. Click: "Adicionar app"
```

#### **Passo B: Anotar App ID**
```
Após criar, você verá:
"ID do app: ca-app-pub-1234567890~abcdefgh"

ANOTE ESTE ID!
```

#### **Passo C: Criar Ad Units**
```
Para cada app, crie 3 ad units:

1. Banner Ad Unit
   - Nome: TeenPatti_Banner
   - Tipo: Banner
   - Anote o ID

2. Interstitial Ad Unit
   - Nome: TeenPatti_Interstitial
   - Tipo: Interstitial
   - Anote o ID

3. Rewarded Ad Unit
   - Nome: TeenPatti_Rewarded
   - Tipo: Rewarded
   - Anote o ID
```

#### **Passo D: Preencher CSV**
```
Abra o arquivo admob-app-ids.csv e preencha:

Jogo: Teen Patti
Package Name: com.afonso.fxtrade.teenpatti
App ID: ca-app-pub-1234567890~abcdefgh
Ad Unit Banner: ca-app-pub-1234567890/12345678
Ad Unit Interstitial: ca-app-pub-1234567890/87654321
Ad Unit Rewarded: ca-app-pub-1234567890/11223344
Status: ✅ Criado
```

---

## 📋 LISTA DOS 15 JOGOS:

### **Índia (3 jogos):**
```
1. Teen Patti
   Package: com.afonso.fxtrade.teenpatti

2. Slot Machine
   Package: com.afonso.fxtrade.slotmachine

3. Carrom 3D
   Package: com.afonso.fxtrade.carrom3d
```

### **Indonésia (3 jogos):**
```
4. Domino QQ
   Package: com.afonso.fxtrade.dominoqq

5. Slot Wayang
   Package: com.afonso.fxtrade.slotwayang

6. Capsa Offline
   Package: com.afonso.fxtrade.capsaoffline
```

### **Paquistão (3 jogos):**
```
7. Cricket Betting
   Package: com.afonso.fxtrade.cricketbetting

8. Teen Patti Cricket
   Package: com.afonso.fxtrade.teenpatticricket

9. Rummy
   Package: com.afonso.fxtrade.rummy
```

### **Bangladesh (3 jogos):**
```
10. Teen Patti Bangladesh
    Package: com.afonso.fxtrade.teenpattibd

11. Cricket Quiz
    Package: com.afonso.fxtrade.cricketquiz

12. Ludo Bangladesh
    Package: com.afonso.fxtrade.ludobd
```

### **Nigéria (3 jogos):**
```
13. Football Quiz
    Package: com.afonso.fxtrade.footballquiz

14. Afro Slots
    Package: com.afonso.fxtrade.afroslots

15. Ayo Board
    Package: com.afonso.fxtrade.ayoboard
```

---

## 📝 EXEMPLO DE PREENCHIMENTO:

```
Jogo,Package Name,App ID,Ad Unit Banner,Ad Unit Interstitial,Ad Unit Rewarded,Status,Notas
Teen Patti,com.afonso.fxtrade.teenpatti,ca-app-pub-1234567890~abcdefgh,ca-app-pub-1234567890/12345678,ca-app-pub-1234567890/87654321,ca-app-pub-1234567890/11223344,✅ Criado,Primeiro app criado
Slot Machine,com.afonso.fxtrade.slotmachine,,,,,,,,⏳ Aguardando,
```

---

## ✅ APÓS CRIAR TODOS:

### **O Que Fazer:**
```
1. Me envie o arquivo CSV preenchido
2. Eu atualizo o código de cada jogo
3. Faço build dos APKs
4. Upload para Google Play
```

### **Tempo Estimado:**
```
Criar 15 apps: 15-20 minutos
Criar 45 ad units: 15 minutos
Preencher CSV: 5 minutos
TOTAL: 35-40 minutos
```

---

## 🔗 LINKS ÚTEIS:

```
AdMob: https://admob.google.com
Google Play: https://play.google.com/console
CSV Template: admob-app-ids.csv (na pasta do projeto)
```

---

## 📞 SE TIVER DÚVIDAS:

```
- "Como criar app no AdMob?"
- "Onde acho o App ID?"
- "Como criar ad unit?"
```

**Me avise que eu te ajudo!** 📱

---

**Bora criar esses apps!** 🚀
