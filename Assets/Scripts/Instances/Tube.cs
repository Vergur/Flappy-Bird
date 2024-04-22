using UnityEngine;

public class Tube : MonoBehaviour
{
    [Header("TubeObjects")]
    [SerializeField] private GameObject _upperTube;
    [SerializeField] private GameObject _lowerTube;
    
    [Header("TubeSprite")]
    [SerializeField] private SpriteRenderer _upperTubeSpriteRenderer;
    [SerializeField] private SpriteRenderer _lowerTubeSpriteRenderer;

    public void ChangePositions(SettingsController.Difficulty difficulty)
    {
        var position = difficulty switch
        {
            SettingsController.Difficulty.Easy => new Vector3(0, 1.2f, 0),
            SettingsController.Difficulty.Medium => new Vector3(0, 1.1f, 0),
            SettingsController.Difficulty.Hard => new Vector3(0, 1f, 0)
        };

        _upperTube.transform.position = position;
        _lowerTube.transform.position = -position;
    }
    
    public void ChangeTubeColor(Sprite sprite)
    {
        _upperTubeSpriteRenderer.sprite = _lowerTubeSpriteRenderer.sprite = sprite;
    }
}