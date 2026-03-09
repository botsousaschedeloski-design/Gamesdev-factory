#!/bin/bash

# GamesDev Factory - Update AdMob Configs
# Atualiza automaticamente todas as configs com App IDs reais

echo "💰 GamesDev Factory - Update AdMob Configs"
echo "=========================================="
echo ""

# Check if admob-apps folder exists
if [ ! -d "admob-apps" ]; then
    echo "❌ Pasta admob-apps não encontrada!"
    echo "⚠️  Rode 05-create-admob-apps.sh primeiro"
    exit 1
fi

echo "📦 Atualizando configs do AdMob..."
echo ""

# Count files
updated=0
pending=0

for template in admob-apps/*-template.json; do
    if [ -f "$template" ]; then
        game=$(basename "$template" -template.json)
        echo "   📱 Processando: $game"
        
        # Check if App ID was filled
        if grep -q "ca-app-pub-XXXXXXXXXXXXXXXX~YYYYYYYYYY" "$template"; then
            echo "      ⚠️  App ID pendente (preencha manualmente)"
            ((pending++))
        else
            echo "      ✅ App ID configurado"
            
            # Copy to admob-configs
            cp "$template" "admob-configs/${game}-admob.json"
            ((updated++))
        fi
    fi
done

echo ""
echo "=========================================="
echo "✅ Atualização completa!"
echo ""
echo "📊 STATUS:"
echo "   Atualizados: $updated/15"
echo "   Pendentes: $pending/15"
echo ""

if [ $pending -gt 0 ]; then
    echo "⚠️  AINDA FALTAM:"
    echo "   1. Preencher App IDs em: admob-apps/*-template.json"
    echo "   2. Rodar este script novamente"
    echo ""
else
    echo "🎉 TODOS APPS CONFIGURADOS!"
    echo ""
    echo "💡 PRÓXIMO:"
    echo "   ./scripts/RUN_ME_FIRST.sh"
    echo "   (Vai usar configs atualizadas)"
    echo ""
fi
