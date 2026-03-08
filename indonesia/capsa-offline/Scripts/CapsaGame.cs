using UnityEngine;
using System.Collections.Generic;

namespace CapsaOffline
{
    /// <summary>
    /// Gerenciador principal do Capsa (Chinese Poker)
    /// Reuse 75% do Teen Patti
    /// </summary>
    public class CapsaGame : MonoBehaviour
    {
        [Header("Game Setup")]
        public int numberOfBots = 3;
        public int difficulty = 2; // 1=Fácil, 2=Médio, 3=Difícil
        
        [Header("References")]
        public CardDeck deck;
        public CapsaHand playerHand;
        public CapsaAI[] bots;
        
        [Header("Game State")]
        public bool isGameActive;
        public int currentPlayer;
        public List<CapsaHand> allHands = new List<CapsaHand>();
        
        [Header("Scoring")]
        public int[] handScores;
        public int winnerIndex;
        
        [Header("UI")]
        public GameObject arrangePanel;
        public GameObject comparePanel;
        public GameObject resultPanel;
        
        void Start()
        {
            InitializeGame();
        }
        
        /// <summary>
        /// Inicializa nova partida
        /// </summary>
        public void InitializeGame()
        {
            // Shuffle deck
            deck.Shuffle();
            
            // Deal 13 cards to each player
            DealCards();
            
            // Player arranges hand
            isGameActive = true;
            currentPlayer = 0;
            
            arrangePanel.SetActive(true);
        }
        
        /// <summary>
        /// Distribui cartas
        /// </summary>
        void DealCards()
        {
            allHands.Clear();
            
            // Player hand
            playerHand.ReceiveCards(deck.DealCards(13));
            allHands.Add(playerHand);
            
            // Bot hands
            for (int i = 0; i < numberOfBots; i++)
            {
                bots[i].Reset();
                bots[i].ReceiveCards(deck.DealCards(13));
                allHands.Add(bots[i].hand);
            }
        }
        
        /// <summary>
        /// Player finalizou de organizar mão
        /// </summary>
        public void PlayerFinishedArranging()
        {
            arrangePanel.SetActive(false);
            
            // Bots arrange their hands
            ArrangeBotHands();
            
            // Compare hands
            CompareAllHands();
        }
        
        /// <summary>
        /// Bots organizam mãos
        /// </summary>
        void ArrangeBotHands()
        {
            foreach (var bot in bots)
            {
                bot.ArrangeHand();
            }
        }
        
        /// <summary>
        /// Compara todas as mãos
        /// </summary>
        void CompareAllHands()
        {
            handScores = new int[allHands.Count];
            
            // Compare each hand
            for (int i = 0; i < allHands.Count; i++)
            {
                int score = 0;
                
                for (int j = 0; j < allHands.Count; j++)
                {
                    if (i != j)
                    {
                        if (CompareHands(allHands[i], allHands[j]))
                        {
                            score++;
                        }
                    }
                }
                
                handScores[i] = score;
            }
            
            // Determine winner
            DetermineWinner();
            
            // Show results
            ShowResults();
        }
        
        /// <summary>
        /// Compara duas mãos
        /// </summary>
        bool CompareHands(CapsaHand hand1, CapsaHand hand2)
        {
            // Compare back hands (5 cards)
            int backCompare = ComparePokerHands(hand1.backHand, hand2.backHand);
            if (backCompare > 0) return true;
            if (backCompare < 0) return false;
            
            // Compare middle hands (5 cards)
            int midCompare = ComparePokerHands(hand1.middleHand, hand2.middleHand);
            if (midCompare > 0) return true;
            if (midCompare < 0) return false;
            
            // Compare front hands (3 cards)
            int frontCompare = ComparePokerHands(hand1.frontHand, hand2.frontHand);
            return frontCompare > 0;
        }
        
        /// <summary>
        /// Compara mãos de poker (5 cartas)
        /// </summary>
        int ComparePokerHands(List<Card> hand1, List<Card> hand2)
        {
            // Implement poker hand evaluation
            // Royal Flush > Straight Flush > Four of a Kind > Full House > Flush > Straight > Three of a Kind > Two Pair > Pair > High Card
            return 0; // Placeholder
        }
        
        /// <summary>
        /// Determina vencedor
        /// </summary>
        void DetermineWinner()
        {
            int maxScore = -1;
            
            for (int i = 0; i < handScores.Length; i++)
            {
                if (handScores[i] > maxScore)
                {
                    maxScore = handScores[i];
                    winnerIndex = i;
                }
            }
        }
        
        /// <summary>
        /// Mostra resultados
        /// </summary>
        void ShowResults()
        {
            isGameActive = false;
            
            if (resultPanel != null)
            {
                resultPanel.SetActive(true);
            }
        }
        
        /// <summary>
        /// Reinicia partida
        /// </summary>
        public void RestartGame()
        {
            if (resultPanel != null)
                resultPanel.SetActive(false);
            
            InitializeGame();
        }
    }
}
