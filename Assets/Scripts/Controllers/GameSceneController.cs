using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class GameSceneController : MonoBehaviour
{
    [Header("Screens")]
    [SerializeField] private GameObject _pauseScreen;
    [SerializeField] private GameObject _unpauseScreen;
    [SerializeField] private GameObject _gameScreen;
    [SerializeField] private GameObject _gameOverScreen;

    [Header("Views")]
    public GameResultsView GameResultsView;
    [SerializeField] private TextMeshProUGUI _currentTimeText;
    [SerializeField] private TextMeshProUGUI _currentScoreText;

    [Header("Controllers")]
    public ScenesController ScenesController;

    private void Awake()
    {
        PauseGame();
        UnpauseGame();
    }

    public void PauseGame()
    {
        ScenesController.PauseGame();
        _pauseScreen.SetActive(true);
    }
    
    public void UnpauseGame()
    {
        _pauseScreen.SetActive(false);
        _unpauseScreen.SetActive(true);
        StartCoroutine(TimeCounter());
    }

    public void ShowLoseScreen(int currentScore, int bestScore)
    {
        ScenesController.PauseGame();
        _gameScreen.SetActive(false);
        _gameOverScreen.SetActive(true);
        GameResultsView.SetText(currentScore, bestScore);
    }

    private IEnumerator TimeCounter()
    {
        for (int i = 3; i >= 1; i--)
        {
            _currentTimeText.SetText(i.ToString());
            yield return new WaitForSecondsRealtime(1);
        }
        SetActiveGameCanvas();
    }

    public void UpdateCurrentScore(int currentScore)
    {
        _currentScoreText.SetText(currentScore.ToString());
    }

    private void SetActiveGameCanvas()
    {
        _unpauseScreen.SetActive(false);
        _gameScreen.SetActive(true);
        ScenesController.UnpauseGame();
    }
}