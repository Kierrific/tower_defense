using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void startButton()
    {
        SceneManager.LoadScene("MapSelection");
    }
    
    public void quitButton()
    {
        Application.Quit();
    }

    public void menuButton()
    {
        SceneManager.LoadScene("Title");
    }

    public void TutorialButton()
    {
        //SceneManager.LoadScene("Tutorial");
    }

    public void PlainsButton()
    {
        SceneManager.LoadScene("Game");
    }
    
    public void DesertButton()
    {
        SceneManager.LoadScene("Map2");
    }
}
