using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DatabankWindowManager : MonoBehaviour
{
    public List<Button> UIButtons;
    public AudioClip open, close;
    public AudioSource artifactSource;

    public void Start()
    {
        this.gameObject.SetActive(false);
    }
    public void showDatabank()
    {
        this.gameObject.SetActive(true);
        artifactSource.PlayOneShot(open);
        foreach (Button button in UIButtons)
        {
            button.gameObject.SetActive(false);
        }
    }
    public void hideDatabank()
    {
        this.gameObject.SetActive(false);
        artifactSource.PlayOneShot(close);
        foreach (Button button in UIButtons)
        {
            button.gameObject.SetActive(true);
        }
    }

}
