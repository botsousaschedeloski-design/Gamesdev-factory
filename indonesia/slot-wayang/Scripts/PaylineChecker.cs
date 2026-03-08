using UnityEngine;
using System.Collections.Generic;

namespace SlotWayang
{
    /// <summary>
    /// Verifica paylines vencedoras
    /// </summary>
    public class PaylineChecker : MonoBehaviour
    {
        [Header("Paylines")]
        public List<Payline> paylines;
        
        /// <summary>
        /// Verifica todas as paylines
        /// </summary>
        public List<Payline> CheckPaylines(Symbol[,] grid)
        {
            List<Payline> winningLines = new List<Payline>();
            
            foreach (var payline in paylines)
            {
                if (IsWinningPayline(payline, grid))
                {
                    winningLines.Add(payline);
                }
            }
            
            return winningLines;
        }
        
        /// <summary>
        /// Verifica se payline é vencedora
        /// </summary>
        bool IsWinningPayline(Payline payline, Symbol[,] grid)
        {
            if (payline.positions.Count < 3) return false;
            
            Symbol firstSymbol = GetSymbolAtPosition(grid, payline.positions[0]);
            if (firstSymbol == null) return false;
            
            Symbol.SymbolType matchType = firstSymbol.type;
            int matchCount = 1;
            
            for (int i = 1; i < payline.positions.Count; i++)
            {
                Symbol symbol = GetSymbolAtPosition(grid, payline.positions[i]);
                
                if (symbol == null) return false;
                
                // Wild substitui tudo
                if (symbol.isWild)
                {
                    matchCount++;
                }
                else if (symbol.type == matchType)
                {
                    matchCount++;
                }
                else
                {
                    return false;
                }
            }
            
            return matchCount >= 3;
        }
        
        /// <summary>
        /// Retorna símbolo na posição
        /// </summary>
        Symbol GetSymbolAtPosition(Symbol[,] grid, Vector2Int pos)
        {
            if (pos.x >= 0 && pos.x < grid.GetLength(0) && pos.y >= 0 && pos.y < grid.GetLength(1))
            {
                return grid[pos.x, pos.y];
            }
            return null;
        }
        
        /// <summary>
        /// Inicializa paylines padrão (20 lines)
        /// </summary>
        public void InitializeDefaultPaylines()
        {
            paylines = new List<Payline>();
            
            // 20 paylines padrão para 5x3 grid
            // Implementar todas as 20 linhas
        }
    }
    
    /// <summary>
    /// Representa uma payline
    /// </summary>
    [System.Serializable]
    public class Payline
    {
        public List<Vector2Int> positions;
        public int multiplier;
    }
}
