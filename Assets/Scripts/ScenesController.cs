using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesController : MonoBehaviour
{
    public void LoadPlayScene()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
        UnpauseGame();
    }
    
    public void LoadMenuScene()
    {
        SceneManager.LoadScene("MenuScene", LoadSceneMode.Single);
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
