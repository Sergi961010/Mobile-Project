using UnityEngine;

namespace TheCreators.UI.MainMenu
{
    public class QuitButton : MonoBehaviour
    {
        public void OnClick()
        {
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #endif
            Application.Quit();
        }
    }
}