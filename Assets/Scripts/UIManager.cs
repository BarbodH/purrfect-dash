using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private GameManager _gameManager;
    
    [SerializeField] private TextMeshProUGUI scoreUI;
    [SerializeField] private GameObject startMenuUI;
    [SerializeField] private GameObject gameOverMenuUI;

    private void Start()
    {
        _gameManager = GameManager.Instance;
        _gameManager.AddListenerOnStart(() =>
        {
            startMenuUI.SetActive(false);
            gameOverMenuUI.SetActive(false);
        });
        _gameManager.AddListenerOnGameOver(() =>
        {
            startMenuUI.SetActive(false);
            gameOverMenuUI.SetActive(true);
        });
        _gameManager.AddListenerOnHome(() =>
        {
            startMenuUI.SetActive(true);
            gameOverMenuUI.SetActive(false);
        });
    }

    private void OnGUI()
    {
        scoreUI.text = _gameManager.GetCurrentScoreString();
    }

    public void HandleButtonStart()
    {
        _gameManager.StartGame();
    }

    public void HandleButtonBackToMenu()
    {
        _gameManager.Home();
    }
}
