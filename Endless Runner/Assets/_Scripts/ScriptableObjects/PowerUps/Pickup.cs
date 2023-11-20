using TheCreators.ProgrammingPatterns.Visitor;
using TheCreators.ScriptableObjects.PowerUps;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public PowerUp PowerUp;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var visitable = collision.gameObject.transform.parent.gameObject.GetComponentInChildren<IVisitable>();
            if (visitable != null)
            {
                visitable.Accept(PowerUp);
                Destroy(gameObject);
            }
        }
    }
}