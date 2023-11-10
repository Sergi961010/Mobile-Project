using UnityEngine;

namespace TheCreators.Persistance
{
    public static class Settings
    {
        private static readonly string _soundEnabled = "soundEnabled";
        private static readonly string _highScore = "highScore";
        public static bool SoundEnabled
        {
            get { return PlayerPrefs.GetInt(_soundEnabled, 1) != 0; }
            set { PlayerPrefs.SetInt(_soundEnabled, value ? 1 : 0); }
        }
        public static int HighScore
        {
            get { return PlayerPrefs.GetInt(_highScore, 0); }
            set { PlayerPrefs.SetInt(_highScore, value); }
        }
    }
}