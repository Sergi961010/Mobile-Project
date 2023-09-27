using TheCreators.Enums;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TheCreators.UI.MainMenu
{
    public class PlayButton : MonoBehaviour
    {
	    public void OnClick()
        {
            SceneManager.LoadScene((int)SceneID.Gameplay);
        }
    }
}