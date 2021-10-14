using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadLevelMenu()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
       
    }
    public void LoadGameover()
    {
        SceneManager.LoadScene(3);
    }
    public void LoadLevel1()
    {
        SceneManager.LoadScene(2);
    }
    public void LoadLevel2()
    {
        SceneManager.LoadScene(3);
    }
    public void PlayAgain()
    { 
        SceneManager.LoadScene(2);
    
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
