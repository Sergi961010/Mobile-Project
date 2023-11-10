using UnityEngine;
using UnityEngine.UI;

namespace TheCreators.UI
{
	public abstract class BaseSlider : MonoBehaviour
	{
		[SerializeField] protected Image progressImage;
		protected virtual void FillBar(float value)
		{
			progressImage.fillAmount = value;
		}
		protected virtual void FillBar(float value, float maxFillAmount)
		{
			progressImage.fillAmount = value / maxFillAmount;
		}
	}
}