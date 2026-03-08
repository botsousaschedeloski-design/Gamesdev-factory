using UnityEngine;

namespace DominoQQ
{
    /// <summary>
    /// Gerenciador de save local (PlayerPrefs)
    /// </summary>
    public static class SaveManager
    {
        private const string GAMES_PLAYED_KEY = "DominoQQ_GamesPlayed";
        private const string GAMES_WON_KEY = "DominoQQ_GamesWon";
        private const string HIGH_SCORE_KEY = "DominoQQ_HighScore";
        private const string SETTINGS_KEY = "DominoQQ_Settings";
        
        /// <summary>
        /// Salva estatísticas do jogador
        /// </summary>
        public static void SaveStats(int gamesPlayed, int gamesWon)
        {
            PlayerPrefs.SetInt(GAMES_PLAYED_KEY, gamesPlayed);
            PlayerPrefs.SetInt(GAMES_WON_KEY, gamesWon);
            PlayerPrefs.Save();
        }
        
        /// <summary>
        /// Carrega estatísticas
        /// </summary>
        public static (int played, int won) LoadStats()
        {
            int played = PlayerPrefs.GetInt(GAMES_PLAYED_KEY, 0);
            int won = PlayerPrefs.GetInt(GAMES_WON_KEY, 0);
            return (played, won);
        }
        
        /// <summary>
        /// Salva recorde
        /// </summary>
        public static void SaveHighScore(int score)
        {
            int currentHigh = PlayerPrefs.GetInt(HIGH_SCORE_KEY, 0);
            if (score > currentHigh)
            {
                PlayerPrefs.SetInt(HIGH_SCORE_KEY, score);
                PlayerPrefs.Save();
            }
        }
        
        /// <summary>
        /// Carrega recorde
        /// </summary>
        public static int LoadHighScore()
        {
            return PlayerPrefs.GetInt(HIGH_SCORE_KEY, 0);
        }
        
        /// <summary>
        /// Salva configurações
        /// </summary>
        public static void SaveSettings(bool soundEnabled, bool musicEnabled, int difficulty)
        {
            PlayerPrefs.SetInt("SoundEnabled", soundEnabled ? 1 : 0);
            PlayerPrefs.SetInt("MusicEnabled", musicEnabled ? 1 : 0);
            PlayerPrefs.SetInt("Difficulty", difficulty);
            PlayerPrefs.Save();
        }
        
        /// <summary>
        /// Carrega configurações
        /// </summary>
        public static (bool sound, bool music, int difficulty) LoadSettings()
        {
            bool sound = PlayerPrefs.GetInt("SoundEnabled", 1) == 1;
            bool music = PlayerPrefs.GetInt("MusicEnabled", 1) == 1;
            int difficulty = PlayerPrefs.GetInt("Difficulty", 1);
            return (sound, music, difficulty);
        }
        
        /// <summary>
        /// Reseta todo o progresso
        /// </summary>
        public static void ResetProgress()
        {
            PlayerPrefs.DeleteKey(GAMES_PLAYED_KEY);
            PlayerPrefs.DeleteKey(GAMES_WON_KEY);
            PlayerPrefs.DeleteKey(HIGH_SCORE_KEY);
            PlayerPrefs.Save();
        }
        
        /// <summary>
        /// Calcula taxa de vitória
        /// </summary>
        public static float GetWinRate()
        {
            var stats = LoadStats();
            if (stats.played == 0) return 0f;
            return (float)stats.won / stats.played * 100f;
        }
    }
}
