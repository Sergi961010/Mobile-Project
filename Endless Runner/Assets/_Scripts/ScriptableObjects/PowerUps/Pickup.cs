using TheCreators.ProgrammingPatterns.Visitor;
using TheCreators.SpawnSystem;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public StaminaCollectibleData data;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var visitable = collision.gameObject.transform.parent.gameObject.GetComponentInChildren<IVisitable>();
            if (visitable != null)
            {
                visitable.Accept(data);
                gameObject.SetActive(false);
            }
        }
    }
}