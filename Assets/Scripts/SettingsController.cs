using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    [Header("Buttons")] 
    [SerializeField] private List<Button> _difficultyButtons;
    [SerializeField] private List<Button> _backgroundSpriteButtons;
    [SerializeField] private List<Button> _tubeSpriteButtons;
    
    [Header("Visuals")]
    [SerializeField] private Material _backgroundMaterial;
    [SerializeField] private List<Texture> _dayTimeTexture;
    [SerializeField] private List<Sprite> _tubesSprite;

    [Header("Controllers")] 
    [SerializeField] private ParallaxController _parallaxController;
    public Tube TubePrefab;
    public Difficulty DifficultyLevel;
    public DayTime TubeSkin;
    public DayTime BackgroundSkin;
    public static SettingsController Instance { get; set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            GetSettingsValues();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        ChangeDifficultyLevel((int)DifficultyLevel);
        ChangeBackgroundMaterial((int)BackgroundSkin);
        ChangeTubeSkin((int)TubeSkin);
        
        SetButtonsMethods(_difficultyButtons, ChangeDifficultyLevel);
        SetButtonsMethods(_backgroundSpriteButtons, ChangeBackgroundMaterial);
        SetButtonsMethods(_tubeSpriteButtons, ChangeTubeSkin);
    }

    private void SetButtonsMethods(List<Button> buttons, Action<int> action)
    {
        for (var i = 0; i < buttons.Count; i++)
        {
            var id = i;
            buttons[i].onClick.AddListener(() => action(id));
        }
    }

    private void GetSettingsValues()
    {
        DifficultyLevel = (Difficulty)PlayerPrefs.GetInt("Difficulty");
        BackgroundSkin = (DayTime)PlayerPrefs.GetInt("BackgroundSkin");
        TubeSkin = (DayTime)PlayerPrefs.GetInt("TubeSkin");
    }

    private void ActivateButton(List<Button> buttons, int id)
    {
        foreach (var button in buttons)
        {
            button.interactable = true;
        }
        buttons[id].interactable = false;
    }

    private void ChangeBackgroundMaterial(int dayTime)
    {
        _backgroundMaterial.mainTexture = _dayTimeTexture[dayTime];
        _parallaxController.ChangeActualTexture(_dayTimeTexture[dayTime]);
        ActivateButton(_backgroundSpriteButtons, dayTime);
        PlayerPrefs.SetInt("BackgroundSkin", dayTime);
    }
    
    private void ChangeTubeSkin(int dayTime)
    {
        TubePrefab.ChangeTubeColor(_tubesSprite[dayTime]);
        ActivateButton(_tubeSpriteButtons, dayTime);
        PlayerPrefs.SetInt("TubeSkin", dayTime);
    }
    
    private void ChangeDifficultyLevel(int difficulty)
    {
        DifficultyLevel = (Difficulty)difficulty;
        TubePrefab.ChangePositions((Difficulty)difficulty);
        ActivateButton(_difficultyButtons, difficulty);
        PlayerPrefs.SetInt("Difficulty", difficulty);
    }

    public enum Difficulty
    {
        Easy,
        Medium,
        Hard
    }
    
    public enum DayTime
    {
        Day,
        Night
    }
}