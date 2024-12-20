using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public float CurrentScore { get; private set; }
    public bool IsPlaying { get; private set; }

    private readonly UnityEvent _onStart = new();
    public void AddListenerOnStart(UnityAction listener) => _onStart.AddListener(listener);
    
    private readonly UnityEvent _onGameOver = new();
    public void AddListenerOnGameOver(UnityAction listener) => _onGameOver.AddListener(listener);
    
    private readonly UnityEvent _onHome = new();
    public void AddListenerOnHome(UnityAction listener) => _onHome.AddListener(listener);

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    // private void Update()
    // {
    //     if (!IsPlaying) return;
    //     CurrentScore += Time.deltaTime;
    // }

    public void IncrementCurrentScore()
    {
        CurrentScore++;
    }

    public void ResetCurrentScore()
    {
        CurrentScore = 0;
    }

    public void StartGame()
    {
        _onStart.Invoke();
        IsPlaying = true;
    }

    public void GameOver()
    {
        _onGameOver.Invoke();
        CurrentScore = 0;
        IsPlaying = false;
    }

    public void Home()
    {
        _onHome.Invoke();
    }

    public string GetCurrentScoreString()
    {
        return Mathf.RoundToInt(CurrentScore).ToString();
    }
}