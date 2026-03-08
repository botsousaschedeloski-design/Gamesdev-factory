using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace SlotWayang
{
    /// <summary>
    /// Controla um reel do slot
    /// </summary>
    public class ReelController : MonoBehaviour
    {
        [Header("Reel Config")]
        public int reelId;
        public float spinDuration = 2f;
        public float stopDelay = 0.2f;
        
        [Header("Symbols")]
        public List<Symbol> availableSymbols;
        public Transform[] symbolPositions;
        
        [Header("State")]
        public bool isSpinning;
        public List<Symbol> currentSymbols;
        
        private RectTransform rectTransform;
        
        void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            currentSymbols = new List<Symbol>();
        }
        
        /// <summary>
        /// Inicializa reel
        /// </summary>
        public void Initialize()
        {
            GenerateRandomSymbols();
        }
        
        /// <summary>
        /// Gera símbolos aleatórios
        /// </summary>
        public void GenerateRandomSymbols()
        {
            currentSymbols.Clear();
            
            for (int i = 0; i < symbolPositions.Length; i++)
            {
                Symbol randomSymbol = GetRandomSymbol();
                currentSymbols.Add(randomSymbol);
            }
        }
        
        /// <summary>
        /// Retorna símbolo aleatório (weighted)
        /// </summary>
        Symbol GetRandomSymbol()
        {
            int rand = Random.Range(0, 100);
            
            // Weighted probabilities
            if (rand < 2) return availableSymbols.Find(s => s.type == Symbol.SymbolType.Gunungan);
            if (rand < 5) return availableSymbols.Find(s => s.type == Symbol.SymbolType.Pandawa);
            if (rand < 10) return availableSymbols.Find(s => s.type == Symbol.SymbolType.Kurawa);
            if (rand < 20) return availableSymbols.Find(s => s.type == Symbol.SymbolType.WayangHero);
            if (rand < 35) return availableSymbols.Find(s => s.type == Symbol.SymbolType.WayangVillain);
            if (rand < 55) return availableSymbols.Find(s => s.type == Symbol.SymbolType.Gamelan);
            return availableSymbols.Find(s => s.type == Symbol.SymbolType.Keris);
        }
        
        /// <summary>
        /// Inicia spin
        /// </summary>
        public IEnumerator Spin()
        {
            isSpinning = true;
            
            // Animate spin
            float elapsed = 0f;
            while (elapsed < spinDuration)
            {
                elapsed += Time.deltaTime;
                GenerateRandomSymbols();
                UpdateSymbolDisplay();
                yield return null;
            }
            
            isSpinning = false;
        }
        
        /// <summary>
        /// Para reel com delay
        /// </summary>
        public IEnumerator StopWithDelay(float delay)
        {
            yield return new WaitForSeconds(delay);
            GenerateRandomSymbols();
            UpdateSymbolDisplay();
        }
        
        /// <summary>
        /// Atualiza display dos símbolos
        /// </summary>
        void UpdateSymbolDisplay()
        {
            // Implementar visual update
        }
        
        /// <summary>
        /// Retorna símbolos visíveis
        /// </summary>
        public List<Symbol> GetVisibleSymbols()
        {
            return currentSymbols.GetRange(0, Mathf.Min(3, currentSymbols.Count));
        }
    }
}
