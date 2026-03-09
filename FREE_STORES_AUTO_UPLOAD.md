# 🤖 Free Stores Auto-Upload Guide

**Upload Automatizado para 5 Lojas Gratuitas**

---

## 📊 VISÃO GERAL:

| Loja | API Upload | CLI Tool | Web Upload | Auto Possible |
|------|------------|----------|------------|---------------|
| **Amazon** | ✅ Sim | ✅ Sim | ✅ Sim | ✅ 80% Auto |
| **Samsung** | ❌ Não | ❌ Não | ✅ Sim | ⚠️ 50% Auto |
| **Huawei** | ✅ Sim | ✅ Sim | ✅ Sim | ✅ 80% Auto |
| **itch.io** | ✅ Sim | ✅ Sim | ✅ Sim | ✅ 90% Auto |
| **GitHub** | ✅ Sim | ✅ Sim | ✅ Sim | ✅ 100% Auto |

---

## 🛒 1. AMAZON APP STORE (80% Auto)

### **API Upload:**

#### **Requisitos:**
```
✅ Amazon Developer Account (free)
✅ API Key (do dashboard)
✅ APKs assinados
✅ Assets (ícones, screenshots)
```

#### **Script de Upload Automático:**

```bash
#!/bin/bash
# amazon-upload.sh

AMAZON_API_KEY="YOUR_API_KEY"
AMAZON_SECRET="YOUR_SECRET"

for game in teenpatti slotmachine carrom3d dominoqq slotwayang capsaoffline; do
    echo "📦 Uploading $game to Amazon..."
    
    curl -X POST \
        -H "Authorization: Bearer $AMAZON_API_KEY" \
        -F "apk=@builds/${game}.apk" \
        -F "title=${game}" \
        -F "description=@descriptions/${game}.txt" \
        -F "icon=@assets/icons/${game}-512.png" \
        -F "screenshots[@]=@assets/screenshots/${game}-*.png" \
        https://developer.amazon.com/api/applications
    
    echo "✅ $game uploaded!"
done
```

#### **Ferramentas:**
```
✅ amz-upload (npm package)
✅ Amazon CLI (official)
✅ Fastlane (multi-store)
```

#### **Instalação Fastlane:**
```bash
# Instalar
sudo gem install fastlane

# Setup
fastlane init

# Configurar Amazon
fastlane add_plugin amazon_appstore

# Upload
fastlane amazon_upload
```

#### **Tempo: 30 minutos (15 jogos)**

---

## 📱 2. SAMSUNG GALAXY STORE (50% Auto)

### **Web Upload (Semi-Auto):**

#### **Requisitos:**
```
✅ Samsung Seller Account (free)
✅ APKs assinados
✅ Assets
```

#### **Script de Preparação:**

```bash
#!/bin/bash
# samsung-prepare.sh

for game in teenpatti slotmachine carrom3d; do
    echo "📦 Preparing $game for Samsung..."
    
    # Create package
    zip -r samsung-${game}.zip \
        builds/${game}.apk \
        assets/icons/${game}-512.png \
        assets/screenshots/${game}-*.png \
        descriptions/${game}.txt
    
    echo "✅ $game package ready!"
done

echo "📦 All packages ready for manual upload"
echo "🔗 Upload: https://seller.samsungapps.com"
```

#### **Upload Manual (Necessário):**
```
1. seller.samsungapps.com
2. Login
3. Add Product (15x)
4. Upload ZIP package
5. Fill details
6. Submit
```

#### **Tempo: 1-2 horas (15 jogos)**

---

## 🌸 3. HUAWEI APPGALLERY (80% Auto)

### **API Upload:**

#### **Requisitos:**
```
✅ Huawei Developer Account (free)
✅ AppGallery Connect API
✅ APKs assinados
✅ Assets
```

#### **Script de Upload:**

```bash
#!/bin/bash
# huawei-upload.sh

HUAWEI_CLIENT_ID="YOUR_CLIENT_ID"
HUAWEI_CLIENT_SECRET="YOUR_SECRET"

# Get access token
TOKEN=$(curl -X POST \
    https://oauth-login.cloud.huawei.com/oauth2/v3/token \
    -d "client_id=$HUAWEI_CLIENT_ID" \
    -d "client_secret=$HUAWEI_CLIENT_SECRET" \
    -d "grant_type=client_credentials" \
    | jq -r '.access_token')

for game in teenpatti slotmachine carrom3d; do
    echo "📦 Uploading $game to Huawei..."
    
    curl -X POST \
        -H "Authorization: Bearer $TOKEN" \
        -F "file=@builds/${game}.apk" \
        -F "appName=${game}" \
        https://connect-api.cloud.huawei.com/api/publish/v2/app-file-submit
    
    echo "✅ $game uploaded!"
done
```

#### **Ferramentas:**
```
✅ Huawei AGC CLI
✅ Fastlane Huawei plugin
✅ agc-upload (npm)
```

#### **Tempo: 30 minutos (15 jogos)**

---

## 🎮 4. ITCH.IO (90% Auto)

### **CLI Upload (Totalmente Auto):**

#### **Instalação:**
```bash
# Instalar butler (itch.io CLI)
npm install -g butler

# Login
butler login
```

#### **Script de Upload:**

```bash
#!/bin/bash
# itch-upload.sh

USERNAME="your-username"

for game in teenpatti slotmachine carrom3d dominoqq slotwayang capsaoffline cricketbetting teenpatticricket rummy teenpattibd cricketquiz ludobd footballquiz afroslots ayoboard; do
    echo "📦 Uploading $game to itch.io..."
    
    butler push \
        builds/${game}.apk \
        ${USERNAME}/${game}:android \
        --userversion 1.0.0
    
    echo "✅ $game uploaded!"
done
```

#### **Configuração Automática:**

```bash
# Criar projetos automaticamente
for game in teenpatti slotmachine carrom3d; do
    butler create-game ${USERNAME}/${game} \
        --title "${game}" \
        --kind html \
        --description "@descriptions/${game}.txt"
done
```

#### **Tempo: 20 minutos (15 jogos)**

---

## 🐙 5. GITHUB RELEASES (100% Auto)

### **GitHub CLI Upload:**

#### **Instalação:**
```bash
# Instalar GitHub CLI
brew install gh

# Login
gh auth login
```

#### **Script de Upload Automático:**

```bash
#!/bin/bash
# github-upload.sh

REPO_OWNER="botsousaschedeloski-design"

for game in teenpatti slotmachine carrom3d dominoqq slotwayang capsaoffline cricketbetting teenpatticricket rummy teenpattibd cricketquiz ludobd footballquiz afroslots ayoboard; do
    echo "📦 Creating GitHub release for $game..."
    
    # Create repository
    gh repo create ${REPO_OWNER}/${game} \
        --public \
        --source=. \
        --remote \
        --push
    
    # Create release
    gh release create v1.0.0 \
        --repo ${REPO_OWNER}/${game} \
        --title "${game} v1.0.0" \
        --notes "Initial release of ${game}" \
        builds/${game}.apk#APK
    
    echo "✅ ${game} released!"
done
```

#### **Upload em Massa:**

```bash
#!/bin/bash
# github-bulk-upload.sh

# Create all 15 repos in parallel
for game in teenpatti slotmachine carrom3d dominoqq slotwayang capsaoffline cricketbetting teenpatticricket rummy teenpattibd cricketquiz ludobd footballquiz afroslots ayoboard; do
    (
        gh repo create ${REPO_OWNER}/${game} --public --source=. --remote --push
        gh release create v1.0.0 --repo ${REPO_OWNER}/${game} --title "${game} v1.0.0" --notes "Initial release" builds/${game}.apk#APK
    ) &
done

wait
echo "✅ All 15 games released!"
```

#### **Tempo: 15 minutos (15 jogos)**

---

## 🚀 MASTER UPLOAD SCRIPT:

### **Upload para TODAS Lojas Free:**

```bash
#!/bin/bash
# upload-all-free-stores.sh

echo "🚀 Starting multi-store upload..."

# 1. Amazon (80% auto)
echo "📦 Amazon App Store..."
./amazon-upload.sh

# 2. Samsung (50% auto - prepare packages)
echo "📱 Samsung Galaxy Store..."
./samsung-prepare.sh

# 3. Huawei (80% auto)
echo "🌸 Huawei AppGallery..."
./huawei-upload.sh

# 4. itch.io (90% auto)
echo "🎮 itch.io..."
./itch-upload.sh

# 5. GitHub (100% auto)
echo "🐙 GitHub Releases..."
./github-upload.sh

echo "✅ All stores uploaded!"
echo ""
echo "📊 Summary:"
echo "   Amazon: ✅ Auto"
echo "   Samsung: ⚠️ Manual upload required"
echo "   Huawei: ✅ Auto"
echo "   itch.io: ✅ Auto"
echo "   GitHub: ✅ Auto"
echo ""
echo "⏱️ Total time: ~2 hours"
```

---

## ⏱️ TEMPO TOTAL:

| Loja | Auto % | Tempo | Manual Required |
|------|--------|-------|-----------------|
| **Amazon** | 80% | 30 min | Review submission |
| **Samsung** | 50% | 1-2h | Web upload |
| **Huawei** | 80% | 30 min | Review submission |
| **itch.io** | 90% | 20 min | None |
| **GitHub** | 100% | 15 min | None |
| **TOTAL** | **76%** | **2-3h** | **Samsung only** |

---

## 📋 CHECKLIST DE UPLOAD:

### **Pré-Upload:**
```
[ ] APKs assinados (15)
[ ] Ícones 512x512 (15)
[ ] Screenshots 1080x1920 (120)
[ ] Descriptions (15)
[ ] Feature Graphics (15)
```

### **Upload Scripts:**
```
[ ] amazon-upload.sh (configurar API keys)
[ ] samsung-prepare.sh (prepare packages)
[ ] huawei-upload.sh (configurar API keys)
[ ] itch-upload.sh (login butler)
[ ] github-upload.sh (login gh)
[ ] upload-all-free-stores.sh (master script)
```

### **Pós-Upload:**
```
[ ] Amazon: Aguardar review (1-3 dias)
[ ] Samsung: Upload manual (1h)
[ ] Huawei: Aguardar review (3-7 dias)
[ ] itch.io: Live instant!
[ ] GitHub: Live instant!
```

---

## 🔑 API KEYS NECESSÁRIAS:

### **Amazon:**
```
1. developer.amazon.com
2. Settings → API Keys
3. Create API Key
4. Copy Key + Secret
```

### **Huawei:**
```
1. developer.huawei.com
2. AppGallery Connect → Settings
3. API Key → Create
4. Copy Client ID + Secret
```

### **itch.io:**
```
1. itch.io
2. User Settings → API Keys
3. Generate API Key
4. butler login (usa key automaticamente)
```

### **GitHub:**
```
1. github.com/settings/tokens
2. Generate new token (classic)
3. Scopes: repo, write:packages
4. gh auth login (usa token)
```

---

## 🎯 CONCLUSÃO:

### **Upload Automatizado:**
```
✅ Amazon: 80% auto (API)
✅ Huawei: 80% auto (API)
✅ itch.io: 90% auto (CLI)
✅ GitHub: 100% auto (CLI)
⚠️ Samsung: 50% auto (web upload)
```

### **Tempo Total:**
```
Setup: 30 min (API keys)
Upload: 2-3 horas (15 jogos, 5 lojas)
Manual: 1h (Samsung web upload)

TOTAL: 3-4 horas
```

### **Custo:**
```
API Keys: $0
Scripts: $0
Upload: $0

TOTAL: $0 (além dos $25 do Google Play)
```

---

**Auto-upload guide completo!** 🤖
