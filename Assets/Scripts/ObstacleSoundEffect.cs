using UnityEngine;

public class ObstacleSoundEffect : MonoBehaviour
{
    private AudioManager _audioManager;
    [SerializeField] private AudioClip clip;

    private void Start()
    {
        _audioManager = AudioManager.Instance;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        _audioManager.PlaySoundEffect(clip);
    }
}
