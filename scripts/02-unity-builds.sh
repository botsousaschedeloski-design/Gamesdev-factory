#!/bin/bash

# GamesDev Factory - Unity Auto Build
# Build automático de 15 APKs

echo "🎮 GamesDev Factory - Unity Auto Build"
echo "======================================="
echo ""

# Configuration
UNITY_PATH="/Applications/Unity/Hub/Editor/2022.3.0f1/Unity.app/Contents/MacOS/Unity"
PROJECTS_DIR="$HOME/Unity Projects/GamesDev"
BUILDS_DIR="$PROJECTS_DIR/Builds"

# Check if Unity exists
if [ ! -d "$UNITY_PATH" ]; then
    echo "❌ Unity não encontrado em: $UNITY_PATH"
    echo "⚠️  Por favor instale Unity 2022.3 LTS"
    echo "🔗 https://unity.com/download"
    exit 1
fi

# Create builds folder
mkdir -p "$BUILDS_DIR"

# Lista de 15 jogos
GAMES=(
    teenpatti
    slotmachine
    carrom3d
    dominoqq
    slotwayang
    capsaoffline
    cricketbetting
    teenpatticricket
    rummy
    teenpattibd
    cricketquiz
    ludobd
    footballquiz
    afroslots
    ayoboard
)

echo "📦 Total de jogos: ${#GAMES[@]}"
echo "📂 Builds em: $BUILDS_DIR"
echo ""

# Build each game
for i in "${!GAMES[@]}"; do
    game="${GAMES[$i]}"
    echo "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━"
    echo "🎮 [$(($i + 1))/${#GAMES[@]}] Building: $game"
    echo "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━"
    
    PROJECT_PATH="$PROJECTS_DIR/$game"
    APK_PATH="$BUILDS_DIR/${game}.apk"
    LOG_PATH="$BUILDS_DIR/${game}-build.log"
    
    # Check if project exists
    if [ ! -d "$PROJECT_PATH" ]; then
        echo "   ⚠️  Projeto não encontrado: $PROJECT_PATH"
        echo "   ⏭️  Pulando..."
        continue
    fi
    
    echo "   📁 Projeto: $PROJECT_PATH"
    echo "   📦 APK: $APK_PATH"
    echo ""
    echo "   🚀 Iniciando build..."
    echo ""
    
    # Unity build command
    "$UNITY_PATH" \
        -projectPath "$PROJECT_PATH" \
        -buildTarget Android \
        -executeMethod BuildScript.BuildAndroid \
        -buildOutput "$APK_PATH" \
        -quit \
        -batchmode \
        -logFile "$LOG_PATH"
    
    # Check result
    if [ -f "$APK_PATH" ]; then
        APK_SIZE=$(du -h "$APK_PATH" | cut -f1)
        echo ""
        echo "   ✅ Build completado!"
        echo "   📦 APK: $APK_PATH"
        echo "   📊 Tamanho: $APK_SIZE"
    else
        echo ""
        echo "   ❌ Build falhou!"
        echo "   📄 Log: $LOG_PATH"
        echo "   💡 Verifique log para detalhes"
    fi
    
    echo ""
done

echo "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━"
echo ""
echo "✅ Todos builds processados!"
echo "📂 APKs em: $BUILDS_DIR"
echo ""
echo "📊 STATUS:"
echo "   Builds completos: $(ls -1 $BUILDS_DIR/*.apk 2>/dev/null | wc -l | tr -d ' ')/15"
echo ""
echo "💡 PRÓXIMO:"
echo "   1. Testar APKs no dispositivo"
echo "   2. Assinar APKs (se necessário)"
echo "   3. Upload para lojas"
echo ""
