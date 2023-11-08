using UnityEngine;
using UnityEngine.SceneManagement;

namespace TheCreators.UI.MainMenu
{
    public class ChangeSceneOnClick : MonoBehaviour
    {
	    public void OnClick(int sceneId)
        {
            SceneManager.LoadScene(sceneId);
        }
    }
}