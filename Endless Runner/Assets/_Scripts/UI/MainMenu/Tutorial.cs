using TheCreators.Persistance;
using UnityEngine;

namespace TheCreators.UI.MainMenu
{
    public class Tutorial : MonoBehaviour
    {
        private void Start()
        {
            if (Settings.FirstTime) Settings.FirstTime = false;
            else gameObject.SetActive(false);
        }
    }
}
