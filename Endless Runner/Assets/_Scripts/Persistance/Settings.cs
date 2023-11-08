using UnityEngine;

namespace TheCreators.Persistance
{
    public static class Settings
    {
        private static readonly string _soundEnabled = "soundEnabled";
        private static readonly string _firstTime = "firstTime";
        public static bool SoundEnabled
        {
            get { return PlayerPrefs.GetInt(_soundEnabled, 1) != 0; }
            set { PlayerPrefs.SetInt(_soundEnabled, value ? 1 : 0); }
        }
        public static bool FirstTime
        {
            get { return PlayerPrefs.GetInt(_firstTime, 1) == 1; }
            set { PlayerPrefs.SetInt(_firstTime, value ? 1 : 0); }
        }
    }
}