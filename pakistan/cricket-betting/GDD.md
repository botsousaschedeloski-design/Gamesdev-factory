# 🏏 Cricket Betting Sim - Game Design Document

**Jogo Offline (Single Player)**

---

## 🎯 Visão Geral

| Item | Descrição |
|------|-----------|
| **Gênero** | Sports Simulation |
| **Modo** | Single Player |
| **Offline** | ✅ 100% offline |
| **Tema** | Cricket (PSL, World Cup) |
| **Plataforma** | Android, iOS |
| **Engine** | Unity (C#) |
| **Desenvolvimento** | 2 dias |
| **Reuse** | 80% (novas mecânicas) |

---

## 🎮 Gameplay

### **Simulador de Apostas:**
```
- Aposte em partidas de cricket
- PSL, World Cup, T20
- Odds dinâmicas
- Gerencie bankroll
```

### **Features:**
```
- Times reais (PSL, Internacional)
- Jogadores famosos
- Estatísticas em tempo real
- Career mode
```

---

## 📁 Estrutura

```
Assets/
├── Scripts/
│   ├── Cricket/
│   │   ├── CricketMatch.cs     ✅ Novo
│   │   ├── BettingSystem.cs    ✅ Novo
│   │   ├── TeamManager.cs      ✅ Novo
│   │   └── CareerMode.cs       ✅ Novo
│   └── Core/
│       └── GameManager.cs      ✅ Reuse
└── Data/
    └── teams.json              ✅ Times/países
```

---

## 🚀 Código (2 dias)

**Dia 1:**
- ✅ CricketMatch.cs
- ✅ BettingSystem.cs
- ✅ TeamManager.cs

**Dia 2:**
- ✅ CareerMode.cs
- ✅ UI
- ✅ Data (times, jogadores)
- ✅ Build APK

---

**Status**: ⏳ A codar
