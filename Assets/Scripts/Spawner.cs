using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    private GameManager _gameManager;
    private float _timeCurrent;
    private float _timeAlive;

    [SerializeField] private GameObject[] obstaclePrefabs;
    [SerializeField] private float baseObstacleSpawnTime = 3f;
    [SerializeField] [Range(0, 1)] private float obstacleSpawnTimeFactor = 0.1f;
    [SerializeField] private float baseObstacleSpeed = 4f;
    [SerializeField] [Range(0, 1)] private float obstacleSpeedFactor = 0.2f;

    private float _obstacleSpawnTime;
    private float _obstacleSpeed;

    private void Start()
    {
        _gameManager = GameManager.Instance;
        _gameManager.AddListenerOnStart(() =>
        {
            RemoveObstacles();
            ResetFactors();
        });
        _gameManager.AddListenerOnGameOver(StopObjects);
        _gameManager.AddListenerOnHome(RemoveObstacles);
    }

    private void Update()
    {
        if (!GameManager.Instance.IsPlaying) return;
        _timeAlive += Time.deltaTime;
        _timeCurrent += Time.deltaTime;

        if (_timeCurrent < _obstacleSpawnTime) return;
        CalculateFactors();
        SpawnObstacle();
        _timeCurrent = 0f;
    }

    private void ResetFactors()
    {
        _timeAlive = 0f;
        _obstacleSpawnTime = baseObstacleSpawnTime;
        _obstacleSpeed = baseObstacleSpeed;
    }

    private void CalculateFactors()
    {
        _obstacleSpawnTime = baseObstacleSpawnTime / Mathf.Pow(_timeAlive, obstacleSpawnTimeFactor);
        _obstacleSpeed = baseObstacleSpeed * Mathf.Pow(_timeAlive, obstacleSpeedFactor);
    }

    private void SpawnObstacle()
    {
        var obstacle = Instantiate(obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)], transform.position,
            Quaternion.identity);
        obstacle.GetComponent<Rigidbody2D>().linearVelocity = Vector2.left * _obstacleSpeed;
    }

    private static void StopObjects()
    {
        foreach (var obstacle in GameObject.FindGameObjectsWithTag("Obstacle"))
        {
            var obstacleRigidbody = obstacle.GetComponent<Rigidbody2D>();
            if (obstacleRigidbody != null)
            {
                obstacleRigidbody.simulated = false;
            }
        }

        foreach (var collectible in GameObject.FindGameObjectsWithTag("Collectible"))
        {
            var collectibleRigidbody = collectible.GetComponent<Rigidbody2D>();
            if (collectibleRigidbody != null)
            {
                collectibleRigidbody.simulated = false;
            }
        }
    }

    private static void RemoveObstacles()
    {
        foreach (var obstacle in GameObject.FindGameObjectsWithTag("Obstacle"))
        {
            Destroy(obstacle);
        }

        foreach (var collectible in GameObject.FindGameObjectsWithTag("Collectible"))
        {
            Destroy(collectible);
        }
    }
}