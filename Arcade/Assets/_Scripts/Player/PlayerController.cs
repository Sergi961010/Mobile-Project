using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidBody;
    private Animator _animator;

    [SerializeField] private float _speed = 2f;

    private void Awake() 
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _rigidBody.velocity = Vector2.right * _speed;
    }

    private void OnEnable()
    {
        PlayerInput.OnAttackInput += StartAttackAnimation;
    }

    private void OnDisable()
    {
        PlayerInput.OnAttackInput -= StartAttackAnimation;
    }

    private void StartAttackAnimation()
    {
        _animator.SetBool("attack", true);
    }

    private void EndAttackAnimation()
    {
        _animator.SetBool("attack", false);
    }
}
