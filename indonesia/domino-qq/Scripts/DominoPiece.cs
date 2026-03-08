using UnityEngine;

namespace DominoQQ
{
    /// <summary>
    /// Representa uma peça de dominó
    /// </summary>
    public class DominoPiece : MonoBehaviour
    {
        [Header("Piece Values")]
        public int topValue;      // 0-6
        public int bottomValue;   // 0-6
        
        [Header("Visual")]
        public SpriteRenderer spriteRenderer;
        public Sprite[] pieceSprites; // Array com sprites para cada combinação
        
        [Header("State")]
        public bool isDouble => topValue == bottomValue;
        public bool isPlayable;
        public bool isDragged;
        
        [Header("References")]
        public Transform dragParent;
        
        private Vector3 originalPosition;
        private int originalSiblingIndex;
        
        void Start()
        {
            if (spriteRenderer == null)
                spriteRenderer = GetComponent<SpriteRenderer>();
            
            originalPosition = transform.position;
            originalSiblingIndex = transform.GetSiblingIndex();
            
            UpdateSprite();
        }
        
        /// <summary>
        /// Atualiza o sprite baseado nos valores da peça
        /// </summary>
        public void UpdateSprite()
        {
            if (pieceSprites != null && pieceSprites.Length > 0)
            {
                // Calcula índice único para cada combinação
                int spriteIndex = Mathf.Min(topValue, bottomValue) * 7 + Mathf.Max(topValue, bottomValue);
                
                if (spriteIndex < pieceSprites.Length)
                {
                    spriteRenderer.sprite = pieceSprites[spriteIndex];
                }
            }
        }
        
        /// <summary>
        /// Inicia o drag da peça
        /// </summary>
        public void StartDrag()
        {
            isDragged = true;
            originalPosition = transform.position;
            originalSiblingIndex = transform.GetSiblingIndex();
            
            // Move para frente
            transform.SetParent(dragParent);
            transform.SetAsLastSibling();
        }
        
        /// <summary>
        /// Atualiza posição durante drag
        /// </summary>
        public void OnDrag(Vector3 position)
        {
            if (isDragged)
            {
                transform.position = position;
            }
        }
        
        /// <summary>
        /// Finaliza o drag
        /// </summary>
        public void EndDrag(bool success)
        {
            isDragged = false;
            
            if (!success)
            {
                // Retorna para posição original
                transform.position = originalPosition;
                transform.SetSiblingIndex(originalSiblingIndex);
            }
        }
        
        /// <summary>
        /// Verifica se esta peça pode ser jogada
        /// </summary>
        public bool CanPlay(int leftEnd, int rightEnd)
        {
            return topValue == leftEnd || bottomValue == leftEnd ||
                   topValue == rightEnd || bottomValue == rightEnd;
        }
        
        /// <summary>
        /// Rotaciona a peça
        /// </summary>
        public void RotatePiece()
        {
            int temp = topValue;
            topValue = bottomValue;
            bottomValue = temp;
            
            transform.Rotate(0, 0, 180);
        }
        
        /// <summary>
        /// Retorna o valor total da peça (para scoring)
        /// </summary>
        public int GetTotalValue()
        {
            return topValue + bottomValue;
        }
        
        /// <summary>
        /// Retorna string representando a peça
        /// </summary>
        public override string ToString()
        {
            return $"[{topValue}|{bottomValue}]";
        }
    }
}
