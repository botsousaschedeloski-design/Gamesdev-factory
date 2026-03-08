using UnityEngine;

namespace SlotWayang
{
    /// <summary>
    /// Slot Machine com tema Wayang
    /// Reuse 90% do Slot Machine original
    /// </summary>
    public class SlotMachine : MonoBehaviour
    {
        [Header("Game Config")]
        public int reels = 5;
        public int rows = 3;
        public int paylines = 20;
        
        [Header("Betting")]
        public int minBet = 100;
        public int maxBet = 10000;
        public int currentBet = 100;
        
        [Header("Credits")]
        public int credits = 10000;
        public int lastWin = 0;
        
        [Header("References")]
        public ReelController[] reelControllers;
        public PaylineChecker paylineChecker;
        public WinCalculator winCalculator;
        
        [Header("Wayang Theme")]
        public WayangTheme wayangTheme;
        public bool inBonusGame;
        public int freeSpinsRemaining;
        
        [Header("UI")]
        public GameObject spinButton;
        public GameObject autoSpinButton;
        public GameObject bonusPanel;
        
        [Header("Audio")]
        public AudioClip spinSound;
        public AudioClip winSound;
        public AudioClip bonusSound;
        
        private bool isSpinning;
        private bool autoSpinEnabled;
        
        void Start()
        {
            InitializeGame();
        }
        
        /// <summary>
        /// Inicializa o jogo
        /// </summary>
        void InitializeGame()
        {
            credits = 10000;
            currentBet = minBet;
            isSpinning = false;
            inBonusGame = false;
            freeSpinsRemaining = 0;
            
            // Initialize reels
            foreach (var reel in reelControllers)
            {
                reel.Initialize();
            }
            
            UpdateUI();
        }
        
        /// <summary>
        /// Player clica em spin
        /// </summary>
        public void Spin()
        {
            if (isSpinning || credits < currentBet) return;
            
            // Deduz bet
            credits -= currentBet;
            isSpinning = true;
            
            // Toca som
            if (spinSound != null)
                AudioSource.PlayClipAtPoint(spinSound, Camera.main.transform.position);
            
            // Spin reels
            foreach (var reel in reelControllers)
            {
                reel.Spin();
            }
            
            // Check win after reels stop
            Invoke(nameof(CheckWin), 2f);
        }
        
        /// <summary>
        /// Verifica vitória
        /// </summary>
        void CheckWin()
        {
            // Get symbols from reels
            Symbol[,] grid = GetSymbolGrid();
            
            // Check paylines
            var winningLines = paylineChecker.CheckPaylines(grid);
            
            // Calculate win
            lastWin = winCalculator.CalculateWin(winningLines, currentBet);
            
            // Check for scatter (free spins)
            int scatterCount = CountScatters(grid);
            if (scatterCount >= 3 && !inBonusGame)
            {
                TriggerFreeSpins(scatterCount);
            }
            
            // Add win
            if (lastWin > 0)
            {
                credits += lastWin;
                
                if (winSound != null)
                    AudioSource.PlayClipAtPoint(winSound, Camera.main.transform.position);
            }
            
            isSpinning = false;
            UpdateUI();
            
            // Auto spin
            if (autoSpinEnabled && credits >= currentBet)
            {
                Invoke(nameof(Spin), 1f);
            }
        }
        
        /// <summary>
        /// Retorna grid de símbolos
        /// </summary>
        Symbol[,] GetSymbolGrid()
        {
            Symbol[,] grid = new Symbol[reels, rows];
            
            for (int i = 0; i < reels; i++)
            {
                var visibleSymbols = reelControllers[i].GetVisibleSymbols();
                for (int j = 0; j < rows; j++)
                {
                    grid[i, j] = visibleSymbols[j];
                }
            }
            
            return grid;
        }
        
        /// <summary>
        /// Conta scatters
        /// </summary>
        int CountScatters(Symbol[,] grid)
        {
            int count = 0;
            
            for (int i = 0; i < reels; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    if (grid[i, j].isScatter)
                    {
                        count++;
                    }
                }
            }
            
            return count;
        }
        
        /// <summary>
        /// Ativa free spins
        /// </summary>
        void TriggerFreeSpins(int scatterCount)
        {
            freeSpinsRemaining = (scatterCount - 2) * 10;
            inBonusGame = true;
            
            if (bonusSound != null)
                AudioSource.PlayClipAtPoint(bonusSound, Camera.main.transform.position);
            
            if (bonusPanel != null)
                bonusPanel.SetActive(true);
        }
        
        /// <summary>
        /// Free spin automático
        /// </summary>
        public void FreeSpin()
        {
            if (freeSpinsRemaining > 0)
            {
                freeSpinsRemaining--;
                Spin();
                
                if (freeSpinsRemaining == 0)
                {
                    inBonusGame = false;
                    if (bonusPanel != null)
                        bonusPanel.SetActive(false);
                }
            }
        }
        
        /// <summary>
        /// Aumenta bet
        /// </summary>
        public void IncreaseBet()
        {
            if (currentBet < maxBet)
            {
                currentBet *= 2;
                if (currentBet > maxBet) currentBet = maxBet;
                UpdateUI();
            }
        }
        
        /// <summary>
        /// Diminui bet
        /// </summary>
        public void DecreaseBet()
        {
            if (currentBet > minBet)
            {
                currentBet /= 2;
                if (currentBet < minBet) currentBet = minBet;
                UpdateUI();
            }
        }
        
        /// <summary>
        /// Toggle auto spin
        /// </summary>
        public void ToggleAutoSpin()
        {
            autoSpinEnabled = !autoSpinEnabled;
            
            if (autoSpinEnabled && !isSpinning)
            {
                Spin();
            }
        }
        
        /// <summary>
        /// Max bet
        /// </summary>
        public void MaxBet()
        {
            currentBet = maxBet;
            UpdateUI();
        }
        
        /// <summary>
        /// Atualiza UI
        /// </summary>
        void UpdateUI()
        {
            // Update UI elements (implementar)
        }
        
        /// <summary>
        /// Salva progresso
        /// </summary>
        public void SaveGame()
        {
            PlayerPrefs.SetInt("WayangSlot_Credits", credits);
            PlayerPrefs.SetInt("WayangSlot_LastWin", lastWin);
            PlayerPrefs.Save();
        }
        
        /// <summary>
        /// Carrega progresso
        /// </summary>
        public void LoadGame()
        {
            credits = PlayerPrefs.GetInt("WayangSlot_Credits", 10000);
            lastWin = PlayerPrefs.GetInt("WayangSlot_LastWin", 0);
            UpdateUI();
        }
    }
}
