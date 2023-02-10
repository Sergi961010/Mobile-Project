using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public static event Action OnAttackInput;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            OnAttackInput?.Invoke();
        }
    }
}
