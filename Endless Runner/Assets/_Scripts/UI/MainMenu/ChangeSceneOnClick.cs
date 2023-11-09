using UnityEngine;

namespace TheCreators.UI.MainMenu
{
    public class ChangeSceneOnClick : MonoBehaviour
    {
        public LevelLoader levelLoader;
	    public void OnClick(int sceneId)
        {
            levelLoader.LoadScene(sceneId);
        }
    }
}