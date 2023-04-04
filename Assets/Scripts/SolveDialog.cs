using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SolveDialog : MonoBehaviour
{

    [SerializeField]
    TMPro.TMP_Text result;

    [SerializeField]
    TMPro.TMP_Text scoreText;

    [SerializeField]
    Button exitToMenuButton;

    [SerializeField]
    GameObject background;

    public void init(int score)
    {
        scoreText.text = "Score: " + score;
        result.text = "Correct!";
        background.GetComponent<Image>().color = new Color(0.14f, 0.46f, 0.0f, 1f);
    }
    
    public void init(string hint) {
        scoreText.text = hint;
        result.text = "Incorrect!";
        exitToMenuButton.GetComponentInChildren<TMPro.TMP_Text>().text = "Retry";
        background.GetComponent<Image>().color = new Color(0.5f, 0.15f, 0.0f, 1f);
    }

    public void exitToMenu()
    {
        if (result.text == "Correct!")
        {
            SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void exitToDesktop()
    {
        Application.Quit();
    }
}
