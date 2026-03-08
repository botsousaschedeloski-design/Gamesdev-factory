# 🎰 Slot Wayang - Game Design Document

**Jogo Offline (Single Player)**

---

## 🎯 Visão Geral

| Item | Descrição |
|------|-----------|
| **Gênero** | Slot Machine |
| **Modo** | Single Player |
| **Offline** | ✅ 100% offline |
| **Tema** | Wayang Kulit (Marionetes Indonésias) |
| **Plataforma** | Android, iOS |
| **Engine** | Unity (C#) |
| **Desenvolvimento** | 1 dia |
| **Reuse** | 90% (Slot Machine Índia) |

---

## 🎮 Gameplay

### **Base Game:**
```
- 5 reels, 20 paylines
- Símbolos: Personagens Wayang
- Wild: Gunungan
- Scatter: Kelir (Tela Wayang)
- Free Spins: 3+ Scatters
```

### **Bonus Features:**
```
- Wayang Bonus Game (escolha personagens)
- Multiplier durante free spins
- Gamble feature (dobrar ganhos)
```

---

## 📁 Estrutura (Reuse 90%)

```
Assets/
├── Scripts/
│   ├── Slot/
│   │   ├── SlotMachine.cs      ✅ Reuse Índia
│   │   ├── ReelController.cs   ✅ Reuse Índia
│   │   ├── PaylineChecker.cs   ✅ Reuse Índia
│   │   └── WinCalculator.cs    ✅ Reuse Índia
│   └── Theme/
│       └── WayangTheme.cs      ✅ Novo (tema)
├── Sprites/
│   ├── wayang-symbols/
│   └── backgrounds/
└── Audio/
    └── gamelan-music/
```

---

## 🎨 Símbolos

| Símbolo | Tipo | Valor (5x) |
|---------|------|------------|
| **Gunungan** | Wild | 500x |
| **Pandawa 5** | High | 200x |
| **Kurawa** | High | 150x |
| **Wayang Hero** | Mid | 100x |
| **Wayang Villain** | Mid | 75x |
| **Gamelan** | Low | 50x |
| **Keris** | Low | 25x |

---

## 🚀 Código (Pronto em 1 dia)

**Dia 1:**
- ✅ Reuse Slot Machine (90%)
- ✅ Adicionar tema Wayang
- ✅ Bonus game
- ✅ Audio/SFX
- ✅ Build APK

---

**Status**: ⏳ A codar
