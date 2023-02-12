using TheCreators.Player;
using UnityEngine;

public class CheckEnemyContact : MonoBehaviour
{
    private IHitable _hitable;
    private void OnEnable()
    {
        PlayerInput.OnAttackInput += OnAttackInputEvent;
    }
    private void OnDisable()
    {
        PlayerInput.OnAttackInput -= OnAttackInputEvent;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        _hitable = collision.gameObject.GetComponent<IHitable>();
    }
    private void OnAttackInputEvent()
    {
        if (_hitable != null)
            _hitable.HandleHit();
    }
}
