using TheCreators.CustomEventSystem;

namespace TheCreators.UI
{
    public class StaminaSlider : BaseSlider
    {
        private void OnEnable()
        {
            GameEventBus.OnStaminaBarUpdate.AddListener(FillBar);
        }
        private void OnDisable()
        {
            GameEventBus.OnStaminaBarUpdate.RemoveListener(FillBar);
        }
    }
}
