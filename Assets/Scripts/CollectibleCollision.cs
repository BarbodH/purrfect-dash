using UnityEngine;

public class CollectibleCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
        GameManager.Instance.IncrementCurrentScore();
    }
}
