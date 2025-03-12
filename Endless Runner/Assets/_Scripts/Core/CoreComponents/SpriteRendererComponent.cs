using UnityEngine;

namespace TheCreators.CoreSystem.CoreComponents
{
    public class SpriteRendererComponent : CoreComponent
    {
        public SpriteRenderer SpriteRenderer { get; private set; }
        protected override void Awake()
        {
            base.Awake();
            SpriteRenderer = GetComponentInParent<SpriteRenderer>();
        }
        public void ChangeSortingOrder(int value)
        {
            SpriteRenderer.sortingOrder = value;
        }
    }
}
