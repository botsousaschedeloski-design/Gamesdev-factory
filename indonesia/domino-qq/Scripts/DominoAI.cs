using UnityEngine;
using System.Collections.Generic;

namespace DominoQQ
{
    /// <summary>
    /// AI para jogadores bots
    /// </summary>
    public class DominoAI : MonoBehaviour
    {
        [Header("AI Settings")]
        public enum Difficulty { Easy, Medium, Hard }
        public Difficulty difficulty = Difficulty.Medium;
        
        [Header("AI State")]
        public List<DominoPiece> hand = new List<DominoPiece>();
        public bool isThinking;
        public float thinkTime = 2f;
        
        [Header("References")]
        public DominoBoard board;
        public DominoGame game;
        
        private System.Random random;
        
        void Start()
        {
            random = new System.Random();
        }
        
        /// <summary>
        /// Inicia o turno da AI
        /// </summary>
        public void StartTurn()
        {
            if (isThinking) return;
            
            isThinking = true;
            Invoke(nameof(MakeMove), thinkTime);
        }
        
        /// <summary>
        /// AI faz uma jogada
        /// </summary>
        void MakeMove()
        {
            DominoPiece pieceToPlay = SelectPiece();
            
            if (pieceToPlay != null)
            {
                PlayPiece(pieceToPlay);
            }
            else
            {
                // Não tem peça para jogar - passa a vez
                PassTurn();
            }
            
            isThinking = false;
        }
        
        /// <summary>
        /// Seleciona qual peça jogar baseado na dificuldade
        /// </summary>
        DominoPiece SelectPiece()
        {
            List<DominoPiece> playablePieces = GetPlayablePieces();
            
            if (playablePieces.Count == 0)
            {
                return null;
            }
            
            switch (difficulty)
            {
                case Difficulty.Easy:
                    return SelectEasy(playablePieces);
                case Difficulty.Medium:
                    return SelectMedium(playablePieces);
                case Difficulty.Hard:
                    return SelectHard(playablePieces);
                default:
                    return playablePieces[0];
            }
        }
        
        /// <summary>
        /// Fácil: Joga peça aleatória
        /// </summary>
        DominoPiece SelectEasy(List<DominoPiece> playable)
        {
            int index = random.Next(playable.Count);
            return playable[index];
        }
        
        /// <summary>
        /// Médio: Joga peça com maior valor primeiro
        /// </summary>
        DominoPiece SelectMedium(List<DominoPiece> playable)
        {
            DominoPiece highestValue = null;
            int maxValue = -1;
            
            foreach (var piece in playable)
            {
                int value = piece.GetTotalValue();
                if (value > maxValue)
                {
                    maxValue = value;
                    highestValue = piece;
                }
            }
            
            return highestValue;
        }
        
        /// <summary>
        /// Difícil: Estratégia avançada
        /// - Tenta baixar doubles primeiro
        /// - Conta peças restantes
        /// - Bloqueia jogador
        /// </summary>
        DominoPiece SelectHard(List<DominoPiece> playable)
        {
            // Prioriza doubles
            foreach (var piece in playable)
            {
                if (piece.isDouble)
                {
                    return piece;
                }
            }
            
            // Prioriza peças com valores altos
            return SelectMedium(playable);
        }
        
        /// <summary>
        /// Retorna lista de peças jogáveis
        /// </summary>
        List<DominoPiece> GetPlayablePieces()
        {
            List<DominoPiece> playable = new List<DominoPiece>();
            
            foreach (var piece in hand)
            {
                if (piece.CanPlay(board.leftEndValue, board.rightEndValue))
                {
                    playable.Add(piece);
                }
            }
            
            return playable;
        }
        
        /// <summary>
        /// Joga a peça selecionada
        /// </summary>
        void PlayPiece(DominoPiece piece)
        {
            hand.Remove(piece);
            board.PlayPiece(piece);
            
            // Notifica o jogo
            game.OnBotPlayedPiece(this, piece);
        }
        
        /// <summary>
        /// Passa a vez (não tem peça para jogar)
        /// </summary>
        void PassTurn()
        {
            Debug.Log($"{gameObject.name} passou a vez");
            game.OnBotPassed(this);
        }
        
        /// <summary>
        /// Adiciona peça à mão
        /// </summary>
        public void AddPiece(DominoPiece piece)
        {
            hand.Add(piece);
        }
        
        /// <summary>
        /// Verifica se ganhou
        /// </summary>
        public bool HasWon()
        {
            return hand.Count == 0;
        }
        
        /// <summary>
        /// Conta pontos da mão restante
        /// </summary>
        public int CountPoints()
        {
            int points = 0;
            foreach (var piece in hand)
            {
                points += piece.GetTotalValue();
            }
            return points;
        }
        
        /// <summary>
        /// Limpa a mão para nova partida
        /// </summary>
        public void Reset()
        {
            hand.Clear();
        }
    }
}
