using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;

    [SerializeField] private float _speed = 2f;

    private void Awake() 
    {
        _rb = GetComponent<Rigidbody2D>();    
    }

    private void Start()
    {
        _rb.velocity = Vector2.right * _speed;
    }
}
