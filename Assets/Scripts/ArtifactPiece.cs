using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ArtifactPiece : MonoBehaviour
{

    public String noneMessage, magniferMessage, brushMessage, materialMessage, coveredMessage;
    public AudioClip magnifierClip, materialClip;
    private AudioSource artifactSource;
    public ToolTipManager tipManager;
    private bool cooldown;

    private void Awake()
    {
        artifactSource = transform.parent.gameObject.GetComponent<AudioSource>();
    }


    public void noneClick(Vector2 mousePos)
    {
        if (!cooldown)
        {
            tipManager.ShowTip(noneMessage, mousePos);
            StartCoroutine(wait());
        }
    }

    public void magnifierClick(Vector2 mousePos)
    {
        if (!cooldown)
        {
            tipManager.ShowTip(magniferMessage, mousePos);
            artifactSource.PlayOneShot(magnifierClip, 0.4f);
            StartCoroutine(wait());
        }
    }

    public void brushClick(Vector2 mousePos)
    {
        if (!cooldown)
        {
            tipManager.ShowTip(brushMessage, mousePos);
            StartCoroutine(wait());
        }
    }

    public void materialClick(Vector2 mousePos)
    {
        if (!cooldown)
        {
            tipManager.ShowTip(materialMessage, mousePos);
            artifactSource.PlayOneShot(materialClip);
            StartCoroutine(wait());
        }
    }

    public void coveredClick(Vector2 mousePos)
    {
        if (!cooldown)
        {
            tipManager.ShowTip(coveredMessage, mousePos);
            StartCoroutine(wait());
        }
    }

    private IEnumerator wait()
    {
        cooldown = true;
        yield return new WaitForSeconds(3f);
        cooldown = false;

    }

    public bool checkForDust()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).gameObject.activeInHierarchy)
            {
                return true;
            }
        }
        return false;
    }
}
