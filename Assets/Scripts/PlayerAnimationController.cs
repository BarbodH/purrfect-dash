using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private GameManager _gameManager;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _gameManager = GameManager.Instance;
        _gameManager.AddListenerOnStart(() => _animator.SetTrigger("Start"));
        _gameManager.AddListenerOnGameOver(() => _animator.SetTrigger("Die"));
        _gameManager.AddListenerOnHome(() => _animator.SetTrigger("Idle"));
    }
}
