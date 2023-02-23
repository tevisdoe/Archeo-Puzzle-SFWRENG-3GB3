using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ArtifactPiece : MonoBehaviour
{
    [SerializeField]
    private String noneMessage, magniferMessage, brushMessage, materialMessage;
    [SerializeField]
    Canvas UICanvas;
    private ToolTipManager manager;

    void Start()
    {
        manager = UICanvas.GetComponent<ToolTipManager>();
    }

    public void noneClick(Vector2 mousePos)
    {
        manager.ShowTip(noneMessage, mousePos);
    }

    public void magnifierClick(Vector2 mousePos)
    {
        manager.ShowTip(magniferMessage, mousePos);
    }

    public void brushClick(Vector2 mousePos)
    {
        manager.ShowTip(brushMessage, mousePos);
    }

    public void materialClick(Vector2 mousePos)
    {
        manager.ShowTip(materialMessage, mousePos);
    }
}
