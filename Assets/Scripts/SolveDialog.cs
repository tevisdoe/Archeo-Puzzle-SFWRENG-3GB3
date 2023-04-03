using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SolveDialog : MonoBehaviour
{

    public TMPro.TMP_Text result;

    public TMPro.TMP_Text scoreText;

    public void exitToMenu()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

    public void exitToDesktop()
    {
        Application.Quit();
    }
}
