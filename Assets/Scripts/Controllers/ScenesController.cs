using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesController : MonoBehaviour
{
    public void LoadPlayScene()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
        UnpauseGame();
        AudioController.Instance.OnLoad();
    }
    
    public void LoadMenuScene()
    {
        UnpauseGame();
        SceneManager.LoadScene("MenuScene");
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    
    public void UnpauseGame()
    {
        Time.timeScale = 1;
    }
}
