#!/bin/bash

# GamesDev Factory - Main Runner Script
# Rode ESTE SCRIPT primeiro!

echo "🎮 GamesDev Factory - Auto Setup"
echo "================================"
echo ""
echo "⚠️  ESTE SCRIPT VAI:"
echo "   1. Baixar assets gratuitos"
echo "   2. Fazer build de 15 APKs"
echo "   3. Upload para 6 lojas"
echo "   4. Configurar AdMob"
echo ""
echo "⏱️  TEMPO ESTIMADO: 4-5 horas (automático)"
echo "💰 CUSTO: \$25 (Google Play)"
echo ""
read -p "Pressione ENTER para começar..."

# Get script directory
SCRIPT_DIR="$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )"

# Step 1: Assets
echo ""
echo "📦 Step 1/4: Baixando assets..."
echo "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━"
"$SCRIPT_DIR/01-assets-setup.sh"

# Step 2: Unity Builds
echo ""
echo "🎮 Step 2/4: Build APKs..."
echo "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━"
"$SCRIPT_DIR/02-unity-builds.sh"

# Step 3: Upload
echo ""
echo "📱 Step 3/4: Upload lojas..."
echo "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━"
"$SCRIPT_DIR/03-upload-stores.sh"

# Step 4: AdMob
echo ""
echo "💰 Step 4/4: AdMob setup..."
echo "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━"
"$SCRIPT_DIR/04-admob-setup.sh"

echo ""
echo "================================"
echo "✅ TUDO COMPLETO!"
echo "================================"
echo ""
echo "📊 PRÓXIMOS PASSOS:"
echo "   1. Criar conta Google Play: https://play.google.com/console (\$25)"
echo "   2. Criar conta AdMob: https://admob.google.com (free)"
echo "   3. Aguardar reviews: 2-7 dias"
echo "   4. Publish!"
echo ""
echo "💡 DOCUMENTAÇÃO:"
echo "   📚 COMPLETE_DOCUMENTATION.md"
echo "   📚 ASSETS_SVG_PACK.md"
echo "   📚 MULTI_STORE_DEPLOYMENT.md"
echo ""
