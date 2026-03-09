#!/bin/bash

# GamesDev Factory - Auto Assets Setup
# Baixa assets gratuitos e organiza

echo "🎨 GamesDev Factory - Assets Setup"
echo "=================================="
echo ""

# Create folders
mkdir -p assets/icons assets/screenshots assets/feature-graphics assets/free-assets

# Download Kenney.nl assets (CC0 License - Free for commercial use)
echo "📦 Baixando assets do Kenney.nl..."

# Check if curl is available
if ! command -v curl &> /dev/null; then
    echo "❌ curl não encontrado. Por favor instale: brew install curl"
    exit 1
fi

# Download asset packs
echo "   📦 1/5: Game Icons..."
curl -sL "https://kenney.nl/content/2d-assets/game-icons.zip" -o assets/free-assets/game-icons.zip 2>/dev/null || echo "   ⚠️  Falhou, continuando..."

echo "   📦 2/5: UI Pack..."
curl -sL "https://kenney.nl/content/2d-assets/ui-pack.zip" -o assets/free-assets/ui-pack.zip 2>/dev/null || echo "   ⚠️  Falhou, continuando..."

echo "   📦 3/5: Casino Pack..."
curl -sL "https://kenney.nl/content/2d-assets/casino-pack.zip" -o assets/free-assets/casino-pack.zip 2>/dev/null || echo "   ⚠️  Falhou, continuando..."

echo "   📦 4/5: Card Pack..."
curl -sL "https://kenney.nl/content/2d-assets/card-pack.zip" -o assets/free-assets/card-pack.zip 2>/dev/null || echo "   ⚠️  Falhou, continuando..."

echo "   📦 5/5: Board Game Pack..."
curl -sL "https://kenney.nl/content/2d-assets/board-game-pack.zip" -o assets/free-assets/board-game-pack.zip 2>/dev/null || echo "   ⚠️  Falhou, continuando..."

# Extract
echo ""
echo "📦 Extraindo assets..."
cd assets/free-assets
for zip in *.zip; do
    if [ -f "$zip" ]; then
        unzip -o "$zip" -d "${zip%.zip}" 2>/dev/null || echo "   ⚠️  Falhou ao extrair $zip"
    fi
done
cd ../..

echo ""
echo "✅ Assets baixados e extraídos!"
echo "📂 Pasta: assets/free-assets/"
echo ""
echo "💡 PRÓXIMO:"
echo "   1. Use assets em assets/free-assets/"
echo "   2. Copie ícones para assets/icons/"
echo "   3. Redimensione conforme necessário"
echo ""
