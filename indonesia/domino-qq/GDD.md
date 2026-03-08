# 🀄 Domino QQ Offline - Game Design Document

**Jogo Offline (Single Player vs AI)**

---

## 🎯 Visão Geral

| Item | Descrição |
|------|-----------|
| **Gênero** | Domino / Puzzle |
| **Modo** | Single Player (vs AI) |
| **Offline** | ✅ 100% offline |
| **Plataforma** | Android, iOS |
| **Engine** | Unity (C#) |
| **Desenvolvimento** | 2 dias |
| **Reuse** | 70% (Carrom 3D base) |

---

## 🎮 Gameplay

### **Modo Single Player:**

```
1. Jogador vs 3 Bots (AI)
2. Turnos automáticos
3. AI com dificuldade ajustável
4. Sem necessidade de internet
```

### **Regras Domino QQ:**

```
- 28 peças de dominó
- 4 jogadores (1 humano + 3 bots)
- Objetivo: baixar todas as peças primeiro
- Pontuação baseada nas peças restantes
```

---

## 🏗️ Arquitetura (Offline)

```
┌─────────────────────────────────┐
│         Unity Client            │
├─────────────────────────────────┤
│  GameManager (Local)            │
│  AI Controller (Local)          │
│  Save System (Local)            │
│  AdMob (Optional)               │
└─────────────────────────────────┘
```

**Sem servidor, sem backend!**

---

## 📁 Estrutura de Arquivos

```
Assets/
├── Scripts/
│   ├── Domino/
│   │   ├── DominoPiece.cs      ✅ Peça de dominó
│   │   ├── DominoBoard.cs      ✅ Tabuleiro
│   │   ├── DominoGame.cs       ✅ Lógica do jogo
│   │   ├── DominoAI.cs         ✅ AI dos bots
│   │   └── DominoUI.cs         ✅ Interface
│   ├── Core/
│   │   ├── GameManager.cs      ✅ Gerenciador
│   │   ├── SaveManager.cs      ✅ Save local
│   │   └── AudioManager.cs     ✅ Áudio
│   └── Ads/
│       └── AdMobManager.cs     ✅ Ads (opcional)
├── Prefabs/
│   ├── DominoPiece.prefab
│   ├── BoardTile.prefab
│   └── PlayerSeat.prefab
├── Scenes/
│   ├── MainMenu.unity
│   ├── Game.unity
│   └── Settings.unity
└── Assets/
    ├── Sprites/
    ├── Audio/
    └── Fonts/
```

---

## 🎨 Features

### **Offline:**
- ✅ Single Player vs AI
- ✅ 3 níveis de dificuldade (Fácil, Médio, Difícil)
- ✅ Save local (progresso)
- ✅ Estatísticas locais
- ✅ Sem internet necessária

### **Monetização (Opcional):**
- ✅ AdMob (Reward Video - continues)
- ✅ AdMob (Interstitial - entre jogos)
- ✅ IAP ( remover ads )

### **UI/UX:**
- ✅ Menu principal simples
- ✅ Seleção de dificuldade
- ✅ Tabuleiro claro
- ✅ Peças fáceis de arrastar
- ✅ Feedback visual

---

## 🤖 AI System

### **Níveis de Dificuldade:**

| Nível | IA | Taxa de Vitória Player |
|-------|----|------------------------|
| **Fácil** | Jogadas aleatórias | 80% |
| **Médio** | Jogadas básicas | 50% |
| **Difícil** | Estratégia avançada | 30% |

### **AI Comportamento:**

```csharp
// Fácil: Joga qualquer peça válida
// Médio: Tenta baixar peças altas primeiro
// Difícil: Bloqueia jogador, conta peças
```

---

## 💾 Save System (Local)

### **Dados Salvos:**

```json
{
  "playerStats": {
    "gamesPlayed": 0,
    "gamesWon": 0,
    "winStreak": 0,
    "highScore": 0
  },
  "settings": {
    "difficulty": "medium",
    "soundEnabled": true,
    "musicEnabled": true
  },
  "progress": {
    "tutorialComplete": false,
    "achievements": []
  }
}
```

**Salvo em:** `PlayerPrefs` ou `JSON local`

---

## 📊 Progresso de Desenvolvimento

### **Dia 1: Core Gameplay**

- [ ] DominoPiece.cs
- [ ] DominoBoard.cs
- [ ] DominoGame.cs
- [ ] Tabuleiro funcional
- [ ] Peças arrastáveis

### **Dia 2: AI + Polish**

- [ ] DominoAI.cs (3 níveis)
- [ ] SaveSystem.cs
- [ ] UI completa
- [ ] Áudio/SFX
- [ ] Build APK

---

## 🎯 Código Base (Começar Agora)

### **DominoPiece.cs:**

```csharp
using UnityEngine;

public class DominoPiece : MonoBehaviour
{
    public int topValue;
    public int bottomValue;
    public bool isDouble;
    
    // Visual
    public Sprite[] pieceSprites;
    
    void OnMouseDown()
    {
        // Drag piece
    }
}
```

### **DominoGame.cs:**

```csharp
using UnityEngine;
using System.Collections.Generic;

public class DominoGame : MonoBehaviour
{
    public List<DominoPiece> playerHand;
    public List<DominoPiece> botHands;
    public DominoPiece[] board;
    
    public void StartGame()
    {
        // Setup game
    }
    
    public void PlayPiece(DominoPiece piece)
    {
        // Play piece on board
    }
}
```

---

## 🚀 Próximos Passos

1. ✅ Criar estrutura de pastas
2. ✅ Implementar DominoPiece.cs
3. ✅ Implementar DominoBoard.cs
4. ✅ Implementar DominoGame.cs
5. ✅ Implementar DominoAI.cs
6. ✅ UI + Save
7. ✅ Build APK

---

**Tempo estimado: 2 dias**  
**Complexidade: Baixa**  
**Reuse: 70% (Carrom 3D)**
