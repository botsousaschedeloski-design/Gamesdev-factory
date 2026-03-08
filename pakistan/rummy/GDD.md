# 🂮 Rummy Pakistan - Game Design Document

**Rummy Offline (Single Player vs AI)**

---

## 🎯 Visão Geral

| Item | Descrição |
|------|-----------|
| **Gênero** | Card Game (Rummy) |
| **Modo** | Single Player vs AI |
| **Offline** | ✅ 100% offline |
| **Engine** | Unity (C#) |
| **Desenvolvimento** | 2 dias |
| **Reuse** | 80% (novas regras) |

---

## 🎮 Gameplay

### **Rummy 13 Cards:**
```
- 13 cartas por jogador
- Formar sets e sequences
- Pure sequence obrigatória
- Points system
```

### **Features:**
```
- Single Player vs 3 bots
- 3 dificuldades
- Save local
- Tutorial
```

---

## 📁 Estrutura

```
Assets/
├── Scripts/
│   ├── Rummy/
│   │   ├── RummyGame.cs        ✅ Novo
│   │   ├── RummyHand.cs        ✅ Novo
│   │   ├── CardEvaluator.cs    ✅ Adaptar
│   │   └── RummyAI.cs          ✅ Novo
│   └── Core/
│       └── SaveManager.cs      ✅ Reuse
└── Prefabs/
    └── Card.prefab             ✅ Reuse
```

---

## 🚀 Código (2 dias)

**Dia 1:**
- ✅ RummyGame.cs
- ✅ RummyHand.cs
- ✅ CardEvaluator

**Dia 2:**
- ✅ RummyAI.cs
- ✅ UI
- ✅ Tutorial
- ✅ Build APK

---

**Status**: ⏳ A codar
