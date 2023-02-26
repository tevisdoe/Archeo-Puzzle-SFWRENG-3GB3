using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Cobweb : MonoBehaviour
{
    private ArtifactPiece parentObject;
    private string clearedMessage = "This part of the artefact is clean.";
    private Renderer rend;
    private float fadeSpeed = 5f;
    private bool fadeOut = false;
    private AudioSource brushSource;
    public AudioClip brushClip;

    void Start()
    {
        parentObject = transform.parent.gameObject.GetComponent<ArtifactPiece>();
        rend = GetComponent<Renderer>();
        brushSource = transform.parent.transform.parent.gameObject.GetComponent<AudioSource>();
    }

    public IEnumerator FadeOutObject()
    {
        while (rend.material.color.a > 0) {
            Color cobwebColour = rend.material.color;
            float fadeAmount = cobwebColour.a - (fadeSpeed * Time.deltaTime);

            cobwebColour = new Color(cobwebColour.r, cobwebColour.g, cobwebColour.b, fadeAmount);
            rend.material.color = cobwebColour;

            if (cobwebColour.a <= 0)
            {
                gameObject.SetActive(false);
                if (!parentObject.checkForDust()) parentObject.brushMessage = clearedMessage;
                break;
            }
            yield return new WaitForSeconds(0.01f);
        }
        
    }

    public void noBrush(Vector2 mousePos)
    {
        if (!fadeOut) parentObject.tipManager.ShowTip("There's something covering this part of the artefact.", mousePos);
    }

    public void Brush(Vector2 mousePos)
    {
        if (!fadeOut)
        {
            fadeOut = true;
            brushSource.PlayOneShot(brushClip);
            parentObject.tipManager.ShowTip("You brush away the cobweb.", mousePos);
            StartCoroutine(FadeOutObject());
        }
        
    }
}
