using UnityEngine;
using System.Collections.Generic;

namespace CapsaOffline
{
    /// <summary>
    /// Representa uma mão de Capsa (3 partes: Front, Middle, Back)
    /// </summary>
    [System.Serializable]
    public class CapsaHand
    {
        public List<Card> frontHand = new List<Card>();   // 3 cartas
        public List<Card> middleHand = new List<Card>();  // 5 cartas
        public List<Card> backHand = new List<Card>();    // 5 cartas
        
        [Header("Arrangement")]
        public bool isArranged;
        public bool isValid;
        
        /// <summary>
        /// Recebe 13 cartas
        /// </summary>
        public void ReceiveCards(List<Card> cards)
        {
            frontHand.Clear();
            middleHand.Clear();
            backHand.Clear();
            
            // Adiciona todas as cartas (player vai organizar)
            frontHand.AddRange(cards.GetRange(0, 3));
            middleHand.AddRange(cards.GetRange(3, 8));
            backHand.AddRange(cards.GetRange(11, 2));
        }
        
        /// <summary>
        /// Organiza mãos (AI usa isso)
        /// </summary>
        public void ArrangeHand()
        {
            // Sort by value
            frontHand.Sort((a, b) => b.value.CompareTo(a.value));
            middleHand.Sort((a, b) => b.value.CompareTo(a.value));
            backHand.Sort((a, b) => b.value.CompareTo(a.value));
            
            // Take best 5 for back, next 5 for middle, rest for front
            // Implement sorting logic
        }
        
        /// <summary>
        /// Verifica se arranjo é válido (Back > Middle > Front)
        /// </summary>
        public bool IsValidArrangement()
        {
            // Back hand deve ser maior que Middle
            // Middle hand deve ser maior que Front
            return true; // Placeholder
        }
        
        /// <summary>
        /// Conta pontos da mão
        /// </summary>
        public int CountPoints()
        {
            int points = 0;
            
            foreach (var card in frontHand) points += card.value;
            foreach (var card in middleHand) points += card.value;
            foreach (var card in backHand) points += card.value;
            
            return points;
        }
        
        /// <summary>
        /// Limpa mão
        /// </summary>
        public void Clear()
        {
            frontHand.Clear();
            middleHand.Clear();
            backHand.Clear();
            isArranged = false;
            isValid = false;
        }
    }
    
    /// <summary>
    /// Representa uma carta
    /// </summary>
    [System.Serializable]
    public class Card
    {
        public enum Suit { Hearts, Diamonds, Clubs, Spades }
        public enum Rank { Two = 2, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace }
        
        public Suit suit;
        public Rank rank;
        public int value;
        
        public Card(Suit suit, Rank rank)
        {
            this.suit = suit;
            this.rank = rank;
            this.value = (int)rank;
        }
    }
}
