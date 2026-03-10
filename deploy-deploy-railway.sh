#!/bin/bash

# GamesDev Factory - Deploy Script (Railway)

echo "🚀 Deploy Backend na Railway"
echo "=============================="
echo ""

# Check if logged in
echo "📝 Verificando login..."
if ! railway whoami 2>/dev/null; then
    echo ""
    echo "⚠️  Não logado na Railway!"
    echo "📝 Execute: railway login"
    echo ""
    read -p "Pressione Enter para continuar..."
    railway login
fi

echo ""
echo "📦 Iniciando deploy..."
cd backend

# Init project
echo "📦 Iniciando projeto..."
railway init

# Add environment variables
echo "⚙️  Configurando variáveis..."
echo ""
read -p "DATABASE_URL: " DATABASE_URL
railway variables set DATABASE_URL="$DATABASE_URL"

read -p "ADMOB_API_KEY: " ADMOB_API_KEY
railway variables set ADMOB_API_KEY="$ADMOB_API_KEY"

# Deploy
echo ""
echo "🚀 Fazendo deploy..."
railway up

echo ""
echo "✅ Deploy completo!"
echo ""
echo "🌐 URL da API:"
echo "https://gamesdev-factory-api.up.railway.app"
