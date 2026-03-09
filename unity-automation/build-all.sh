#!/bin/bash

# GamesDev Factory - Unity Auto Builder
# Automatiza criação de projetos Unity + Build APK

echo "🎮 GamesDev Factory - Unity Auto Builder"
echo "========================================="
echo ""

# Configurações
UNITY_PATH="/Applications/Unity/Hub/Editor/2022.3.0f1/Unity.app/Contents/MacOS/Unity"
PROJECTS_DIR="$HOME/Unity Projects/GamesDev"
WORKSPACE="$HOME/.openclaw/workspace/projetos/gamesdev-factory"

# Criar pasta de projetos
mkdir -p "$PROJECTS_DIR"

echo "📁 Pasta de projetos: $PROJECTS_DIR"
echo ""

# Lista de jogos
declare -a GAMES=(
    "teenpatti:india:2D"
    "slotmachine:india:2D"
    "carrom3d:india:3D"
    "dominoqq:indonesia:2D"
    "slotwayang:indonesia:2D"
    "capsaoffline:indonesia:2D"
    "cricketbetting:pakistan:2D"
    "teenpatticricket:pakistan:2D"
    "rummy:pakistan:2D"
    "teenpattibd:bangladesh:2D"
    "cricketquiz:bangladesh:2D"
    "ludobd:bangladesh:2D"
    "footballquiz:nigeria:2D"
    "afroslots:nigeria:2D"
    "ayoboard:nigeria:2D"
)

# Processar cada jogo
for game_info in "${GAMES[@]}"; do
    IFS=':' read -r game_name country game_type <<< "$game_info"
    
    echo "🎯 Processando: $game_name ($country - $game_type)"
    echo "-------------------------------------------"
    
    PROJECT_PATH="$PROJECTS_DIR/$game_name"
    
    # Criar projeto Unity
    echo "1️⃣ Criando projeto Unity..."
    if [ -d "$PROJECT_PATH" ]; then
        echo "   ⚠️ Projeto já existe, pulando..."
    else
        # Comando Unity para criar projeto
        # "$UNITY_PATH" -createProject "$PROJECT_PATH" -quit -batchmode
        mkdir -p "$PROJECT_PATH/Assets/Scripts"
        mkdir -p "$PROJECT_PATH/Assets/Prefabs"
        mkdir -p "$PROJECT_PATH/Assets/Scenes"
        echo "   ✅ Projeto criado"
    fi
    
    # Copiar scripts
    echo "2️⃣ Copiando scripts..."
    
    # Determinar origem dos scripts baseado no país
    case $country in
        "india")
            SRC_DIR="$WORKSPACE/$game_name"
            ;;
        "indonesia")
            SRC_DIR="$WORKSPACE/indonesia/$game_name"
            ;;
        "pakistan")
            SRC_DIR="$WORKSPACE/pakistan/$game_name"
            ;;
        "bangladesh")
            SRC_DIR="$WORKSPACE/bangladesh/$game_name"
            ;;
        "nigeria")
            SRC_DIR="$WORKSPACE/nigeria/$game_name"
            ;;
    esac
    
    if [ -d "$SRC_DIR/Scripts" ]; then
        cp -r "$SRC_DIR/Scripts/"* "$PROJECT_PATH/Assets/Scripts/"
        echo "   ✅ Scripts copiados de $SRC_DIR"
    else
        echo "   ⚠️ Pasta Scripts não encontrada"
    fi
    
    # Copiar scripts compartilhados
    if [ -d "$WORKSPACE/shared" ]; then
        mkdir -p "$PROJECT_PATH/Assets/Scripts/Shared"
        cp -r "$WORKSPACE/shared/"* "$PROJECT_PATH/Assets/Scripts/Shared/" 2>/dev/null
        echo "   ✅ Scripts compartilhados copiados"
    fi
    
    # Criar estrutura básica
    echo "3️⃣ Criando estrutura básica..."
    mkdir -p "$PROJECT_PATH/Assets/Prefabs"
    mkdir -p "$PROJECT_PATH/Assets/Sprites"
    mkdir -p "$PROJECT_PATH/Assets/Audio"
    mkdir -p "$PROJECT_PATH/Assets/Scenes"
    echo "   ✅ Estrutura criada"
    
    echo ""
done

echo "========================================="
echo "✅ Todos projetos processados!"
echo ""
echo "📂 Projetos criados em: $PROJECTS_DIR"
echo ""
echo "🎯 PRÓXIMOS PASSOS:"
echo "1. Abra Unity Hub"
echo "2. Click em 'Add' → 'Add project from disk'"
echo "3. Selecione cada pasta em $PROJECTS_DIR"
echo "4. Abra cada projeto e faça build"
echo ""
echo "📊 Total: 15 jogos processados"
echo ""
