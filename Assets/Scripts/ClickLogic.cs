using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickLogic : MonoBehaviour
{
    [SerializeField]
    private LayerMask clickLayer;

    private enum Tool
    {
        Magnifier,
        Brush,
        Material,
        None
    }
    private Tool currentTool;

    private void Start()
    {
        currentTool = Tool.None;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit rayHit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out rayHit, 100f, clickLayer))
            {
                ArtifactPiece hitPiece = rayHit.collider.GetComponent<ArtifactPiece>(); 
                if (currentTool == Tool.None) hitPiece.noneClick();
                else if (currentTool == Tool.Magnifier) hitPiece.magnifierClick();
                else if (currentTool == Tool.Brush) hitPiece.brushClick();
                else hitPiece.materialClick();
            }
        }
    }

    public void toggleMagnifier()
    {
        if (currentTool != Tool.Magnifier) currentTool = Tool.Magnifier;
        else currentTool = Tool.None;
    }

    public void toggleBrush()
    {
        if (currentTool != Tool.Brush) currentTool = Tool.Brush;
        else currentTool = Tool.None;
    }
    public void toggleMaterial()
    {
        if (currentTool != Tool.Material) currentTool = Tool.Material;
        else currentTool = Tool.None;
    }
}
