using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DatabankWindowManager : MonoBehaviour
{
    public Button databankButton;
    private Image background;

    public void Start()
    {
        background = this.gameObject.GetComponent<Image>();
        hideDatabank();
    }
    public void showDatabank()
    {
        this.gameObject.SetActive(true);
        databankButton.gameObject.SetActive(false);
    }
    public void hideDatabank()
    {
        this.gameObject.SetActive(false);
        databankButton.gameObject.SetActive(true);
    }
}
