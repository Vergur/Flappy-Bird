using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private GameSceneController _gameSceneController;
    
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
        _gameSceneController.UpdateCurrentScore(++_currentScore);
    }
    
    private void OnPlayerDied()
    {
        CheckMedalResult();
        CheckBestScore();
        _gameSceneController.ShowLoseScreen(_currentScore, _bestScore);
    }

    private void CheckMedalResult()
    {
        _gameSceneController.GameResultsView.EnableMedal(_currentScore * 2 > _bestScore ? GameResultsView.Coins.Golden : GameResultsView.Coins.Silver);
    }

    private void CheckBestScore()
    {
        if (_currentScore <= _bestScore) return;
        
        _gameSceneController.GameResultsView.ShowNewRecord();
        _bestScore = _currentScore;
        PlayerPrefs.SetInt("PlayerBestScore", _bestScore);
    }

    private void OnDestroy()
    {
        _playerController.Player.OnPlayerScore -= OnPlayerScore;
        _playerController.Player.OnPlayerDied -= OnPlayerDied;
    }
}
