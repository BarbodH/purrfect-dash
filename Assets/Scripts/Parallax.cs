using UnityEngine;

public class Parallax : MonoBehaviour
{
    private GameManager _gameManager;
    private Material _material;
    private float _distance;
    [Range(0f, 0.5f)] [SerializeField] private float maxSpeed = 0.2f;
    private float _speed;

    private void Start()
    {
        _material = GetComponent<Renderer>().material;
        _gameManager = GameManager.Instance;
        _gameManager.AddListenerOnStart(() => _speed = maxSpeed);
        _gameManager.AddListenerOnGameOver(() => _speed = 0f);
    }

    private void Update()
    {
        _distance += Time.deltaTime * _speed;
        _material.SetTextureOffset("_MainTex", Vector2.right * _distance);
    }
}