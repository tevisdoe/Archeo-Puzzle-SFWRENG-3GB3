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

    void Start()
    {
        parentObject = transform.parent.gameObject.GetComponent<ArtifactPiece>();
        rend = GetComponent<Renderer>();
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
                parentObject.brushMessage = clearedMessage;
                Destroy(gameObject); 
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
            parentObject.tipManager.ShowTip("You brush away the cobweb.", mousePos);
            StartCoroutine(FadeOutObject());
        }
        
    }
}
