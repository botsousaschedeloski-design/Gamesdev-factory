# 🎮 Unity Setup Guide - Todos 15 Jogos

**Tempo Total: 10-15 horas (todos 15 jogos)**

---

## 📋 Pré-Requisitos:

### **Software Necessário:**
```
✅ Unity Hub (baixar: https://unity.com/download)
✅ Unity 2022.3 LTS (recomendado)
✅ Android Build Support (módulo)
✅ Visual Studio ou VS Code
```

### **Instalar Unity:**
```
1. Baixe Unity Hub
2. Instale Unity 2022.3 LTS
3. Em Módulos, marque:
   ✅ Android Build Support
   ✅ Android SDK & NDK Tools
   ✅ OpenJDK
```

---

## 📁 Estrutura de Pastas Unity:

### **Para Cada Jogo:**
```
Assets/
├── Scripts/
│   └── [Copiar scripts do jogo]
├── Prefabs/
│   └── [Criar prefabs]
├── Sprites/
│   └── [Assets visuais]
├── Audio/
│   └── [Sons e música]
├── Scenes/
│   ├── MainMenu.unity
│   ├── Game.unity
│   └── Settings.unity
└── Resources/
    └── [Dados e configs]
```

---

## 🎯 JOGO POR JOGO:

---

## 🇮🇳 ÍNDIA (3 Jogos):

### **1. Teen Patti**

**Tipo:** 2D  
**Tempo:** 2-3 horas

#### **Passo 1: Criar Projeto**
```
1. Unity Hub → New Project
2. Select: 2D Core
3. Name: "TeenPatti-India"
4. Create
```

#### **Passo 2: Importar Scripts**
```
Copie para Assets/Scripts/:
- teen-patti/Assets/Scripts/Game/
- teen-patti/Assets/Scripts/Network/
- teen-patti/Assets/Scripts/UI/
- shared/ui/
- shared/ads/
- shared/utils/
```

#### **Passo 3: Criar Prefabs**
```
1. Click direito em Assets/Prefabs/
2. Create → Prefab
3. Nome: "Card"
4. Arraste sprite de carta
5. Adicione componente: CardUI.cs
6. Repita para: Chip, PlayerSeat, Table
```

#### **Passo 4: Configurar Cena**
```
1. File → New Scene → 2D
2. Nome: "GameTable"
3. Arraste prefabs para cena
4. Configure:
   - Canvas (UI)
   - GameManager (empty + GameManager.cs)
   - AudioManager (empty + AudioManager.cs)
5. Salve cena
```

#### **Passo 5: Player Settings**
```
1. File → Build Settings
2. Switch Platform: Android
3. Player Settings:
   - Company Name: "Afonso FXtrade"
   - Package Name: com.afonso.fxtrade.teenpatti
   - Minimum API Level: Android 8.0 (API 26)
   - Scripting Backend: IL2CPP
   - Target Architectures: ARM64 ✅
```

#### **Passo 6: Build APK**
```
1. File → Build Settings
2. Click "Build"
3. Escolha pasta
4. Nome: "TeenPatti-v1.0.apk"
5. Aguarde build (~5-10 min)
```

---

### **2. Slot Machine**

**Tipo:** 2D  
**Tempo:** 2-3 horas

#### **Scripts para Importar:**
```
- slot-machine/Assets/Scripts/Slot/
- slot-machine/Assets/Scripts/UI/
- shared/ads/
- shared/utils/
```

#### **Prefabs:**
```
- Reel (com ReelController.cs)
- Symbol (sprites dos símbolos)
- SpinButton
```

#### **Cena:**
```
1. Crie scene "SlotMachine"
2. Adicione 5 Reels
3. Configure UI (Spin, Bet, Auto)
4. Adicione GameManager
```

#### **Build:**
```
Package Name: com.afonso.fxtrade.slotmachine
```

---

### **3. Carrom 3D**

**Tipo:** 3D  
**Tempo:** 3-4 horas

#### **Scripts para Importar:**
```
- carrom-3d/Assets/Scripts/Physics/
- carrom-3d/Assets/Scripts/Game/
- carrom-3d/Assets/Scripts/AI/
- shared/utils/
```

#### **Prefabs 3D:**
```
1. Board (3D model ou plano)
2. Striker (cilindro)
3. Pieces (cilindros menores)
4. Pockets (esferas)
```

#### **Configurar Física:**
```
1. Adicione Rigidbody nas peças
2. Configure Physics Material (atrito)
3. Teste colisões
```

#### **Build:**
```
Package Name: com.afonso.fxtrade.carrom3d
```

---

## 🇮🇩 INDONÉSIA (3 Jogos):

### **4. Domino QQ**

**Tipo:** 2D  
**Tempo:** 2-3 horas

#### **Scripts:**
```
- indonesia/domino-qq/Scripts/
  - DominoPiece.cs
  - DominoBoard.cs
  - DominoGame.cs
  - DominoAI.cs
  - SaveManager.cs
```

#### **Prefabs:**
```
- DominoPiece (sprite da peça)
- BoardTile (onde peças são jogadas)
- PlayerHand (mão do jogador)
```

#### **Build:**
```
Package Name: com.afonso.fxtrade.dominoqq
```

---

### **5. Slot Wayang**

**Tipo:** 2D  
**Tempo:** 2 horas (90% reuse Slot India)

#### **Scripts:**
```
- indonesia/slot-wayang/Scripts/
  (mesma estrutura do Slot Machine)
```

#### **Diferença:**
```
- Sprites tema Wayang
- Audio gamelan
- Bonus rounds temáticos
```

#### **Build:**
```
Package Name: com.afonso.fxtrade.slotwayang
```

---

### **6. Capsa Offline**

**Tipo:** 2D  
**Tempo:** 2-3 horas

#### **Scripts:**
```
- indonesia/capsa-offline/Scripts/
  - CapsaGame.cs
  - CapsaHand.cs
  - CapsaAI.cs
  - CardDeck.cs
```

#### **Build:**
```
Package Name: com.afonso.fxtrade.capsaoffline
```

---

## 🇵🇰 PAQUISTÃO (3 Jogos):

### **7. Cricket Betting Sim**

**Tipo:** 2D  
**Tempo:** 2-3 horas

#### **Scripts:**
```
- pakistan/cricket-betting/Scripts/
  - CricketMatch.cs
  - BettingSystem.cs
```

#### **Build:**
```
Package Name: com.afonso.fxtrade.cricketbetting
```

---

### **8. Teen Patti Cricket**

**Tipo:** 2D  
**Tempo:** 1-2 horas (85% reuse Teen Patti India)

#### **Scripts:**
```
- Reuse teen-patti/Scripts/
- Adicione tema cricket
```

#### **Build:**
```
Package Name: com.afonso.fxtrade.teenpatticricket
```

---

### **9. Rummy Pakistan**

**Tipo:** 2D  
**Tempo:** 2-3 horas

#### **Scripts:**
```
- pakistan/rummy/Scripts/
  - RummyGame.cs
  - RummyHand.cs
  - RummyAI.cs
```

#### **Build:**
```
Package Name: com.afonso.fxtrade.rummypakistan
```

---

## 🇧🇩 BANGLADESH (3 Jogos):

### **10-12. Bangladesh Games**

**Tempo:** 6-8 horas (todos 3)

#### **Jogos:**
```
- Teen Patti Bangladesh (85% reuse)
- Cricket Quiz (novo)
- Ludo Bangladesh (novo)
```

#### **Build:**
```
com.afonso.fxtrade.teenpattibd
com.afonso.fxtrade.cricketquiz
com.afonso.fxtrade.ludobd
```

---

## 🇳🇬 NIGÉRIA (3 Jogos):

### **13-15. Nigeria Games**

**Tempo:** 6-8 horas (todos 3)

#### **Jogos:**
```
- Football Quiz (novo)
- Afro Slots (90% reuse)
- Ayo Board (novo)
```

#### **Build:**
```
com.afonso.fxtrade.footballquiz
com.afonso.fxtrade.afroslots
com.afonso.fxtrade.ayoboard
```

---

## 📊 CRONOGRAMA SUGERIDO:

### **Dia 1-2: Índia**
```
✅ Teen Patti (3h)
✅ Slot Machine (3h)
✅ Carrom 3D (4h)
Total: 10 horas
```

### **Dia 3-4: Indonésia**
```
✅ Domino QQ (3h)
✅ Slot Wayang (2h)
✅ Capsa Offline (3h)
Total: 8 horas
```

### **Dia 5-6: Paquistão**
```
✅ Cricket Betting (3h)
✅ Teen Patti Cricket (2h)
✅ Rummy Pakistan (3h)
Total: 8 horas
```

### **Dia 7-8: Bangladesh + Nigéria**
```
✅ Bangladesh 3 jogos (8h)
✅ Nigéria 3 jogos (8h)
Total: 16 horas
```

### **Dia 9-10: Revisão + Builds Finais**
```
✅ Testar todos APKs
✅ Ajustes finais
✅ Play Store prep
Total: 10 horas
```

---

## 🎯 CHECKLIST GERAL:

### **Para Cada Jogo:**
```
[ ] Projeto Unity criado
[ ] Scripts importados
[ ] Prefabs criados
[ ] Cena configurada
[ ] Audio/Sprites adicionados
[ ] Player Settings configurados
[ ] Build APK testado
[ ] APK funciona no dispositivo
```

---

## 🚀 COMEÇAR AGORA:

### **Primeiro Jogo (Teen Patti):**

1. **Abra Unity Hub**
2. **New Project → 2D Core**
3. **Nome: "TeenPatti-India"**
4. **Copie scripts** (teen-patti/Assets/Scripts/)
5. **Crie prefabs** (Card, Chip, Table)
6. **Configure cena** (GameManager, UI)
7. **Build APK** (Android settings)

**Tempo: 2-3 horas**

---

## 💡 DICAS IMPORTANTES:

### **1. Organize Pastas:**
```
Mantenha estrutura consistente entre jogos
Facilita reuse de código
```

### **2. Use Prefabs:**
```
Cartas, peças, UI elements
Economiza tempo nos próximos jogos
```

### **3. Teste No Dispositivo:**
```
Sempre teste APK no Android real
Emulator pode dar falsos positivos
```

### **4. Package Names Únicos:**
```
com.afonso.fxtrade.[nomedojogo]
Cada jogo precisa de package name único
```

### **5. Keystore:**
```
Crie keystore para assinar APKs
Mesmo keystore para todos jogos
Guarda em lugar seguro!
```

---

## 🎉 RESULTADO FINAL:

**Após 10 dias:**
```
✅ 15 APKs gerados
✅ Todos testados
✅ Prontos para Play Store
```

---

## 📞 PRECISA DE AJUDA?

**Se travar em algum passo:**
1. Me avise qual jogo
2. Me diga qual passo
3. Mande screenshot do erro

**Eu ajudo a resolver!** 🚀

---

**Comece com Teen Patti AGORA!** 🎮
