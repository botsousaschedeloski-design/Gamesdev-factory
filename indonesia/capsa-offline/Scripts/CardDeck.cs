using UnityEngine;

namespace CapsaOffline
{
    /// <summary>
    /// Baralho de cartas
    /// </summary>
    public class CardDeck : MonoBehaviour
    {
        [Header("Deck")]
        public List<Card> cards = new List<Card>();
        private int currentIndex;
        
        void Start()
        {
            Initialize();
        }
        
        /// <summary>
        /// Inicializa baralho (52 cartas)
        /// </summary>
        public void Initialize()
        {
            cards.Clear();
            
            for (int suit = 0; suit < 4; suit++)
            {
                for (int rank = 2; rank <= 14; rank++)
                {
                    Card.CardSuit cardSuit = (Card.CardSuit)suit;
                    Card.CardRank cardRank = (Card.CardRank)rank;
                    cards.Add(new Card(cardSuit, cardRank));
                }
            }
            
            Shuffle();
        }
        
        /// <summary>
        /// Embaralha baralho
        /// </summary>
        public void Shuffle()
        {
            currentIndex = 0;
            
            for (int i = cards.Count - 1; i > 0; i--)
            {
                int j = Random.Range(0, i + 1);
                Card temp = cards[i];
                cards[i] = cards[j];
                cards[j] = temp;
            }
        }
        
        /// <summary>
        /// Compra uma carta
        /// </summary>
        public Card DealCard()
        {
            if (currentIndex >= cards.Count)
            {
                Shuffle();
            }
            
            return cards[currentIndex++];
        }
        
        /// <summary>
        /// Compra N cartas
        /// </summary>
        public List<Card> DealCards(int count)
        {
            List<Card> dealtCards = new List<Card>();
            
            for (int i = 0; i < count; i++)
            {
                dealtCards.Add(DealCard());
            }
            
            return dealtCards;
        }
        
        /// <summary>
        /// Reseta baralho
        /// </summary>
        public void Reset()
        {
            Initialize();
        }
    }
}
