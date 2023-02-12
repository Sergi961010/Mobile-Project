using System;
using UnityEngine;

namespace TheCreators.Player
{
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

}