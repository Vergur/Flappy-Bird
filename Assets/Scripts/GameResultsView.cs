using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameResultsView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _currentScoreTextField;
    [SerializeField] private TextMeshProUGUI _bestScoreTextField;

    public void SetText(int currentScore, int bestScore)
    {
        _currentScoreTextField.SetText(currentScore.ToString());
        _bestScoreTextField.SetText(bestScore.ToString());
    }
}
