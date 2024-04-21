using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private GameObject _gameOverScreen;
    [SerializeField] private GameResultsView _gameResultsView;
    private int _currentScore = 0;
    private int _bestScore = 0;
    
    private void Start()
    {
        _playerController.Player.OnPlayerScore += OnPlayerScore;
        _playerController.Player.OnPlayerDied += OnPlayerDied;
        _bestScore = PlayerPrefs.GetInt("PlayerBestScore");
    }

    private void OnPlayerScore()
    {
        _currentScore++;
    }
    
    private void OnPlayerDied()
    {
        Time.timeScale = 0f;
        CheckBestScore();
        _gameOverScreen.SetActive(true);
        _gameResultsView.SetText(_currentScore, _bestScore);
    }

    private void CheckBestScore()
    {
        if (_currentScore <= _bestScore) return;

        _bestScore = _currentScore;
        PlayerPrefs.SetInt("PlayerBestScore", _bestScore);
    }

    private void OnDestroy()
    {
        _playerController.Player.OnPlayerScore -= OnPlayerScore;
        _playerController.Player.OnPlayerDied -= OnPlayerDied;
    }
}
