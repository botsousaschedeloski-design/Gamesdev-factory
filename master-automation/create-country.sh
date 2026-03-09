#!/bin/bash

# Master Automation - Create New Country
# Cria novo país com 3 jogos automaticamente

echo "🎮 GamesDev Factory - Create New Country"
echo "========================================="
echo ""

# Parâmetros
COUNTRY_CODE=$1
COUNTRY_NAME=$2
NUM_GAMES=${3:-3}

if [ -z "$COUNTRY_CODE" ] || [ -z "$COUNTRY_NAME" ]; then
    echo "❌ Uso: ./create-country.sh [codigo] \"Nome\" [num-jogos]"
    echo "Exemplo: ./create-country.sh philippines \"Filipinas\" 3"
    exit 1
fi

WORKSPACE="$HOME/.openclaw/workspace/projetos/gamesdev-factory"
COUNTRY_DIR="$WORKSPACE/$COUNTRY_CODE"

echo "📦 Criando país: $COUNTRY_NAME ($COUNTRY_CODE)"
echo "   Jogos: $NUM_GAMES"
echo ""

# Criar pasta do país
mkdir -p "$COUNTRY_CODE"

# Criar README
cat > "$COUNTRY_CODE/README.md" << EOF
# 🇺🇳 $COUNTRY_NAME - GamesDev Factory

**Status**: 📋 Planejando

---

## Jogos:

$(for i in $(seq 1 $NUM_GAMES); do echo "- [ ] Jogo $i - Em planejamento"; done)

---

## Progresso:

- [ ] GDDs criados
- [ ] Código C# gerado
- [ ] Projetos Unity criados
- [ ] APKs buildados

---

**Criado**: $(date +%Y-%m-%d)
**Total Jogos**: $NUM_GAMES
EOF

echo "✅ README.md criado"

# Gerar GDDs para cada jogo
for i in $(seq 1 $NUM_GAMES); do
    GAME_NAME="game-$i"
    mkdir -p "$COUNTRY_CODE/$GAME_NAME"
    
    cat > "$COUNTRY_CODE/$GAME_NAME/GDD.md" << EOF
# 🎮 $GAME_NAME - Game Design Document

**País**: $COUNTRY_NAME
**Status**: 📋 Planejando

---

## Visão Geral:

| Item | Descrição |
|------|-----------|
| **Gênero** | TBD |
| **Modo** | Single Player |
| **Offline** | ✅ 100% offline |
| **Engine** | Unity (C#) |
| **Desenvolvimento** | 1-2 dias |
| **Reuse** | 75-90% |

---

## Gameplay:

TBD (a definir)

---

## Estrutura:

\`\`\`
Assets/
├── Scripts/
│   └── [Scripts C#]
├── Prefabs/
├── Sprites/
└── Audio/
\`\`\`

---

**Status**: ⏳ Aguardando geração de código

EOF

    echo "✅ GDD $GAME_NAME criado"
done

# Atualizar dashboard
echo ""
echo "📊 Atualizando dashboard..."
# (Script de update do dashboard seria chamado aqui)

# Git commit
echo ""
echo "💾 Fazendo git commit..."
cd "$WORKSPACE"
git add "$COUNTRY_CODE"
git commit -m "📦 Criar país: $COUNTRY_NAME ($NUM_GAMES jogos)"
git push origin main

echo ""
echo "========================================="
echo "✅ País $COUNTRY_NAME criado!"
echo ""
echo "📂 Pasta: $COUNTRY_CODE/"
echo "📝 GDDs: $NUM_GAMES criados"
echo ""
echo "🎯 PRÓXIMOS PASSOS:"
echo "1. Android17 gera código C#"
echo "2. Unity automation cria projetos"
echo "3. Build APKs automático"
echo ""
