using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExitManager : MonoBehaviour
{

    public List<Button> UIButtons;

    public void Start()
    {
        this.gameObject.SetActive(false);
    }
    public void OpenConfirmationWindow()
    {
        this.gameObject.SetActive(true);
        foreach (Button button in UIButtons)
        {
            button.gameObject.SetActive(false);
        }
    }

    public void CloseConfirmationWindow()
    {
        this.gameObject.SetActive(false);
        foreach (Button button in UIButtons)
        {
            button.gameObject.SetActive(true);
        }
    }

    public void exitToMenu()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
}
