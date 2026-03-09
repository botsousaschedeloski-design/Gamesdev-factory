# 🔑 AdMob Setup Guide

**Configuração completa do AdMob para 15 jogos**

---

## 📋 PASSO A PASSO:

### **1. Criar Conta AdMob (5 min)**

```
1. Acesse: https://admob.google.com
2. Click "Get Started"
3. Login com conta Google
4. Preencha:
   - Nome: Afonso FXtrade
   - Email: botsousaschedeloski@gmail.com
   - País: Brasil
5. Aceite termos
6. ✅ Conta criada!
```

---

### **2. Criar Apps (15 min)**

```
Para CADA um dos 15 jogos:

1. AdMob → Apps → Add App
2. Platform: Android
3. App Name: [Nome do Jogo]
4. Category: Games
5. Click "Create"
6. Copie "App ID"
7. Repita para 15 jogos
```

**App IDs (Exemplo):**
```
✅ teenpatti: ca-app-pub-XXXXXXXXXXXXXXXX~YYYYYYYYYY
✅ slotmachine: ca-app-pub-XXXXXXXXXXXXXXXX~YYYYYYYYYY
✅ carrom3d: ca-app-pub-XXXXXXXXXXXXXXXX~YYYYYYYYYY
... (15 total)
```

---

### **3. Criar Ad Units (30 min)**

```
Para CADA jogo, criar 3 ad units:

1. Banner Ad
   - Name: [Jogo]_Banner
   - Ad size: 320x50 (Smart Banner)
   - Copy Ad Unit ID

2. Interstitial Ad
   - Name: [Jogo]_Interstitial
   - Ad size: Full Screen
   - Copy Ad Unit ID

3. Rewarded Video
   - Name: [Jogo]_Rewarded
   - Ad size: Full Screen
   - Copy Ad Unit ID
```

**Total: 45 Ad Units (15 jogos × 3)**

---

### **4. Configurar Jogos (30 min)**

```
Para CADA jogo:

1. Abrir script AdMobManager.cs
2. Substituir App ID
3. Substituir Ad Unit IDs
4. Build APK
5. Testar ads
```

**Código Exemplo:**
```csharp
public class AdMobManager : MonoBehaviour
{
    // Substituir com SEUS IDs
    public string appId = "ca-app-pub-XXXXXXXXXXXXXXXX~YYYYYYYYYY";
    public string bannerId = "ca-app-pub-XXXXXXXXXXXXXXXX/YYYYYYYYYY";
    public string interstitialId = "ca-app-pub-XXXXXXXXXXXXXXXX/YYYYYYYYYY";
    public string rewardedId = "ca-app-pub-XXXXXXXXXXXXXXXX/YYYYYYYYYY";
}
```

---

### **5. Testar Ads (15 min)**

```
1. Build APK de teste
2. Instalar no dispositivo
3. Verificar:
   ✅ Banner aparece
   ✅ Interstitial aparece
   ✅ Rewarded video funciona
4. Testar em 3-5 jogos
```

---

## 💰 CONFIGURAÇÃO DE PAGAMENTO:

### **1. Adicionar Conta Bancária**

```
1. AdMob → Payments → Add Payment Info
2. Preencha:
   - Nome: Afonso Sousa
   - Endereço: [Seu endereço]
   - Banco: [Seu banco]
   - Conta: [Sua conta]
   - SWIFT: [Código SWIFT]
3. Threshold: $100 (padrão)
4. ✅ Configurado!
```

### **2. PIN Verification**

```
1. Google envia carta por correio
2. Aguarde 2-4 semanas
3. Insira PIN no AdMob
4. ✅ Verificado!
```

---

## 📊 PROJEÇÃO DE RECEITA:

### **Por Jogo:**
```
1,000 downloads/dia
× 5 ads/user/day
× $0.002 per ad
= $10/dia por jogo
```

### **15 Jogos:**
```
$10 × 15 jogos = $150/dia
= $4,500/mês
```

### **Cenários:**
```
Conservador: $1,500/mês
Moderado: $4,500/mês
Otimista: $9,000/mês
```

---

## 🎯 MELHORES PRÁTICAS:

### **Banner Ads:**
```
✅ Mostrar no menu principal
✅ Não mostrar durante gameplay
✅ Refresh a cada 60s
```

### **Interstitial Ads:**
```
✅ Mostrar entre jogos
✅ Máximo 1 por 3 minutos
✅ Não mostrar no tutorial
```

### **Rewarded Video:**
```
✅ Oferecer recompensas boas
✅ 2,000-5,000 moedas
✅ Máximo 5 por dia
```

---

## ⚠️ O QUE NÃO FAZER:

```
❌ Click nos próprios ads
❌ Incentivar clicks
❌ Esconder botão de fechar
❌ Muitos ads (usuário desinstala)
❌ Ads durante gameplay intensa
```

---

## 📞 SUPORTE ADMOB:

```
Help Center: https://support.google.com/admob
Email: admob-support@google.com
Forum: https://support.google.com/admob/community
```

---

## ✅ CHECKLIST:

```
[ ] 1. Conta AdMob criada
[ ] 2. 15 Apps criados
[ ] 3. 45 Ad Units criadas
[ ] 4. IDs copiados
[ ] 5. Scripts atualizados
[ ] 6. APKs testados
[ ] 7. Conta bancária adicionada
[ ] 8. PIN verificado
[ ] 9. Primeiro pagamento recebido
```

---

**Guia AdMob completo!** 💰
