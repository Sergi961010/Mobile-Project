using UnityEngine;

public class EnemyController : MonoBehaviour, IHitable
{
    private Rigidbody2D _rb;

    [SerializeField] private float _speed = 2f;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _rb.velocity = Vector2.left * _speed;
    }

    public void HandleHit()
    {
        Destroy(this);
    }
}
