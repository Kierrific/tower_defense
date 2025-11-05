using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void startButton()
    {
        SceneManager.LoadScene("Game");
    }
    
    public void quitButton()
    {
        Application.Quit();
    }
}
