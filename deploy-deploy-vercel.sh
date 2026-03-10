#!/bin/bash

# GamesDev Factory - Deploy Script (Vercel)

echo "🚀 Deploy Frontend na Vercel"
echo "=============================="
echo ""

# Check if logged in
echo "📝 Verificando login..."
if ! vercel whoami 2>/dev/null; then
    echo ""
    echo "⚠️  Não logado na Vercel!"
    echo "📝 Execute: vercel login"
    echo ""
    read -p "Pressione Enter para continuar..."
    vercel login
fi

echo ""
echo "📦 Fazendo deploy..."
cd frontend/public
vercel --prod

echo ""
echo "✅ Deploy completo!"
echo ""
echo "🌐 URL do Dashboard:"
echo "https://gamesdev-factory-dashboard.vercel.app"
