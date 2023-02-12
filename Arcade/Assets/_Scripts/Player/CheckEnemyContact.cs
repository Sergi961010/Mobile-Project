using TheCreators.Player;
using UnityEngine;

public class CheckEnemyContact : MonoBehaviour
{
    private GameObject _enemy;
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
        _enemy = collision.gameObject;
    }
    private void OnAttackInputEvent()
    {
        if (_enemy != null)
            _enemy.SetActive(false);
    }
}
