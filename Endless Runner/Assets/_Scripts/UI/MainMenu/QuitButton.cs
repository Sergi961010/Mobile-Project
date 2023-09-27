using UnityEngine;

namespace TheCreators.UI.MainMenu
{
    public class QuitButton : MonoBehaviour
    {
	    public void OnClick()
        {
            Application.Quit();
        }
    }
}
