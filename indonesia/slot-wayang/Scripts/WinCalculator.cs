using UnityEngine;
using System.Collections.Generic;

namespace SlotWayang
{
    /// <summary>
    /// Calcula vitórias do slot
    /// </summary>
    public class WinCalculator : MonoBehaviour
    {
        [Header("Symbol Values")]
        public int gununganValue = 500;
        public int pandawaValue = 200;
        public int kurawaValue = 150;
        public int heroValue = 100;
        public int villainValue = 75;
        public int gamelanValue = 50;
        public int kerisValue = 25;
        
        [Header("Multipliers")]
        public int match3Multiplier = 1;
        public int match4Multiplier = 5;
        public int match5Multiplier = 10;
        
        /// <summary>
        /// Calcula vitória total
        /// </summary>
        public int CalculateWin(List<Payline> winningLines, int bet)
        {
            int totalWin = 0;
            
            foreach (var payline in winningLines)
            {
                int lineWin = CalculateLineWin(payline, bet);
                totalWin += lineWin;
            }
            
            return totalWin;
        }
        
        /// <summary>
        /// Calcula vitória por linha
        /// </summary>
        int CalculateLineWin(Payline payline, int bet)
        {
            int baseValue = GetSymbolValue(Symbol.SymbolType.Keris);
            int multiplier = payline.multiplier * match3Multiplier;
            
            return bet * baseValue * multiplier / 10;
        }
        
        /// <summary>
        /// Retorna valor do símbolo
        /// </summary>
        int GetSymbolValue(Symbol.SymbolType type)
        {
            switch (type)
            {
                case Symbol.SymbolType.Gunungan: return gununganValue;
                case Symbol.SymbolType.Pandawa: return pandawaValue;
                case Symbol.SymbolType.Kurawa: return kurawaValue;
                case Symbol.SymbolType.WayangHero: return heroValue;
                case Symbol.SymbolType.WayangVillain: return villainValue;
                case Symbol.SymbolType.Gamelan: return gamelanValue;
                case Symbol.SymbolType.Keris: return kerisValue;
                default: return 25;
            }
        }
    }
}
