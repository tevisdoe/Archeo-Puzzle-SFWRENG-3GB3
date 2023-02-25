using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ArtifactPiece : MonoBehaviour
{

    public String noneMessage, magniferMessage, brushMessage, materialMessage, coveredMessage;
    public ToolTipManager tipManager;

    public void noneClick(Vector2 mousePos)
    {
        tipManager.ShowTip(noneMessage, mousePos);
    }

    public void magnifierClick(Vector2 mousePos)
    {
        tipManager.ShowTip(magniferMessage, mousePos);
    }

    public void brushClick(Vector2 mousePos)
    {
        tipManager.ShowTip(brushMessage, mousePos);
    }

    public void materialClick(Vector2 mousePos)
    {
        tipManager.ShowTip(materialMessage, mousePos);
    }

    public void coveredClick(Vector2 mousePos)
    {
        tipManager.ShowTip(coveredMessage, mousePos);
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
