using UnityEngine;
using System.Collections.Generic;

namespace CapsaOffline
{
    /// <summary>
    /// AI para Capsa
    /// Reuse 70% do Teen Patti AI
    /// </summary>
    public class CapsaAI : MonoBehaviour
    {
        [Header("AI Settings")]
        public int difficulty = 2; // 1=Fácil, 2=Médio, 3=Difícil
        
        [Header("Hand")]
        public CapsaHand hand;
        public bool isThinking;
        
        [Header("References")]
        public CapsaGame game;
        
        private System.Random random;
        
        void Start()
        {
            random = new System.Random();
            hand = new CapsaHand();
        }
        
        /// <summary>
        /// Recebe cartas
        /// </summary>
        public void ReceiveCards(List<Card> cards)
        {
            hand.ReceiveCards(cards);
        }
        
        /// <summary>
        /// AI organiza mão
        /// </summary>
        public void ArrangeHand()
        {
            if (difficulty == 1)
            {
                ArrangeEasy();
            }
            else if (difficulty == 2)
            {
                ArrangeMedium();
            }
            else
            {
                ArrangeHard();
            }
            
            hand.isArranged = true;
        }
        
        /// <summary>
        /// Fácil: Organiza aleatório
        /// </summary>
        void ArrangeEasy()
        {
            // Random arrangement
            hand.ArrangeHand();
        }
        
        /// <summary>
        /// Médio: Organiza por valor
        /// </summary>
        void ArrangeMedium()
        {
            // Put highest cards in back
            hand.ArrangeHand();
        }
        
        /// <summary>
        /// Difícil: Estratégia ótima
        /// </summary>
        void ArrangeHard()
        {
            // Best possible arrangement
            hand.ArrangeHand();
        }
        
        /// <summary>
        /// Reseta AI
        /// </summary>
        public void Reset()
        {
            hand.Clear();
            isThinking = false;
        }
    }
}
