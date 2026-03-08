using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

namespace DominoQQ
{
    /// <summary>
    /// Gerenciador principal do jogo Domino QQ
    /// </summary>
    public class DominoGame : MonoBehaviour
    {
        [Header("Game Setup")]
        public int numberOfBots = 3;
        public DominoAI.Difficulty difficulty = DominoAI.Difficulty.Medium;
        
        [Header("References")]
        public DominoBoard board;
        public DominoPiece piecePrefab;
        public Transform playerHandParent;
        public Transform[] botHandParents;
        
        [Header("Game State")]
        public List<DominoPiece> playerHand = new List<DominoPiece>();
        public List<DominoAI> bots = new List<DominoAI>();
        public int currentPlayerIndex;
        public bool isGameActive;
        
        [Header("UI")]
        public GameObject gameUI;
        public GameObject winPanel;
        public GameObject losePanel;
        
        [Header("Audio")]
        public AudioClip pieceSound;
        public AudioClip winSound;
        public AudioClip loseSound;
        
        private List<DominoPiece> allPieces = new List<DominoPiece>();
        private int gamesPlayed;
        private int gamesWon;
        
        void Start()
        {
            InitializeGame();
        }
        
        /// <summary>
        /// Inicializa uma nova partida
        /// </summary>
        public void InitializeGame()
        {
            // Limpa estado anterior
            ResetBoard();
            ClearHands();
            
            // Cria peças
            CreateAllPieces();
            
            // Embaralha
            ShufflePieces();
            
            // Distribui
            DistributePieces();
            
            // Determina quem começa
            DetermineFirstPlayer();
            
            // Inicia jogo
            isGameActive = true;
            currentPlayerIndex = 0;
            
            // Atualiza UI
            UpdateUI();
        }
        
        /// <summary>
        /// Cria todas as 28 peças de dominó
        /// </summary>
        void CreateAllPieces()
        {
            allPieces.Clear();
            
            for (int i = 0; i <= 6; i++)
            {
                for (int j = i; j <= 6; j++)
                {
                    DominoPiece piece = Instantiate(piecePrefab);
                    piece.topValue = i;
                    piece.bottomValue = j;
                    piece.gameObject.SetActive(false);
                    allPieces.Add(piece);
                }
            }
        }
        
        /// <summary>
        /// Embaralha as peças
        /// </summary>
        void ShufflePieces()
        {
            for (int i = allPieces.Count - 1; i > 0; i--)
            {
                int j = Random.Range(0, i + 1);
                DominoPiece temp = allPieces[i];
                allPieces[i] = allPieces[j];
                allPieces[j] = temp;
            }
        }
        
        /// <summary>
        /// Distribui 7 peças para cada jogador
        /// </summary>
        void DistributePieces()
        {
            // Player humano
            for (int i = 0; i < 7; i++)
            {
                DominoPiece piece = allPieces[i];
                piece.gameObject.SetActive(true);
                piece.transform.SetParent(playerHandParent);
                playerHand.Add(piece);
            }
            
            // Bots
            for (int botIndex = 0; botIndex < numberOfBots; botIndex++)
            {
                DominoAI bot = bots[botIndex];
                bot.Reset();
                
                for (int i = 0; i < 7; i++)
                {
                    int pieceIndex = 7 + (botIndex * 7) + i;
                    DominoPiece piece = allPieces[pieceIndex];
                    piece.gameObject.SetActive(false); // Esconde peça do bot
                    bot.AddPiece(piece);
                }
            }
        }
        
        /// <summary>
        /// Determina quem começa (quem tem o double-6 ou peça mais alta)
        /// </summary>
        void DetermineFirstPlayer()
        {
            // Simplificado: jogador sempre começa
            currentPlayerIndex = 0;
        }
        
        /// <summary>
        /// Jogador joga uma peça
        /// </summary>
        public void PlayerPlayPiece(DominoPiece piece)
        {
            if (!isGameActive || currentPlayerIndex != 0) return;
            
            if (board.PlayPiece(piece))
            {
                // Peça jogada com sucesso
                playerHand.Remove(piece);
                piece.transform.SetParent(board.boardParent);
                
                // Toca som
                if (pieceSound != null)
                    AudioSource.PlayClipAtPoint(pieceSound, Camera.main.transform.position);
                
                // Verifica se ganhou
                if (playerHand.Count == 0)
                {
                    PlayerWon();
                    return;
                }
                
                // Próximo jogador
                NextPlayer();
            }
        }
        
        /// <summary>
        /// Bot jogou uma peça
        /// </summary>
        public void OnBotPlayedPiece(DominoAI bot, DominoPiece piece)
        {
            // Toca som
            if (pieceSound != null)
                AudioSource.PlayClipAtPoint(pieceSound, Camera.main.transform.position);
            
            // Verifica se bot ganhou
            if (bot.HasWon())
            {
                PlayerLost();
                return;
            }
            
            // Próximo jogador
            NextPlayer();
        }
        
        /// <summary>
        /// Bot passou a vez
        /// </summary>
        public void OnBotPassed(DominoAI bot)
        {
            // Verifica se jogo está travado
            if (IsGameBlocked())
            {
                EndGameBlocked();
                return;
            }
            
            // Próximo jogador
            NextPlayer();
        }
        
        /// <summary>
        /// Passa para próximo jogador
        /// </summary>
        void NextPlayer()
        {
            currentPlayerIndex = (currentPlayerIndex + 1) % (numberOfBots + 1);
            
            if (currentPlayerIndex == 0)
            {
                // Vez do jogador
                UpdateUI();
            }
            else
            {
                // Vez do bot
                bots[currentPlayerIndex - 1].StartTurn();
            }
        }
        
        /// <summary>
        /// Jogador ganhou
        /// </summary>
        void PlayerWon()
        {
            isGameActive = false;
            gamesWon++;
            gamesPlayed++;
            
            if (winSound != null)
                AudioSource.PlayClipAtPoint(winSound, Camera.main.transform.position);
            
            // Mostra painel de vitória
            if (winPanel != null)
                winPanel.SetActive(true);
            
            // Salva progresso
            SaveManager.SaveStats(gamesPlayed, gamesWon);
        }
        
        /// <summary>
        /// Jogador perdeu
        /// </summary>
        void PlayerLost()
        {
            isGameActive = false;
            gamesPlayed++;
            
            if (loseSound != null)
                AudioSource.PlayClipAtPoint(loseSound, Camera.main.transform.position);
            
            // Mostra painel de derrota
            if (losePanel != null)
                losePanel.SetActive(true);
            
            // Salva progresso
            SaveManager.SaveStats(gamesPlayed, gamesWon);
        }
        
        /// <summary>
        /// Jogo travado (ninguém pode jogar)
        /// </summary>
        void EndGameBlocked()
        {
            isGameActive = false;
            gamesPlayed++;
            
            // Conta pontos
            int playerPoints = CountPlayerPoints();
            int lowestBotPoints = int.MaxValue;
            
            foreach (var bot in bots)
            {
                int points = bot.CountPoints();
                if (points < lowestBotPoints)
                {
                    lowestBotPoints = points;
                }
            }
            
            // Quem tem menos pontos ganha
            if (playerPoints < lowestBotPoints)
            {
                PlayerWon();
            }
            else
            {
                PlayerLost();
            }
        }
        
        /// <summary>
        /// Verifica se jogo está travado
        /// </summary>
        bool IsGameBlocked()
        {
            List<List<DominoPiece>> allHands = new List<List<DominoPiece>>();
            allHands.Add(playerHand);
            
            foreach (var bot in bots)
            {
                allHands.Add(bot.hand);
            }
            
            return board.IsGameBlocked(allHands);
        }
        
        /// <summary>
        /// Conta pontos da mão do jogador
        /// </summary>
        int CountPlayerPoints()
        {
            int points = 0;
            foreach (var piece in playerHand)
            {
                points += piece.GetTotalValue();
            }
            return points;
        }
        
        /// <summary>
        /// Reseta o tabuleiro
        /// </summary>
        void ResetBoard()
        {
            if (board != null)
                board.Reset();
        }
        
        /// <summary>
        /// Limpa as mãos
        /// </summary>
        void ClearHands()
        {
            playerHand.Clear();
            foreach (var bot in bots)
            {
                bot.Reset();
            }
        }
        
        /// <summary>
        /// Atualiza UI
        /// </summary>
        void UpdateUI()
        {
            if (gameUI != null)
                gameUI.SetActive(true);
        }
        
        /// <summary>
        /// Reinicia partida
        /// </summary>
        public void RestartGame()
        {
            if (winPanel != null) winPanel.SetActive(false);
            if (losePanel != null) losePanel.SetActive(false);
            
            InitializeGame();
        }
        
        /// <summary>
        /// Volta ao menu principal
        /// </summary>
        public void BackToMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
