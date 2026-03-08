using UnityEngine;

namespace SlotWayang
{
    /// <summary>
    /// Símbolo do slot (Wayang theme)
    /// </summary>
    [System.Serializable]
    public class Symbol
    {
        public enum SymbolType
        {
            Gunungan,      // Wild
            Pandawa,       // High
            Kurawa,        // High
            WayangHero,    // Mid
            WayangVillain, // Mid
            Gamelan,       // Low
            Keris,         // Low
            Scatter        // Scatter (Kelir)
        }
        
        public SymbolType type;
        public Sprite sprite;
        public int value;        // Valor para 5x
        public bool isWild;
        public bool isScatter;
        
        public Symbol(SymbolType type, int value)
        {
            this.type = type;
            this.value = value;
            this.isWild = (type == SymbolType.Gunungan);
            this.isScatter = (type == SymbolType.Scatter);
        }
    }
}
