using TheCreators.Managers;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float _spriteWidth;
    [SerializeField] private float _parallaxMultiplier;

    private void Start()
    {
        _spriteWidth = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void Update()
    {
        MoveElement();
        CheckReset();
    }

    private void MoveElement()
    {
        float deltaX = GameManager.Instance.GameVelocity.x * Time.deltaTime * _parallaxMultiplier;
        transform.position += new Vector3(-deltaX, 0, 0);
    }

    private void CheckReset()
    {
        if ((Mathf.Abs(transform.position.x) - _spriteWidth) > 0)
        {
            transform.position = new Vector3(0.0f, transform.position.y, transform.position.z);
        }
    }
}
