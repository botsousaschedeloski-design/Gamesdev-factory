# 🃏 Teen Patti Cricket - Game Design Document

**Teen Patti com Tema de Cricket**

---

## 🎯 Visão Geral

| Item | Descrição |
|------|-----------|
| **Gênero** | Card Game |
| **Modo** | Single Player vs AI |
| **Offline** | ✅ 100% offline |
| **Tema** | Cricket + Teen Patti |
| **Engine** | Unity (C#) |
| **Desenvolvimento** | 1 dia |
| **Reuse** | 85% (Teen Patti Índia) |

---

## 🎮 Gameplay

### **Base:**
```
- Mesmas regras Teen Patti
- Cartas com tema cricket
- Bots com nomes de jogadores
- Torneios PSL
```

### **Features:**
```
- Cards com jogadores de cricket
- Stadiums como backgrounds
- Commentary durante jogo
- PSL Tournament mode
```

---

## 📁 Estrutura (85% Reuse)

```
Assets/
├── Scripts/
│   └── TeenPatti/
│       ├── TeenPattiGame.cs    ✅ Reuse Índia
│       ├── CardEvaluator.cs    ✅ Reuse Índia
│       └── AI.cs               ✅ Reuse Índia
├── Sprites/
│   └── cricket-cards/          ✅ Novo tema
└── Audio/
    └── commentary/             ✅ Commentary cricket
```

---

## 🚀 Código (1 dia)

**Apenas trocar assets:**
- ✅ Cards (tema cricket)
- ✅ Backgrounds (stadiums)
- ✅ Audio (commentary)
- ✅ UI (cores PSL)

---

**Status**: ⏳ A codar
