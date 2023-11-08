using UnityEngine;

namespace TheCreators.UI.MainMenu
{
    public class ActivatePanelOnClick : MonoBehaviour
    {
        public void OnClick(GameObject gameObject)
        {
            gameObject.SetActive(true);
        }
    }
}
