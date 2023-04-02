using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DatabankWindowManager : MonoBehaviour
{
    public Button databankButton;
    public Button solveButton;
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
        databankButton.gameObject.SetActive(false);
        solveButton.gameObject.SetActive(false);
    }
    public void hideDatabank()
    {
        this.gameObject.SetActive(false);
        artifactSource.PlayOneShot(close);
        databankButton.gameObject.SetActive(true);
        solveButton.gameObject.SetActive(true);
    }
}
