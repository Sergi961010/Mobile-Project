using TheCreators.CustomEventSystem;
using UnityEngine;
using UnityEngine.UI;

namespace TheCreators.UI
{
    public class StaminaSlider : MonoBehaviour
    {
        [SerializeField] private Image staminaProgressUI;
        private void OnEnable()
        {
            GameEventBus.OnStaminaBarUpdate.AddListener(UpdateStaminaBar);
        }
        private void OnDisable()
        {
            GameEventBus.OnStaminaBarUpdate.RemoveListener(UpdateStaminaBar);
        }
        private void UpdateStaminaBar(float currentStamina, float maxStamina)
        {
            staminaProgressUI.fillAmount = currentStamina / maxStamina;
        }
    }
}
