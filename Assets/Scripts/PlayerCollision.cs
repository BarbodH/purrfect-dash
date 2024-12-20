using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.transform.CompareTag("Obstacle")) return;
        GameManager.Instance.GameOver();
    }
}
