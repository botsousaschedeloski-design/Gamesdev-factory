#!/bin/bash

# GamesDev Factory - Auto Build APKs
# Faz build automático de todos 15 APKs

echo "🎮 GamesDev Factory - Auto Build APKs"
echo "======================================"
echo ""

UNITY_PATH="/Applications/Unity/Hub/Editor/2022.3.0f1/Unity.app/Contents/MacOS/Unity"
PROJECTS_DIR="$HOME/Unity Projects/GamesDev"
BUILDS_DIR="$HOME/Unity Projects/GamesDev-Builds"

mkdir -p "$BUILDS_DIR"

# Lista de jogos
declare -a GAMES=(
    "teenpatti:com.afonso.fxtrade.teenpatti"
    "slotmachine:com.afonso.fxtrade.slotmachine"
    "carrom3d:com.afonso.fxtrade.carrom3d"
    "dominoqq:com.afonso.fxtrade.dominoqq"
    "slotwayang:com.afonso.fxtrade.slotwayang"
    "capsaoffline:com.afonso.fxtrade.capsaoffline"
    "cricketbetting:com.afonso.fxtrade.cricketbetting"
    "teenpatticricket:com.afonso.fxtrade.teenpatticricket"
    "rummy:com.afonso.fxtrade.rummy"
    "teenpattibd:com.afonso.fxtrade.teenpattibd"
    "cricketquiz:com.afonso.fxtrade.cricketquiz"
    "ludobd:com.afonso.fxtrade.ludobd"
    "footballquiz:com.afonso.fxtrade.footballquiz"
    "afroslots:com.afonso.fxtrade.afroslots"
    "ayoboard:com.afonso.fxtrade.ayoboard"
)

# Processar cada jogo
for game_info in "${GAMES[@]}"; do
    IFS=':' read -r game_name package_name <<< "$game_info"
    
    echo "🎯 Build: $game_name"
    echo "-------------------------------------------"
    
    PROJECT_PATH="$PROJECTS_DIR/$game_name"
    APK_PATH="$BUILDS_DIR/${game_name}.apk"
    
    if [ ! -d "$PROJECT_PATH" ]; then
        echo "   ⚠️ Projeto não encontrado, pulando..."
        continue
    fi
    
    # Comando Unity para build
    echo "1️⃣ Iniciando build..."
    
    "$UNITY_PATH" \
        -projectPath "$PROJECT_PATH" \
        -buildTarget Android \
        -executeMethod BuildScript.BuildAndroid \
        -buildOutput "$APK_PATH" \
        -quit \
        -batchmode \
        -logFile "$BUILDS_DIR/${game_name}-build.log"
    
    if [ -f "$APK_PATH" ]; then
        echo "   ✅ Build completado: $APK_PATH"
    else
        echo "   ❌ Build falhou. Verifique log: ${game_name}-build.log"
    fi
    
    echo ""
done

echo "========================================="
echo "✅ Todos builds processados!"
echo ""
echo "📂 APKs em: $BUILDS_DIR"
echo ""
