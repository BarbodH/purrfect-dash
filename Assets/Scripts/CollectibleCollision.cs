using UnityEngine;

public class CollectibleCollision : MonoBehaviour
{
    private const string TagName = "Collectible";
    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = GameManager.Instance;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag(TagName)) return;
        Destroy(other.gameObject);
        _gameManager.IncrementCurrentScore();
    }
}
