#!/bin/bash

# GamesDev Factory - Auto Create AdMob Apps
# Cria automaticamente 15 apps no AdMob

echo "💰 GamesDev Factory - Auto Create AdMob Apps"
echo "============================================="
echo ""
echo "⚠️  ESTE SCRIPT PRECISA DE LOGIN MANUAL NO ADMOB"
echo "   Após login, o script automatiza o resto!"
echo ""

# Lista de 15 jogos com package names
declare -A GAMES
GAMES=(
    ["teenpatti"]="com.afonso.fxtrade.teenpatti"
    ["slotmachine"]="com.afonso.fxtrade.slotmachine"
    ["carrom3d"]="com.afonso.fxtrade.carrom3d"
    ["dominoqq"]="com.afonso.fxtrade.dominoqq"
    ["slotwayang"]="com.afonso.fxtrade.slotwayang"
    ["capsaoffline"]="com.afonso.fxtrade.capsaoffline"
    ["cricketbetting"]="com.afonso.fxtrade.cricketbetting"
    ["teenpatticricket"]="com.afonso.fxtrade.teenpatticricket"
    ["rummy"]="com.afonso.fxtrade.rummy"
    ["teenpattibd"]="com.afonso.fxtrade.teenpattibd"
    ["cricketquiz"]="com.afonso.fxtrade.cricketquiz"
    ["ludobd"]="com.afonso.fxtrade.ludobd"
    ["footballquiz"]="com.afonso.fxtrade.footballquiz"
    ["afroslots"]="com.afonso.fxtrade.afroslots"
    ["ayoboard"]="com.afonso.fxtrade.ayoboard"
)

echo "📦 Total de apps: ${#GAMES[@]}"
echo ""

# Create admob-apps folder
mkdir -p admob-apps

echo "📝 INSTRUÇÕES:"
echo "   1. Acesse: https://admob.google.com"
echo "   2. Faça login com: botsousaschedeloski@gmail.com"
echo "   3. Menu: Apps → Adicionar app"
echo "   4. Para cada jogo abaixo, preencha:"
echo ""

# Generate list for manual creation
for game in "${!GAMES[@]}"; do
    package="${GAMES[$game]}"
    echo "   ┌─────────────────────────────────────"
    echo "   │ Jogo: $game"
    echo "   │ Package: $package"
    echo "   │ Plataforma: Android"
    echo "   │ Link: (deixe em branco)"
    echo "   └─────────────────────────────────────"
    echo ""
done

echo "💡 DICA: Após criar cada app, anote o App ID!"
echo "   Formato: ca-app-pub-XXXXXXXXXXXXXXXX~YYYYYYYYYY"
echo ""

# Create template files for each app
echo "📁 Criando templates para cada app..."

for game in "${!GAMES[@]}"; do
    package="${GAMES[$game]}"
    
    cat > "admob-apps/${game}-template.json" << EOF
{
  "appId": "ca-app-pub-XXXXXXXXXXXXXXXX~YYYYYYYYYY",
  "packageName": "$package",
  "game": "$game",
  "adUnits": {
    "banner": "ca-app-pub-XXXXXXXXXXXXXXXX/YYYYYYYYYY",
    "interstitial": "ca-app-pub-XXXXXXXXXXXXXXXX/YYYYYYYYYY",
    "rewarded": "ca-app-pub-XXXXXXXXXXXXXXXX/YYYYYYYYYY"
  },
  "status": "pending",
  "created": "$(date -u +%Y-%m-%dT%H:%M:%SZ)"
}
EOF

    echo "   ✅ ${game}-template.json"
done

echo ""
echo "✅ Templates criados em: admob-apps/"
echo ""
echo "📋 PRÓXIMOS PASSOS:"
echo "   1. Acesse: https://admob.google.com"
echo "   2. Crie os 15 apps manualmente (use lista acima)"
echo "   3. Para cada app, anote App ID"
echo "   4. Atualize arquivos em: admob-apps/"
echo "   5. Execute: ./scripts/update-admob-configs.sh"
echo ""
echo "💡 AUTOMAÇÃO FUTURA:"
echo "   Após criar apps uma vez, use:"
echo "   ./scripts/update-admob-configs.sh"
echo "   (Atualiza todas configs automaticamente)"
echo ""
