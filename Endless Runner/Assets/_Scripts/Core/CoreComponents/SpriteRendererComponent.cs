using UnityEngine;

namespace TheCreators.CoreSystem.CoreComponents
{
    public class SpriteRendererComponent : BaseCoreComponent
    {
        private SpriteRenderer _spriteRenderer;

        protected override void Awake()
        {
            base.Awake();
            _spriteRenderer = GetComponentInParent<SpriteRenderer>();
        }
        public void ChangeSortingOrder(int value)
        {
            _spriteRenderer.sortingOrder = value;
        }
    }
}
