using UnityEngine;
using System.Collections.Generic;

namespace DominoQQ
{
    /// <summary>
    /// Gerencia o tabuleiro de dominó e as peças jogadas
    /// </summary>
    public class DominoBoard : MonoBehaviour
    {
        [Header("Board Setup")]
        public Transform boardParent;
        public float pieceSpacing = 1.2f;
        public float rowSpacing = 2f;
        
        [Header("State")]
        public List<DominoPiece> playedPieces = new List<DominoPiece>();
        public int leftEndValue = -1;
        public int rightEndValue = -1;
        
        [Header("Visual")]
        public GameObject boardTilePrefab;
        
        private List<Vector3> boardPositions = new List<Vector3>();
        
        void Start()
        {
            InitializeBoard();
        }
        
        /// <summary>
        /// Inicializa o tabuleiro
        /// </summary>
        void InitializeBoard()
        {
            playedPieces.Clear();
            leftEndValue = -1;
            rightEndValue = -1;
            boardPositions.Clear();
        }
        
        /// <summary>
        /// Tenta jogar uma peça no tabuleiro
        /// </summary>
        public bool PlayPiece(DominoPiece piece, bool rotateIfNeeded = true)
        {
            if (playedPieces.Count == 0)
            {
                // Primeira peça
                return PlayFirstPiece(piece);
            }
            
            // Tenta encaixar na esquerda
            if (piece.topValue == leftEndValue || piece.bottomValue == leftEndValue)
            {
                return PlayOnLeft(piece, rotateIfNeeded);
            }
            
            // Tenta encaixar na direita
            if (piece.topValue == rightEndValue || piece.bottomValue == rightEndValue)
            {
                return PlayOnRight(piece, rotateIfNeeded);
            }
            
            return false;
        }
        
        /// <summary>
        /// Joga a primeira peça (qualquer uma serve)
        /// </summary>
        bool PlayFirstPiece(DominoPiece piece)
        {
            playedPieces.Add(piece);
            leftEndValue = piece.topValue;
            rightEndValue = piece.bottomValue;
            
            // Posiciona no centro
            Vector3 position = Vector3.zero;
            piece.transform.position = position;
            piece.transform.rotation = Quaternion.Euler(0, 0, 0);
            
            return true;
        }
        
        /// <summary>
        /// Joga peça na esquerda
        /// </summary>
        bool PlayOnLeft(DominoPiece piece, bool rotateIfNeeded)
        {
            // Verifica se precisa rotacionar
            if (piece.bottomValue == leftEndValue && rotateIfNeeded)
            {
                piece.RotatePiece();
            }
            
            if (piece.topValue != leftEndValue)
            {
                return false;
            }
            
            playedPieces.Insert(0, piece);
            leftEndValue = piece.bottomValue;
            
            // Calcula nova posição
            Vector3 newPosition = CalculateLeftPosition();
            piece.transform.position = newPosition;
            
            // Rotaciona se for double
            if (piece.isDouble)
            {
                piece.transform.Rotate(0, 0, 90);
            }
            
            return true;
        }
        
        /// <summary>
        /// Joga peça na direita
        /// </summary>
        bool PlayOnRight(DominoPiece piece, bool rotateIfNeeded)
        {
            // Verifica se precisa rotacionar
            if (piece.topValue == rightEndValue && rotateIfNeeded)
            {
                piece.RotatePiece();
            }
            
            if (piece.bottomValue != rightEndValue)
            {
                return false;
            }
            
            playedPieces.Add(piece);
            rightEndValue = piece.topValue;
            
            // Calcula nova posição
            Vector3 newPosition = CalculateRightPosition();
            piece.transform.position = newPosition;
            
            // Rotaciona se for double
            if (piece.isDouble)
            {
                piece.transform.Rotate(0, 0, 90);
            }
            
            return true;
        }
        
        /// <summary>
        /// Calcula posição para jogar na esquerda
        /// </summary>
        Vector3 CalculateLeftPosition()
        {
            int piecesInRow = Mathf.FloorToInt(10f / pieceSpacing);
            int rowIndex = playedPieces.Count / piecesInRow;
            int pieceIndex = playedPieces.Count % piecesInRow;
            
            float x = -(pieceIndex * pieceSpacing) - (pieceSpacing / 2);
            float y = -(rowIndex * rowSpacing);
            
            return new Vector3(x, y, 0);
        }
        
        /// <summary>
        /// Calcula posição para jogar na direita
        /// </summary>
        Vector3 CalculateRightPosition()
        {
            int piecesInRow = Mathf.FloorToInt(10f / pieceSpacing);
            int rowIndex = (playedPieces.Count - 1) / piecesInRow;
            int pieceIndex = (playedPieces.Count - 1) % piecesInRow;
            
            float x = (pieceIndex * pieceSpacing) + (pieceSpacing / 2);
            float y = -(rowIndex * rowSpacing);
            
            return new Vector3(x, y, 0);
        }
        
        /// <summary>
        /// Verifica se o jogo está travado (ninguém pode jogar)
        /// </summary>
        public bool IsGameBlocked(List<DominoPiece> allHands)
        {
            foreach (var hand in allHands)
            {
                foreach (var piece in hand)
                {
                    if (piece.CanPlay(leftEndValue, rightEndValue))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        
        /// <summary>
        /// Verifica se um jogador ganhou
        /// </summary>
        public bool CheckWin(List<DominoPiece> hand)
        {
            return hand.Count == 0;
        }
        
        /// <summary>
        /// Limpa o tabuleiro para nova partida
        /// </summary>
        public void Reset()
        {
            foreach (var piece in playedPieces)
            {
                piece.gameObject.SetActive(false);
            }
            playedPieces.Clear();
            leftEndValue = -1;
            rightEndValue = -1;
        }
    }
}
