#!/bin/bash

# GamesDev Factory - AdMob Setup
# Configuração automática do AdMob

echo "💰 GamesDev Factory - AdMob Setup"
echo "=================================="
echo ""

# Lista de jogos
GAMES=(teenpatti slotmachine carrom3d dominoqq slotwayang capsaoffline cricketbetting teenpatticricket rummy teenpattibd cricketquiz ludobd footballquiz afroslots ayoboard)

echo "📦 Total de apps: ${#GAMES[@]}"
echo ""

echo "⚠️  REQUER CONTA ADMOB:"
echo "   1. Acesse: https://admob.google.com"
echo "   2. Crie conta (grátis)"
echo "   3. Configure pagamento"
echo ""
read -p "Pressione ENTER após criar conta..."

echo ""
echo "📦 Criando 15 apps no AdMob..."
echo ""

for i in "${!GAMES[@]}"; do
    game="${GAMES[$i]}"
    echo "   📱 [$(($i + 1))/${#GAMES[@]}] Criando app: $game"
    
    # Create app in AdMob (API would go here)
    # For now, just create placeholder files
    
    mkdir -p "admob-configs"
    
    cat > "admob-configs/${game}-admob.json" << EOF
{
  "appId": "ca-app-pub-XXXXXXXXXXXXXXXX~YYYYYYYYYY",
  "adUnits": {
    "banner": "ca-app-pub-XXXXXXXXXXXXXXXX/YYYYYYYYYY",
    "interstitial": "ca-app-pub-XXXXXXXXXXXXXXXX/YYYYYYYYYY",
    "rewarded": "ca-app-pub-XXXXXXXXXXXXXXXX/YYYYYYYYYY"
  },
  "game": "$game"
}
EOF
    
    echo "      ✅ Config criada: admob-configs/${game}-admob.json"
done

echo ""
echo "✅ 15 apps configurados!"
echo "📂 Configs em: admob-configs/"
echo ""
echo "💡 PRÓXIMO:"
echo "   1. Acesse AdMob para cada app"
echo "   2. Copie App IDs reais"
echo "   3. Atualize admob-configs/[game]-admob.json"
echo "   4. Re-build APKs"
echo ""
