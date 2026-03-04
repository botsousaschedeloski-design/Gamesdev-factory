# 🎮 GamesDev Factory - Semana 1: Brasil

**3 Jogos para Lançamento**  
**Data**: 2026-03-04

---

## 📋 Jogos Selecionados

| # | Jogo | Gênero | Complexidade | Reuse | Tempo |
|---|------|--------|--------------|-------|-------|
| 1️⃣ | **Bingo Carnaval** | Bingo | Baixa | 80% | 3-4 dias |
| 2️⃣ | **Tigrinho Slots** | Slots | Baixa | 90% | 2-3 dias |
| 3️⃣ | **Truco Online** | Cards | Média | 70% | 4-5 dias |

---

## 🗓️ Cronograma Detalhado

### Segunda-feira (Pesquisa)

| Hora | Tarefa | Output |
|------|--------|--------|
| 09:00 | Android17: Analisar mercado Brasil | `pesquisa_mercado.md` |
| 11:00 | LLM Local: Dados demográficos | JSON estruturado |
| 14:00 | Qwen: Gerar 20 ideias de jogos | `ideias_qwen.json` |
| 16:00 | Android17: Consolidar pesquisa | Relatório final |

**Output do Dia**: Pesquisa completa + 20 ideias

---

### Terça-feira (Geração de Ideias)

| Hora | Tarefa | Output |
|------|--------|--------|
| 09:00 | Qwen: Brainstorm 20 ideias | Lista de ideias |
| 11:00 | LLM Local: Filtrar para 10 | Top 10 ideias |
| 14:00 | Qwen: Detalhar top 5 | GDDs preliminares |
| 16:00 | Afonso: Selecionar top 3 | 3 jogos selecionados |

**Output do Dia**: 3 GDDs aprovados

---

### Quarta-feira (Desenvolvimento - Dia 1)

| Hora | Tarefa | Output |
|------|--------|--------|
| 09:00 | Android17: Setup projetos | 3 projetos Unity |
| 11:00 | Android17: Código Bingo (core) | 50% Bingo pronto |
| 14:00 | Android17: Código Tigrinho (core) | 50% Tigrinho pronto |
| 17:00 | Afonso: Revisão | Feedback |

**Output do Dia**: 50% código de 2 jogos

---

### Quinta-feira (Desenvolvimento - Dia 2)

| Hora | Tarefa | Output |
|------|--------|--------|
| 09:00 | Android17: Código Truco (core) | 50% Truco pronto |
| 11:00 | Android17: Features Bingo | 80% Bingo pronto |
| 14:00 | Android17: Features Tigrinho | 80% Tigrinho pronto |
| 17:00 | Android17: Integração Ads | Todos com Ads |

**Output do Dia**: 80% código de 3 jogos

---

### Sexta-feira (Assets + Polish)

| Hora | Tarefa | Output |
|------|--------|--------|
| 09:00 | Afonso: Assets Bingo | Sprites brasileiros |
| 12:00 | Afonso: Assets Tigrinho | Sprites animais |
| 15:00 | Android17: Bug fixes | Bugs corrigidos |
| 18:00 | Android17: Build final | 3 APKs prontos |

**Output do Dia**: 3 APKs prontos para teste

---

### Sábado (Testes)

| Hora | Tarefa | Output |
|------|--------|--------|
| 09:00 | Afonso: QA testing | Lista de bugs |
| 12:00 | Android17: Bug fixes | Bugs corrigidos |
| 15:00 | Beta testers: Teste externo | Feedback |
| 18:00 | Afonso: Aprovação final | ✅ Aprovado |

**Output do Dia**: 3 APKs aprovados

---

### Domingo (Lançamento)

| Hora | Tarefa | Output |
|------|--------|--------|
| 09:00 | Android17: Play Store upload | 3 apps em review |
| 12:00 | Android17: ASO optimization | Listings otimizadas |
| 15:00 | Afonso: Marketing inicial | Posts redes sociais |
| 18:00 | 🚀 LAUNCH | 3 jogos publicados! |

**Output do Dia**: 3 jogos na Play Store!

---

## 📁 Estrutura de Projetos

```
gamesdev-factory/
├── semana1/
│   ├── bingo-carnaval/
│   │   ├── Assets/
│   │   ├── Scripts/
│   │   └── Builds/
│   ├── tigrinho-slots/
│   │   ├── Assets/
│   │   ├── Scripts/
│   │   └── Builds/
│   └── truco-online/
│       ├── Assets/
│       ├── Scripts/
│       └── Builds/
├── shared/
│   └── (código reutilizado do gamesdev)
└── builds/
    └── semana1/
        ├── bingo-carnaval-v1.0.0.apk
        ├── tigrinho-slots-v1.0.0.apk
        └── truco-online-v1.0.0.apk
```

---

## 🎯 Bingo Carnaval - GDD Resumido

### Visão Geral
- **Nome**: Bingo Carnaval
- **Gênero**: Bingo
- **Target**: 25-55 anos, Brasil
- **Tema**: Carnaval brasileiro

### Features
- ✅ Bingo tradicional (75 bolas)
- ✅ Power-ups (marcação rápida, dabber especial)
- ✅ Multiplayer (10-50 jogadores)
- ✅ Skins de carnaval
- ✅ Músicas brasileiras
- ✅ Eventos de Carnaval (sazonal)

### Monetização
| Tipo | Placement | Revenue Share |
|------|-----------|---------------|
| **Reward Video** | Cartelas extras | 50% |
| **Interstitial** | Entre jogos | 30% |
| **IAP** | Cartelas premium | 20% |

### Assets Necessários
| Asset | Quantidade | Status |
|-------|------------|--------|
| Sprites carnaval | 20 | ⏳ Pendente |
| Backgrounds | 5 | ⏳ Pendente |
| Músicas | 10 | ⏳ Pendente |
| UI Brasil | 15 | ✅ Reuse |

### KPI Targets
- Downloads D1: 2,000+
- Retention D1: 40%+
- ARPDAU: $0.08-0.12

---

## 🎰 Tigrinho Slots - GDD Resumido

### Visão Geral
- **Nome**: Tigrinho Slots
- **Gênero**: Slot Machine
- **Target**: 30-60 anos, Brasil
- **Tema**: Animais brasileiros

### Features
- ✅ 5 reels, 20 paylines
- ✅ Símbolos: animais brasileiros
- ✅ Bonus rounds (floresta, cidade)
- ✅ Jackpot progressivo
- ✅ Free spins
- ✅ Tema Brasil

### Monetização
| Tipo | Placement | Revenue Share |
|------|-----------|---------------|
| **Reward Video** | Free spins | 60% |
| **Interstitial** | Entre spins | 25% |
| **IAP** | Moedas premium | 15% |

### Assets Necessários
| Asset | Quantidade | Status |
|-------|------------|--------|
| Sprites animais | 10 | ⏳ Pendente |
| Backgrounds | 3 | ⏳ Pendente |
| SFX | 15 | ✅ Reuse 50% |
| UI Slots | 20 | ✅ Reuse 90% |

### KPI Targets
- Downloads D1: 3,000+
- Retention D1: 45%+
- ARPDAU: $0.10-0.15

---

## 🃏 Truco Online - GDD Resumido

### Visão Geral
- **Nome**: Truco Online
- **Gênero**: Cards
- **Target**: 18-50 anos, Brasil
- **Tema**: Truco tradicional brasileiro

### Features
- ✅ Truco paulista/mineiro/gaúcho
- ✅ Multiplayer online (2v2, 3v3)
- ✅ Ranked matchmaking
- ✅ Skins de cartas (temas brasileiros)
- ✅ Avatares brasileiros
- ✅ Chat (emoji + frases)

### Monetização
| Tipo | Placement | Revenue Share |
|------|-----------|---------------|
| **Reward Video** | Entrar em sala VIP | 40% |
| **Interstitial** | Entre partidas | 40% |
| **IAP** | Skins de cartas | 20% |

### Assets Necessários
| Asset | Quantidade | Status |
|-------|------------|--------|
| Cartas (design BR) | 52 | ⏳ Pendente |
| Mesas (temas BR) | 4 | ⏳ Pendente |
| Avatares | 20 | ⏳ Pendente |
| UI Cards | 30 | ✅ Reuse 70% |

### KPI Targets
- Downloads D1: 1,500+
- Retention D1: 50%+
- ARPDAU: $0.05-0.10

---

## 📊 Reuse de Código

### Código Reutilizado (GamesDev India)

| Sistema | Reuse % | Jogos Aplicáveis |
|---------|---------|------------------|
| **GameManager** | 100% | Todos |
| **UIManager** | 100% | Todos |
| **AudioManager** | 100% | Todos |
| **DataManager** | 100% | Todos |
| **AdMobManager** | 100% | Todos |
| **SocketManager** | 100% | Truco |
| **Matchmaking** | 100% | Truco |
| **SlotMachine Core** | 90% | Tigrinho |
| **Card Game Core** | 70% | Truco |
| **Bingo Core** | 80% | Bingo |

### Código Novo Necessário

| Sistema | Complexidade | Tempo |
|---------|--------------|-------|
| **Bingo Logic** | Baixa | 1 dia |
| **Truco Rules** | Média | 2 dias |
| **Brasil Localization** | Baixa | 0.5 dia |
| **PIX Payment** | Baixa | 0.5 dia |
| **Assets Brasileiros** | Média | 1-2 dias |

---

## 🎨 Assets Brasileiros

### Prioridade Alta

| Asset | Quantidade | Tempo | Responsável |
|-------|------------|-------|-------------|
| Sprites carnaval | 20 | 4h | Afonso/Designer |
| Sprites animais | 10 | 2h | Afonso/Designer |
| Cartas Truco BR | 52 | 6h | Afonso/Designer |
| Backgrounds | 12 | 4h | Afonso/Designer |

### Prioridade Média

| Asset | Quantidade | Tempo | Responsável |
|-------|------------|-------|-------------|
| Músicas brasileiras | 10 | 2h | Afonso (licença-free) |
| SFX brasileiros | 15 | 2h | Afonso |
| Avatares | 20 | 4h | Afonso/Designer |

---

## 🚀 Build + Launch

### Build Automation

```bash
# Build de todos os jogos da semana 1
cd gamesdev-factory/build
python build_automation.py --all --platform android

# Output:
# - bingo-carnaval-v1.0.0.apk
# - tigrinho-slots-v1.0.0.apk
# - truco-online-v1.0.0.apk
```

### Play Store Upload

| Jogo | Package Name | Category |
|------|--------------|----------|
| Bingo Carnaval | `com.afonso.fxtrade.bingocarnaval` | Casino |
| Tigrinho Slots | `com.afonso.fxtrade.tigrinhoslots` | Casino |
| Truco Online | `com.afonso.fxtrade.trucoonline` | Card |

### ASO (App Store Optimization)

| Elemento | Bingo | Tigrinho | Truco |
|----------|-------|----------|-------|
| **Title** | Bingo Carnaval 🎭 | Tigrinho Slots 🐯 | Truco Online 🃏 |
| **Keywords** | bingo, carnaval, brasil | slots, tigrinho, cassino | truco, cartas, brasil |
| **Description** | 150 chars | 150 chars | 150 chars |
| **Screenshots** | 6+ | 6+ | 6+ |

---

## 📈 Projeção Semana 1

### Downloads (Primeiros 7 Dias)

| Jogo | D1 | D7 | D30 |
|------|-----|-----|------|
| Bingo Carnaval | 2,000 | 10,000 | 30,000 |
| Tigrinho Slots | 3,000 | 15,000 | 50,000 |
| Truco Online | 1,500 | 8,000 | 25,000 |
| **Total** | **6,500** | **33,000** | **105,000** |

### Revenue (Primeiros 30 Dias)

| Jogo | ARPDAU | D30 Revenue |
|------|--------|-------------|
| Bingo Carnaval | $0.10 | $3,000 |
| Tigrinho Slots | $0.12 | $6,000 |
| Truco Online | $0.08 | $2,000 |
| **Total** | **-** | **$11,000** |

---

## ✅ Checklist Semana 1

### Segunda
- [ ] Pesquisa de mercado Brasil
- [ ] Gerar 20 ideias com Qwen
- [ ] Consolidar pesquisa

### Terça
- [ ] Filtrar para 10 ideias
- [ ] Detalhar top 5
- [ ] Afonso seleciona top 3

### Quarta
- [ ] Setup 3 projetos Unity
- [ ] Código Bingo (50%)
- [ ] Código Tigrinho (50%)

### Quinta
- [ ] Código Truco (50%)
- [ ] Features Bingo (80%)
- [ ] Features Tigrinho (80%)
- [ ] Integração Ads

### Sexta
- [ ] Assets brasileiros
- [ ] Bug fixes
- [ ] Build 3 APKs

### Sábado
- [ ] QA testing
- [ ] Bug fixes
- [ ] Beta testers
- [ ] Aprovação final

### Domingo
- [ ] Upload Play Store
- [ ] ASO optimization
- [ ] Marketing inicial
- [ ] 🚀 LAUNCH!

---

**Semana 1: Brasil - Tudo pronto para começar!** 🇧🇷🚀
