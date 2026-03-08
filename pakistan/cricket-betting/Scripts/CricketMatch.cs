using UnityEngine;

namespace CricketBetting
{
    /// <summary>
    /// Simulador de apostas de Cricket
    /// </summary>
    public class CricketMatch : MonoBehaviour
    {
        [Header("Teams")]
        public Team team1;
        public Team team2;
        
        [Header("Match State")]
        public bool isMatchActive;
        public int currentOver;
        public int currentBall;
        public int team1Score;
        public int team2Score;
        public int team1Wickets;
        public int team2Wickets;
        
        [Header("Betting")]
        public BettingSystem bettingSystem;
        
        [Header("Format")]
        public enum MatchFormat { T20, ODI, Test }
        public MatchFormat format = MatchFormat.T20;
        
        void Start()
        {
            InitializeMatch();
        }
        
        /// <summary>
        /// Inicializa partida
        /// </summary>
        public void InitializeMatch()
        {
            currentOver = 0;
            currentBall = 0;
            team1Score = 0;
            team2Score = 0;
            team1Wickets = 0;
            team2Wickets = 0;
            isMatchActive = true;
        }
        
        /// <summary>
        /// Simula uma bola
        /// </summary>
        public void SimulateBall()
        {
            // Random outcome: 0-6 runs, wicket, wide, no-ball
            int outcome = Random.Range(0, 10);
            
            if (outcome < 7)
            {
                // Runs scored
                AddRuns(outcome);
            }
            else if (outcome < 9)
            {
                // Wicket
                TakeWicket();
            }
            else
            {
                // Extra ball
                currentBall--;
            }
            
            currentBall++;
            
            if (currentBall >= 6)
            {
                currentOver++;
                currentBall = 0;
            }
            
            CheckMatchEnd();
        }
        
        /// <summary>
        /// Adiciona runs
        /// </summary>
        void AddRuns(int runs)
        {
            // Add to current batting team
        }
        
        /// <summary>
        /// Wicket caiu
        /// </summary>
        void TakeWicket()
        {
            // Increment wickets
        }
        
        /// <summary>
        /// Verifica se partida acabou
        /// </summary>
        void CheckMatchEnd()
        {
            // Check if innings over
        }
    }
    
    /// <summary>
    /// Time de cricket
    /// </summary>
    [System.Serializable]
    public class Team
    {
        public string teamName;
        public string country;
        public int rating;
        public Player[] players;
    }
    
    /// <summary>
    /// Jogador de cricket
    /// </summary>
    [System.Serializable]
    public class Player
    {
        public string playerName;
        public string role; // Batsman, Bowler, All-rounder
        public int battingAvg;
        public int bowlingAvg;
    }
}
