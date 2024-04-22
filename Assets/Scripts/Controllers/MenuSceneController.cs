using UnityEngine;

public class MenuSceneController : MonoBehaviour
{
    [Header("Screens")] 
    [SerializeField] private GameObject _settingsScreen;
    [SerializeField] private GameObject _mainScreen;

    public void ShowSettingsScreen()
    {
        _settingsScreen.SetActive(true);
        _mainScreen.SetActive(false);
    }
    
    public void ShowMainScreen()
    {
        _settingsScreen.SetActive(false);
        _mainScreen.SetActive(true);
    }
}