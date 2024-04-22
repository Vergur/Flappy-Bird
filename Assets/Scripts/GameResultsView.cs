using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameResultsView : MonoBehaviour
{
    [Header("TextFields")]
    [SerializeField] private TextMeshProUGUI _currentScoreTextField;
    [SerializeField] private TextMeshProUGUI _bestScoreTextField;

    [Header("Medal")]
    [SerializeField] private Image _medalPlaceholder;
    [SerializeField] private Sprite[] _medals;

    [Header("NewRecord")]
    [SerializeField] private GameObject _newRecord;

    public void SetText(int currentScore, int bestScore)
    {
        _currentScoreTextField.SetText(currentScore.ToString());
        _bestScoreTextField.SetText(bestScore.ToString());
    }

    public void ShowNewRecord()
    {
        _newRecord.SetActive(true);
    }
    
    public void EnableMedal(Coins coin)
    {
        _medalPlaceholder.sprite = _medals[(int)coin];
    }
    
    public enum Coins
    {
        Silver,
        Golden
    }
}
