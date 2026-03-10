# 📊 GamesDev Factory - Dashboard Admin

**Dashboard de Acompanhamento dos 15 Jogos**

---

## 🎯 FUNCIONALIDADES:

### **1. Visão Geral:**
```
✅ Total de Downloads (todos os jogos)
✅ Acessos Diários (últimos 7 dias)
✅ Receita Total (AdMob)
✅ Jogos Ativos (15 jogos)
```

### **2. Por Jogo:**
```
✅ Downloads por jogo
✅ Acessos diários (3x ao dia)
✅ Receita AdMob por jogo
✅ Status (Ativo/Inativo)
```

### **3. Por Região:**
```
✅ Índia (3 jogos)
✅ Indonésia (3 jogos)
✅ Paquistão (3 jogos)
✅ Bangladesh (3 jogos)
✅ Nigéria (3 jogos)
```

---

## 📊 MÉTRICAS PRINCIPAIS:

### **Downloads:**
```
- Total geral
- Por jogo
- Por região
- Últimos 7 dias
```

### **Acessos Diários (3x ao dia):**
```
- Manhã (09:00)
- Tarde (15:00)
- Noite (21:00)
- Total diário
```

### **Receita AdMob:**
```
- Banner impressions
- Interstitial impressions
- Rewarded videos
- Receita por jogo
- eCPM médio
```

---

## 🏗️ ARQUITETURA:

```
┌─────────────────────────────────────────┐
│  Dashboard Admin (React)                │
│  - Visão geral                          │
│  - Métricas por jogo                    │
│  - Gráficos de acesso                   │
│  - Receita AdMob                        │
└─────────────────────────────────────────┘
                    ↓ REST API
┌─────────────────────────────────────────┐
│  Backend (Node.js)                      │
│  - API de métricas                      │
│  - Track de downloads                   │
│  - Track de acessos                     │
│  - Integração AdMob API                 │
└─────────────────────────────────────────┘
                    ↓
┌─────────────────────────────────────────┐
│  Banco de Dados                         │
│  - Jogos (15 jogos)                     │
│  - Downloads (por jogo, por dia)        │
│  - Acessos (3x por dia)                 │
│  - Receita AdMob                        │
└─────────────────────────────────────────┘
```

---

## 📊 MODELO DE DADOS:

### **Game:**
```typescript
interface Game {
  id: string;
  name: string;
  region: 'india' | 'indonesia' | 'pakistan' | 'bangladesh' | 'nigeria';
  packageName: string;
  appId: string; // AdMob App ID
  status: 'active' | 'inactive';
  createdAt: Date;
}
```

### **DailyMetrics:**
```typescript
interface DailyMetrics {
  gameId: string;
  date: string; // YYYY-MM-DD
  
  // Downloads
  downloads: number;
  
  // Acessos (3x ao dia)
  accessesMorning: number;   // 09:00
  accessesAfternoon: number; // 15:00
  accessesEvening: number;   // 21:00
  totalAccesses: number;
  
  // AdMob Revenue
  bannerImpressions: number;
  interstitialImpressions: number;
  rewardedVideos: number;
  revenue: number;
  eCPM: number;
}
```

---

## 📈 API ENDPOINTS:

### **Dashboard:**
```
GET /api/dashboard/overview
  - Retorna visão geral
  - Total downloads, acessos, receita

GET /api/dashboard/games
  - Lista todos os jogos
  - Métricas de cada jogo

GET /api/dashboard/games/:id/metrics
  - Métricas de um jogo específico
  - Últimos 7 dias

GET /api/dashboard/regions/:region
  - Métricas por região
```

### **Tracking:**
```
POST /api/track/download
  - Track download de jogo
  - Body: { gameId, packageName }

POST /api/track/access
  - Track acesso diário
  - Body: { gameId, period: 'morning' | 'afternoon' | 'evening' }
```

---

## 🎨 UI COMPONENTES:

### **1. Overview Cards:**
```
┌─────────────────────────────────────────┐
│  📥 Downloads    │  👥 Acessos         │
│  125,450         │  45,230 (hoje)      │
├─────────────────────────────────────────┤
│  💰 Receita      │  🎮 Jogos Ativos    │
│  $1,234          │  15/15              │
└─────────────────────────────────────────┘
```

### **2. Games Table:**
```
┌─────────────────────────────────────────┐
│ Jogo           │ Downloads │ Acessos   │
├─────────────────────────────────────────┤
│ Teen Patti     │ 25,450    │ 12,340    │
│ Slot Machine   │ 18,230    │ 8,450     │
│ Carrom 3D      │ 15,670    │ 6,780     │
│ ...            │ ...       │ ...       │
└─────────────────────────────────────────┘
```

### **3. Access Chart (7 dias):**
```
📊 Acessos Diários (Últimos 7 Dias)

Seg  │  ████████░░  45,230
Ter  │  ███████░░░  38,450
Qua  │  ████████░░  42,100
Qui  │  █████████░  48,900
Sex  │  ████████░░  45,230
Sáb  │  ██████░░░░  32,450
Dom  │  █████░░░░░  28,900
```

### **4. Revenue by Region:**
```
🇮🇳 Índia:        $456 (35%)
🇮🇩 Indonésia:    $312 (24%)
🇵🇰 Paquistão:    $234 (18%)
🇧🇩 Bangladesh:   $150 (12%)
🇳🇬 Nigéria:      $100 (8%)
```

---

## 🚀 IMPLEMENTAÇÃO:

### **Backend (Node.js):**

```typescript
// routes/dashboard.ts

// Overview metrics
router.get('/overview', async (req, res) => {
  const totalDownloads = await getTotalDownloads();
  const totalAccesses = await getTotalAccesses();
  const totalRevenue = await getTotalRevenue();
  
  res.json({
    downloads: totalDownloads,
    accesses: totalAccesses,
    revenue: totalRevenue,
    activeGames: 15
  });
});

// Track download
router.post('/track/download', async (req, res) => {
  const { gameId, packageName } = req.body;
  
  await trackDownload(gameId, packageName);
  
  res.json({ success: true });
});

// Track access (3x per day)
router.post('/track/access', async (req, res) => {
  const { gameId, period } = req.body;
  // period: 'morning' | 'afternoon' | 'evening'
  
  await trackAccess(gameId, period);
  
  res.json({ success: true });
});
```

### **Frontend (React):**

```typescript
// Dashboard.tsx

const Dashboard = () => {
  const [overview, setOverview] = useState(null);
  const [games, setGames] = useState([]);
  const [accessChart, setAccessChart] = useState([]);
  
  useEffect(() => {
    loadOverview();
    loadGames();
    loadAccessChart();
  }, []);
  
  return (
    <div>
      {/* Overview Cards */}
      <OverviewCards data={overview} />
      
      {/* Games Table */}
      <GamesTable games={games} />
      
      {/* Access Chart */}
      <AccessChart data={accessChart} />
      
      {/* Revenue by Region */}
      <RevenueByRegion />
    </div>
  );
};
```

---

## 📊 TRACKING IMPLEMENTATION:

### **No App (Código Unity):**

```csharp
// AdMobManager.cs

public class AdMobManager : MonoBehaviour
{
    public string gameId;
    
    // Track download (primeiro acesso)
    void Start()
    {
        if (!PlayerPrefs.HasKey("download_tracked"))
        {
            TrackDownload();
            PlayerPrefs.SetInt("download_tracked", 1);
        }
        
        // Track access (3x per day)
        TrackDailyAccess();
    }
    
    void TrackDownload()
    {
        StartCoroutine(SendTracking("download"));
    }
    
    void TrackDailyAccess()
    {
        string period = GetTimePeriod(); // morning, afternoon, evening
        StartCoroutine(SendTracking("access", period));
    }
    
    string GetTimePeriod()
    {
        int hour = DateTime.Now.Hour;
        
        if (hour >= 6 && hour < 12) return "morning";
        if (hour >= 12 && hour < 18) return "afternoon";
        return "evening";
    }
    
    IEnumerator SendTracking(string type, string period = null)
    {
        WWWForm form = new WWWForm();
        form.AddField("gameId", gameId);
        form.AddField("type", type);
        if (period != null) form.AddField("period", period);
        
        UnityWebRequest www = UnityWebRequest.Post(
            "https://api.gamesdev-factory.com/track", 
            form
        );
        
        yield return www.SendWebRequest();
    }
}
```

---

## 📈 DASHBOARD SCREENSHOTS:

### **Tela Principal:**
```
┌─────────────────────────────────────────────────────┐
│  🎮 GamesDev Factory Dashboard                     │
├─────────────────────────────────────────────────────┤
│                                                     │
│  📥 Downloads    👥 Acessos    💰 Receita   🎮 Jogos│
│  125,450         45,230        $1,234      15/15   │
│                                                     │
├─────────────────────────────────────────────────────┤
│                                                     │
│  📊 Acessos Diários (Últimos 7 Dias)               │
│  [Gráfico de barras]                                │
│                                                     │
├─────────────────────────────────────────────────────┤
│                                                     │
│  💰 Receita por Região                             │
│  [Gráfico de pizza]                                 │
│                                                     │
├─────────────────────────────────────────────────────┤
│                                                     │
│  🎮 Jogos por Região                               │
│  [Tabela com downloads e acessos]                   │
│                                                     │
└─────────────────────────────────────────────────────┘
```

---

## 🚀 PRÓXIMOS PASSOS:

### **1. Backend:**
```
[ ] Criar models (Game, DailyMetrics)
[ ] Criar rotas de tracking
[ ] Criar rotas de dashboard
[ ] Integrar com banco de dados
```

### **2. Frontend:**
```
[ ] Criar Dashboard component
[ ] Criar OverviewCards component
[ ] Criar GamesTable component
[ ] Criar AccessChart component
[ ] Criar RevenueByRegion component
```

### **3. Integration:**
```
[ ] Adicionar tracking code em cada jogo Unity
[ ] Testar tracking de downloads
[ ] Testar tracking de acessos
[ ] Testar dashboard
```

---

**Dashboard pronto para implementar!** 🚀
