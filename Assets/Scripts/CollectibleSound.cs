using UnityEngine;

public class CollectibleSound : MonoBehaviour
{
    private AudioManager _audioManager;
    [SerializeField] private AudioClip clip;

    private void Start()
    {
        _audioManager = AudioManager.Instance;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _audioManager.PlaySoundEffect(clip);
    }
}
