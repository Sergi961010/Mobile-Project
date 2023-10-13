using UnityEngine;

namespace TheCreators.Managers
{
    public class GameManager : MonoBehaviour
    {
        private void OnEnable()
        {
            Application.targetFrameRate = 60;
        }
    }
}