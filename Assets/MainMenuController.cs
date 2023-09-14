using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuController : MonoBehaviour
{
    public CanvasGroup OptionPanel;

    public void PlayGame()
    {
        Debug.Log("Start");
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Option()
    {
        Debug.Log("Option");
        OptionPanel.alpha = 1;
        OptionPanel.blocksRaycasts = true;
    }
    public void Back()
    {
        Debug.Log("Back");
        OptionPanel.alpha = 0;
        OptionPanel.blocksRaycasts = false;
    }

    public void Restart()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
