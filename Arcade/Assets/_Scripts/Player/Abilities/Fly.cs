using UnityEngine;

namespace TheCreators.Player
{
    public class Fly : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;
        private EnergyBarController _energyController;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _energyController = GetComponent<EnergyBarController>();
        }
        private void Update()
        {
            if (_energyController.isFlying)
            {
                _energyController.UseAbility();
                Move();
            }
        }
        private void Move()
        {
            _rigidbody.velocity = new Vector2(0, 2);
        }
    }
}