using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    private GameManager _gameManager;
    [SerializeField] private AudioSource backgroundMusicSource;
    [SerializeField] private AudioSource soundEffectSource;
    [SerializeField] private AudioClip backgroundMusic;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    private void Start()
    {
        backgroundMusicSource.clip = backgroundMusic;
        backgroundMusicSource.loop = true;
        
        _gameManager = GameManager.Instance;
        _gameManager.AddListenerOnStart(() => backgroundMusicSource.Play());
        _gameManager.AddListenerOnGameOver(() => backgroundMusicSource.Stop());
    }

    public void PlaySoundEffect(AudioClip clip)
    {
        soundEffectSource.PlayOneShot(clip);
    }
}