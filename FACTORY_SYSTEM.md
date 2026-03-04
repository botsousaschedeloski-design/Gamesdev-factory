# 🚀 GamesDev Factory - 3 Jogos/Semana

**Sistema de Geração de Ideias em Mercados Emergentes**  
**Data**: 2026-03-04

---

## 🎯 Objetivo

**Meta**: Lançar 3 jogos novos por semana  
**Modelo**: Reutilizar estrutura do GamesDev India  
**Foco**: Mercados emergentes + em desenvolvimento

---

## 🌍 Mercados Alvo

### Tier 1 (Prioridade Alta)

| País | População | Smartphone | Crescimento | Gêneros Populares |
|------|-----------|------------|-------------|-------------------|
| **🇮🇳 Índia** | 1.4B | 750M | 25%/ano | Cards, Casino, Board |
| **🇧🇷 Brasil** | 215M | 150M | 15%/ano | Slots, Bingo, Futebol |
| **🇮🇩 Indonésia** | 275M | 200M | 20%/ano | Casino, Puzzle, MOBA |

### Tier 2 (Prioridade Média)

| País | População | Smartphone | Crescimento | Gêneros Populares |
|------|-----------|------------|-------------|-------------------|
| **🇳🇬 Nigéria** | 220M | 100M | 30%/ano | Sports, Casino, Quiz |
| **🇵🇰 Paquistão** | 240M | 120M | 25%/ano | Cricket, Cards, Casino |
| **🇵🇭 Filipinas** | 115M | 80M | 18%/ano | Casino, Slots, Esports |

### Tier 3 (Oportunidades)

| País | População | Smartphone | Crescimento | Gêneros Populares |
|------|-----------|------------|-------------|-------------------|
| **🇧🇩 Bangladesh** | 170M | 90M | 28%/ano | Cards, Board, Quiz |
| **🇻🇳 Vietnã** | 98M | 60M | 22%/ano | MOBA, Puzzle, Casino |
| **🇹🇭 Tailândia** | 72M | 55M | 12%/ano | Slots, Muay Thai, Casino |

---

## 🔄 Pipeline de Geração de Ideias

### Semana Típica

```
Segunda: Pesquisa de Mercado (LLM Local + Qwen)
Terça: Geração de Ideias (Qwen)
Quarta: Seleção + GDD (LLM Local)
Quinta: Código Core (Android17 Auto)
Sexta: UI + Assets (Templates)
Sábado: Build + Testes
Domingo: Lançamento
```

---

## 🤖 Sistema de Pesquisa

### Fase 1: LLM Local (Ollama/LM Studio)

**Prompt para gemma3:4b**:
```
Analise o mercado de jogos mobile em [PAÍS]:

1. Dados demográficos (população, smartphones, internet)
2. Gêneros mais populares
3. Métodos de pagamento locais
4. Cultura local (festivais, esportes, tradições)
5. Jogos de sucesso no país
6. Regulamentações de jogos

Formato: JSON estruturado
```

**Output**: `mercado/[PAÍS]/pesquisa_local.json`

---

### Fase 2: Qwen API (Análise Profunda)

**Prompt para qwen3.5-plus**:
```
Com base na pesquisa local, gere 10 ideias de jogos para [PAÍS]:

Para cada ideia:
1. Nome do jogo
2. Gênero
3. Mecânica principal
4. Tema local (cultura, festival, esporte)
5. Monetização (IAP, Ads, ambos)
6. Complexidade (baixa, média, alta)
7. Tempo estimado de desenvolvimento

Critérios:
- Baixa complexidade preferencial
- Reutilizar assets existentes
- Tema culturalmente relevante
- Monetização adaptée ao mercado local

Formato: JSON array
```

**Output**: `mercado/[PAÍS]/ideias_qwen.json`

---

### Fase 3: Seleção (LLM Local)

**Prompt para gemma3:4b**:
```
Selecione as 3 melhores ideias para desenvolvimento:

Critérios de seleção:
1. ✅ Baixa complexidade (< 2 semanas)
2. ✅ Reutilização de código existente
3. ✅ Tema cultural forte
4. ✅ Potencial de monetização
5. ✅ Diferencial competitivo

Para cada selecionada:
- Justificativa
- Riscos
- Assets necessários
- Similar com jogos existentes

Output: Top 3 ranqueado
```

---

## 📊 Template de Ideia

### game_idea_template.json

```json
{
  "id": "BR-001",
  "market": "Brasil",
  "name": "Bingo da Sorte",
  "genre": "Casino/Bingo",
  "description": "Bingo brasileiro com temas de carnaval e futebol",
  
  "mechanics": {
    "core": "Bingo tradicional com power-ups",
    "multiplayer": true,
    "players": "10-50 por sala",
    "duration": "5-10 minutos por partida"
  },
  
  "localization": {
    "language": ["Português"],
    "theme": "Carnaval, Futebol, Praia",
    "events": ["Carnaval", "Copa do Mundo", "Réveillon"]
  },
  
  "monetization": {
    "ads": {
      "reward": "Cartelas extras",
      "interstitial": "Entre jogos",
      "banner": "Menu principal"
    },
    "iap": {
      "currency": "R$ 2,90 - R$ 49,90",
      "items": ["Cartelas premium", "Power-ups", "Skins"]
    }
  },
  
  "development": {
    "complexity": "Baixa",
    "time": "1-2 semanas",
    "reuse": "80% do código do Slot Machine",
    "newAssets": "20 sprites, 3 backgrounds"
  },
  
  "kpi_targets": {
    "downloads_d1": 1000,
    "retention_d1": "40%",
    "retention_d7": "20%",
    "arpdau": "$0.05-0.10"
  }
}
```

---

## 🏗️ Estrutura de Código Reutilizável

### Core Engine (100% Reuse)

```
shared/
├── core/
│   ├── GameManager.cs        ✅
│   ├── UIManager.cs          ✅
│   ├── AudioManager.cs       ✅
│   ├── DataManager.cs        ✅
│   └── AdMobManager.cs       ✅
├── network/
│   ├── SocketManager.cs      ✅
│   ├── Matchmaking.cs        ✅
│   └── Leaderboard.cs        ✅
└── monetization/
    ├── AdManager.cs          ✅
    ├── IAPManager.cs         ✅
    └── CurrencySystem.cs     ✅
```

### Game-Specific (60-80% Reuse)

```
games/[GAME_ID]/
├── Scripts/
│   ├── GameLogic.cs          ⚠️ 50% novo
│   ├── Features.cs           ⚠️ 30% novo
│   └── UI_Game.cs            ⚠️ 40% novo
├── Assets/
│   ├── Sprites/              ⚠️ 50% novo
│   ├── Audio/                ⚠️ 30% novo
│   └── Themes/               ⚠️ 60% novo
└── Config/
    └── game_config.json      ⚠️ 80% novo
```

---

## 📅 Cronograma Semanal

### Segunda: Pesquisa

| Hora | Tarefa | Ferramenta |
|------|--------|-----------|
| 09:00 | Selecionar mercado | Android17 |
| 10:00 | Pesquisa demográfica | LLM Local |
| 12:00 | Análise cultural | Qwen |
| 14:00 | Competidores | LLM Local |
| 16:00 | Consolidar pesquisa | Android17 |

**Output**: `mercado/[PAÍS]/relatorio_completo.md`

---

### Terça: Geração de Ideias

| Hora | Tarefa | Ferramenta |
|------|--------|-----------|
| 09:00 | Brainstorm 20 ideias | Qwen |
| 11:00 | Filtrar para 10 | LLM Local |
| 14:00 | Detalhar top 5 | Qwen |
| 16:00 | Selecionar top 3 | Android17 + Afonso |

**Output**: 3 GDDs prontos

---

### Quarta: Desenvolvimento Início

| Hora | Tarefa | Status |
|------|--------|--------|
| 09:00 | Setup projeto | Android17 |
| 11:00 | Código core | Android17 Auto |
| 14:00 | Features principais | Android17 Auto |
| 17:00 | Revisão | Afonso |

**Output**: 50% código pronto

---

### Quinta: Desenvolvimento Continuação

| Hora | Tarefa | Status |
|------|--------|--------|
| 09:00 | Features secundárias | Android17 Auto |
| 11:00 | UI implementation | Android17 Auto |
| 14:00 | Integração Ads | Android17 Auto |
| 17:00 | Primeiro build | Android17 |

**Output**: 90% código pronto, build teste

---

### Sexta: Assets + Polish

| Hora | Tarefa | Status |
|------|--------|--------|
| 09:00 | Assets visuais | Afonso/Designer |
| 12:00 | Audio/SFX | Afonso/Designer |
| 15:00 | Bug fixes | Android17 |
| 18:00 | Build final | Android17 |

**Output**: 100% pronto para launch

---

### Sábado: Testes

| Hora | Tarefa | Responsável |
|------|--------|-------------|
| 09:00 | QA testing | Afonso |
| 12:00 | Bug fixes | Android17 |
| 15:00 | Beta testers | Externo |
| 18:00 | Aprovação final | Afonso |

**Output**: APK aprovado

---

### Domingo: Lançamento

| Hora | Tarefa | Status |
|------|--------|--------|
| 09:00 | Play Store upload | Android17 |
| 12:00 | ASO optimization | Android17 |
| 15:00 | Marketing inicial | Afonso |
| 18:00 | 🚀 LAUNCH | Auto |

**Output**: 3 jogos na Play Store!

---

## 🎯 Pipeline de Assets

### Asset Library Compartilhada

```
assets-library/
├── ui/                    ✅ 100% reutilizável
│   ├── buttons/
│   ├── panels/
│   └── icons/
├── audio/
│   ├── sfx/
│   └── music/
├── themes/
│   ├── casino/
│   ├── board/
│   └── sports/
└── effects/
    ├── particles/
    └── animations/
```

### Reuse Rate por Gênero

| Gênero | Código Reuse | Assets Reuse | Tempo Total |
|--------|--------------|--------------|-------------|
| **Casino/Slots** | 85% | 60% | 3-4 dias |
| **Cards** | 80% | 50% | 4-5 dias |
| **Board** | 75% | 40% | 5-6 dias |
| **Sports** | 70% | 50% | 5-6 dias |
| **Puzzle** | 90% | 70% | 2-3 dias |
| **Quiz** | 95% | 80% | 1-2 dias |

---

## 📈 Métricas de Produção

### Por Semana

| Métrica | Meta |
|---------|------|
| Jogos lançados | 3 |
| Mercados pesquisados | 5-7 |
| Ideias geradas | 20-30 |
| GDDs completos | 3 |
| Código novo | ~5,000 linhas |
| Assets novos | ~100 sprites |

### Por Mês

| Métrica | Meta |
|---------|------|
| Jogos lançados | 12 |
| Mercados cobertos | 8-10 |
| Portfolio total | 50+ jogos |
| Receita combinada | $5,000-10,000/mês |

---

## 🤖 Automação Android17

### Scripts de Geração

| Script | Função | Tempo |
|--------|--------|-------|
| `generate_market_research.py` | Pesquisa mercado | 5 min |
| `generate_game_ideas.py` | Gera 20 ideias | 10 min |
| `select_top_games.py` | Seleciona top 3 | 5 min |
| `generate_gdd.py` | Cria GDD completo | 15 min |
| `generate_code.py` | Gera código base | 30 min |
| `generate_assets.py` | Cria templates assets | 20 min |
| `build_all.py` | Build de todos jogos | 45 min |

**Total Automação**: ~2 horas por jogo  
**Tempo Humano**: 1-2 horas (revisão + assets finais)

---

## 🎯 Primeiros Mercados (Semanas 1-4)

### Semana 1: 🇧🇷 Brasil

**Jogos Sugeridos**:
1. **Bingo Carnaval** - Bingo com tema de carnaval
2. **Truco Online** - Cartas tradicional brasileiro
3. **Tigrinho Slots** - Slot machine tema Brasil

**Assets Existentes**: 70% do GamesDev India  
**Novos Assets**: 30% (temas brasileiros)

---

### Semana 2: 🇮🇩 Indonésia

**Jogos Sugeridos**:
1. **Domino QQ** - Domino local popular
2. **Slot Wayang** - Slots com mitologia local
3. **Capsa Online** - Cartas tradicional

**Assets Existentes**: 80%  
**Novos Assets**: 20% (temas indonésios)

---

### Semana 3: 🇳🇬 Nigéria

**Jogos Sugeridos**:
1. **Football Quiz** - Quiz de futebol
2. **Ayo Board** - Board game tradicional
3. **Afro Slots** - Slots tema africano

**Assets Existentes**: 75%  
**Novos Assets**: 25% (temas africanos)

---

### Semana 4: 🇵🇰 Paquistão

**Jogos Sugeridos**:
1. **Cricket Betting Sim** - Simulador (sem dinheiro)
2. **Teen Patti Cricket** - Teen Patti tema cricket
3. **Rummy Pakistan** - Rummy local

**Assets Existentes**: 85% (similar Índia)  
**Novos Assets**: 15%

---

## 💡 Sistema de Ideias com LLM Local

### prompt_market_research.txt

```
Você é um analista de mercado de jogos mobile.

Analise o mercado de [PAÍS] considerando:

1. DEMOGRAFIA
   - População total
   - Usuários de smartphone
   - Faixa etária predominante
   - Renda média

2. CULTURA DE JOGOS
   - Gêneros mais populares
   - Jogos de sucesso local
   - Preferências de gameplay
   - Tempo médio de sessão

3. CULTURA LOCAL
   - Festivais principais
   - Esportes populares
   - Símbolos culturais
   - Cores preferidas

4. MONETIZAÇÃO
   - Métodos de pagamento
   - Ticket médio de IAP
   - Tolerância a ads
   - eCPM local

5. REGULAMENTAÇÃO
   - Leis de jogos
   - Restrições de conteúdo
   - Age rating
   - Taxas/impostos

Output: JSON estruturado
```

---

### prompt_game_generation.txt

```
Você é um designer de jogos mobile especializado em mercados emergentes.

Com base na pesquisa de [PAÍS], gere 10 ideias de jogos.

Para cada ideia inclua:

1. NOME E CONCEITO
   - Nome em inglês + local
   - Elevator pitch (1 frase)
   - Gênero principal

2. GAMEPLAY
   - Mecânica core
   - Duração da sessão
   - Single/Multiplayer
   - Progressão

3. LOCALIZAÇÃO
   - Tema cultural específico
   - Festivais/eventos
   - Elementos locais
   - Idiomas

4. MONETIZAÇÃO
   - Estratégia (Ads, IAP, misto)
   - Preço de IAP (moeda local)
   - Placement de ads
   - Rewards

5. DESENVOLVIMENTO
   - Complexidade (1-5)
   - Tempo estimado
   - % Reuse de código existente
   - Assets novos necessários

6. POTENCIAL
   - Download projections (D1, D30)
   - Revenue projections
   - KPI targets
   - Riscos

Priorize:
✅ Baixa complexidade (1-3)
✅ Alto reuse de código (>60%)
✅ Tema cultural forte
✅ Monetização adaptada ao mercado

Output: JSON array com 10 ideias
```

---

## 🚀 Próximos Passos

### Imediato (Esta Semana)

1. [ ] Selecionar próximo mercado (Brasil?)
2. [ ] Rodar pesquisa com LLM local
3. [ ] Gerar 20 ideias com Qwen
4. [ ] Selecionar top 3 com Afonso
5. [ ] Iniciar desenvolvimento

### Configuração

1. [ ] Criar pasta `mercados/` com subpastas
2. [ ] Criar prompts em arquivos `.txt`
3. [ ] Configurar scripts de automação
4. [ ] Template de GDD genérico
5. [ ] Asset library organizada

---

**Sistema pronto para 3 jogos/semana!** 🚀
