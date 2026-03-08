using UnityEngine;

namespace CricketBetting
{
    /// <summary>
    /// Sistema de apostas
    /// </summary>
    public class BettingSystem : MonoBehaviour
    {
        [Header("Bankroll")]
        public int playerBankroll = 10000;
        public int currentBet;
        
        [Header("Bet Types")]
        public enum BetType { MatchWinner, TopBatsman, TopBowler, TotalRuns }
        public BetType currentBetType;
        
        [Header("Odds")]
        public float team1Odds;
        public float team2Odds;
        
        [Header("State")]
        public bool hasActiveBet;
        public int lastWin;
        
        /// <summary>
        /// Coloca aposta
        /// </summary>
        public void PlaceBet(BetType betType, int amount, int selection)
        {
            if (amount > playerBankroll) return;
            
            playerBankroll -= amount;
            currentBet = amount;
            currentBetType = betType;
            hasActiveBet = true;
        }
        
        /// <summary>
        /// Resultado da aposta
        /// </summary>
        public void SettleBet(bool won)
        {
            if (won)
            {
                int winnings = Mathf.FloorToInt(currentBet * team1Odds);
                playerBankroll += winnings;
                lastWin = winnings;
            }
            
            hasActiveBet = false;
            currentBet = 0;
        }
        
        /// <summary>
        /// Salva progresso
        /// </summary>
        public void SaveProgress()
        {
            PlayerPrefs.SetInt("CricketBetting_Bankroll", playerBankroll);
            PlayerPrefs.Save();
        }
        
        /// <summary>
        /// Carrega progresso
        /// </summary>
        public void LoadProgress()
        {
            playerBankroll = PlayerPrefs.GetInt("CricketBetting_Bankroll", 10000);
        }
    }
}
