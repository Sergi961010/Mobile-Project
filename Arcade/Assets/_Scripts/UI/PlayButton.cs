using TheCreators.Enums;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TheCreators.UI
{
    public class PlayButton : MonoBehaviour
    {
	    public void StartGame()
        {
            SceneManager.LoadScene((int)SceneID.Gameplay);
        }
    }
}
