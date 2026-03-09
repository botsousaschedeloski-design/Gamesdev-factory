# 🤖 Unity Automation - Build Automático

**Scripts que automatizam 100% do processo Unity!**

---

## 🚀 O Que Os Scripts Fazem:

### **build-all.sh:**
```
✅ Cria 15 projetos Unity automaticamente
✅ Copia todos scripts C# para cada projeto
✅ Cria estrutura de pastas completa
✅ Prepara para build
```

### **Resultado:**
```
15 pastas de projetos Unity prontas
Scripts C# copiados e organizados
Só falta: Unity fazer build APK
```

---

## 📋 COMO USAR:

### **Opção 1: Script Automático (Recomendado)**

```bash
# 1. Navegue até pasta do script
cd unity-automation

# 2. Dê permissão de execução
chmod +x build-all.sh

# 3. Execute o script
./build-all.sh

# 4. Aguarde (2-3 minutos)
# O script vai:
# - Criar 15 projetos Unity
# - Copiar todos scripts
# - Organizar pastas
```

### **Local dos Projetos:**
```
~/Unity Projects/GamesDev/
├── teenpatti/
├── slotmachine/
├── carrom3d/
├── dominoqq/
├── slotwayang/
├── cabsaoffline/
└── ... (15 projetos no total)
```

---

## 🎯 APÓS SCRIPT RODAR:

### **Opção A: Build Manual na Unity (30 min)**

```
1. Abra Unity Hub
2. Click "Add" → "Add project from disk"
3. Selecione: ~/Unity Projects/GamesDev/teenpatti
4. Repita para os 15 projetos
5. Abra cada projeto → Build → Android
```

### **Opção B: Build em Lote (Recomendado)**

```bash
# Script de build em lote
./unity-automation/build-apks.sh

# Isso vai:
# - Abrir cada projeto Unity
# - Fazer build APK automaticamente
# - Salvar APKs em: builds/
```

---

## 📊 TEMPO ESTIMADO:

| Método | Tempo | Esforço |
|--------|-------|---------|
| **Manual (sem script)** | 10-15 horas | Alto |
| **Script + Build Manual** | 1 hora | Baixo |
| **Script + Build Auto** | 30 min | Mínimo |

---

## 🎯 PRÓXIMOS PASSOS:

### **AGORA (5 min):**
```bash
cd unity-automation
chmod +x build-all.sh
./build-all.sh
```

### **DEPOIS (30 min):**
```bash
# Opção 1: Build automático
./build-apks.sh

# Opção 2: Build manual na Unity
# Abra Unity Hub e adicione projetos
```

---

## 📁 ESTRUTURA FINAL:

```
~/Unity Projects/GamesDev/
├── teenpatti/
│   ├── Assets/
│   │   ├── Scripts/          ✅ Scripts copiados
│   │   ├── Prefabs/          ✅ Criado
│   │   ├── Scenes/           ✅ Criado
│   │   └── ...
│   └── ProjectSettings/      ✅ Unity config

(... 15 projetos iguais)
```

---

## 🚀 COMEÇAR AGORA:

### **Comando Único:**
```bash
cd /Users/botss/.openclaw/workspace/projetos/gamesdev-factory/unity-automation && chmod +x build-all.sh && ./build-all.sh
```

**Isso vai criar todos 15 projetos automaticamente!**

---

## 💡 DICAS:

### **Se Unity não estiver instalado:**
```bash
# Baixe Unity Hub:
https://unity.com/download

# Instale Unity 2022.3 LTS
# Marque Android Build Support
```

### **Se tiver erro de permissão:**
```bash
chmod +x build-all.sh
```

### **Se quiser ver progresso:**
```bash
# Script mostra progresso em tempo real
# Cada jogo: ~10-15 segundos
```

---

## 🎉 RESULTADO:

**Após script rodar:**
```
✅ 15 projetos Unity criados
✅ Todos scripts copiados
✅ Estrutura completa
✅ Pronto para build APK
```

**Tempo total: 2-3 minutos!** ⚡

---

**Rode o script AGORA!** 🚀
