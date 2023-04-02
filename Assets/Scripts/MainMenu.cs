using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayLevel1()
    {
        SceneManager.LoadScene("Artifact Scene");
    }

    public void PlayLevel2()
    {
        //TODO: Add link to level 2
        //SceneManager.LoadScene("Level 2");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
