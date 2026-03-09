#!/bin/bash

# Copy All Scripts to Unity Projects
# Copia TODOS scripts C# para projetos Unity

echo "📦 Copying All Scripts to Unity Projects"
echo "========================================="
echo ""

UNITY_PROJECTS="$HOME/Unity Projects/GamesDev"
WORKSPACE="$HOME/.openclaw/workspace/projetos/gamesdev-factory"

# Copy Indonesia scripts
echo "🇮🇩 Copying Indonesia scripts..."
for game in domino-qq slot-wayang capsa-offline; do
    game_name=$(echo $game | tr '-' '')
    if [ -d "$WORKSPACE/indonesia/$game/Scripts" ]; then
        cp "$WORKSPACE/indonesia/$game/Scripts"/* "$UNITY_PROJECTS/$game_name/Assets/Scripts/"
        echo "   ✅ $game → $game_name"
    fi
done

# Copy Pakistan scripts
echo ""
echo "🇵🇰 Copying Pakistan scripts..."
for game in cricket-betting teenpatti-cricket rummy; do
    game_name=$(echo $game | tr '-' '')
    if [ -d "$WORKSPACE/pakistan/$game/Scripts" ]; then
        cp "$WORKSPACE/pakistan/$game/Scripts"/* "$UNITY_PROJECTS/$game_name/Assets/Scripts/"
        echo "   ✅ $game → $game_name"
    fi
done

# Copy Bangladesh scripts
echo ""
echo "🇧🇩 Copying Bangladesh scripts..."
for game in teenpatti-bd cricket-quiz ludo-bd; do
    game_name=$(echo $game | tr '-' '')
    # Bangladesh usa reuse, copiar scripts genéricos
    if [ -d "$WORKSPACE/bangladesh/$game/Scripts" ]; then
        cp "$WORKSPACE/bangladesh/$game/Scripts"/* "$UNITY_PROJECTS/$game_name/Assets/Scripts/" 2>/dev/null
        echo "   ✅ $game → $game_name"
    else
        echo "   ⚠️ $game: usando scripts genéricos"
    fi
done

# Copy Nigeria scripts
echo ""
echo "🇳🇬 Copying Nigeria scripts..."
for game in football-quiz afro-slots ayo-board; do
    game_name=$(echo $game | tr '-' '')
    if [ -d "$WORKSPACE/nigeria/$game/Scripts" ]; then
        cp "$WORKSPACE/nigeria/$game/Scripts"/* "$UNITY_PROJECTS/$game_name/Assets/Scripts/" 2>/dev/null
        echo "   ✅ $game → $game_name"
    else
        echo "   ⚠️ $game: usando scripts genéricos"
    fi
done

# Copy shared scripts
echo ""
echo "📦 Copying shared scripts..."
if [ -d "$WORKSPACE/shared" ]; then
    for project in "$UNITY_PROJECTS"/*/; do
        mkdir -p "$project/Assets/Scripts/Shared"
        cp -r "$WORKSPACE/shared"/* "$project/Assets/Scripts/Shared/" 2>/dev/null
    done
    echo "   ✅ Shared scripts copied to all projects"
fi

echo ""
echo "========================================="
echo "✅ All scripts copied!"
echo ""
