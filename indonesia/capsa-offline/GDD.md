# 🃏 Capsa Offline - Game Design Document

**Jogo de Cartas Indonésio (Single Player vs AI)**

---

## 🎯 Visão Geral

| Item | Descrição |
|------|-----------|
| **Gênero** | Card Game |
| **Modo** | Single Player vs AI |
| **Offline** | ✅ 100% offline |
| **Plataforma** | Android, iOS |
| **Engine** | Unity (C#) |
| **Desenvolvimento** | 2 dias |
| **Reuse** | 75% (Teen Patti base) |

---

## 🎮 Gameplay

### **Capsa (Chinese Poker):**
```
- 13 cartas por jogador
- 3 mãos: Front (3), Middle (5), Back (5)
- Back > Middle > Front
- Compara com oponentes
```

### **Regras:**
```
- Back hand: 5 cartas (maior)
- Middle hand: 5 cartas (média)
- Front hand: 3 cartas (menor)
- Back > Middle > Front
```

---

## 📁 Estrutura (Reuse 75%)

```
Assets/
├── Scripts/
│   ├── Capsa/
│   │   ├── CapsaGame.cs        ✅ Novo
│   │   ├── CapsaHand.cs        ✅ Novo
│   │   ├── CapsaAI.cs          ✅ Reuse Teen Patti AI
│   │   └── CardEvaluator.cs    ✅ Reuse Teen Patti
│   └── Core/
│       └── GameManager.cs      ✅ Reuse
└── Prefabs/
    └── Card.prefab             ✅ Reuse
```

---

## 🚀 Código (2 dias)

**Dia 1:**
- ✅ CapsaGame.cs
- ✅ CapsaHand.cs
- ✅ CardEvaluator (adaptar)

**Dia 2:**
- ✅ CapsaAI.cs
- ✅ UI
- ✅ Save System
- ✅ Build APK

---

**Status**: ⏳ A codar
