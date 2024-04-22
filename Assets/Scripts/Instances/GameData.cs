using UnityEngine;

public class GameData : MonoBehaviour
{
    public static GameData Instance { get; set; }
    [HideInInspector] public SettingsController.Difficulty Difficulty;
    [HideInInspector] public Tube TubePrefab;
    
    private void Awake()
    {
        if (Instance != null) return;
        
        Instance = this;
    }

    public void SaveDifficultyLevel(SettingsController.Difficulty difficulty)
    {
        Difficulty = difficulty;
    }
    
    public void SaveTubePrefab(Tube tube)
    {
        TubePrefab = tube;
    }
}