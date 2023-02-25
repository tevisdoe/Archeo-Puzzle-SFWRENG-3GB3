using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolLogic : MonoBehaviour
{
    [SerializeField]
    private LayerMask clickLayer;
    [SerializeField]
    private Texture2D magnifierTexture, brushTexture, materialTexture;
    private Vector2 clickPosition = new Vector2(-1,1);
    private CursorMode cursorMode = CursorMode.Auto;
    private bool menuAccessed = false;

    private enum Tool
    {
        Magnifier,
        Brush,
        Material,
        None
    }
    private Tool currentTool = Tool.None;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && !menuAccessed)
        {
            RaycastHit rayHit;
            Vector2 mouseHit = Input.mousePosition;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(mouseHit), out rayHit, 100f, clickLayer))
            {
                if (rayHit.collider.TryGetComponent<ArtifactPiece>(out ArtifactPiece hitPiece))
                {
                    switch (currentTool)
                    {
                        case Tool.None:
                            hitPiece.noneClick(mouseHit);
                            break;
                        case Tool.Magnifier:
                            if (!hitPiece.checkForDust()) hitPiece.magnifierClick(mouseHit);
                            else hitPiece.coveredClick(mouseHit);
                            break;
                        case Tool.Brush:
                            hitPiece.brushClick(mouseHit);
                            break;
                        case Tool.Material:
                            hitPiece.materialClick(mouseHit);
                            break;
                        default:
                            break;
                    }
                    
                } else if (rayHit.collider.TryGetComponent(out Cobweb cobweb))
                {
                    switch (currentTool)
                    {
                        case Tool.Brush:
                            cobweb.Brush(mouseHit);
                            break;
                        default:
                            cobweb.noBrush(mouseHit);
                            break;
                    }
                }

                
                     
            }
        }
    }

    public void toggleMagnifier()
    {
        if (currentTool != Tool.Magnifier)
        {
            currentTool = Tool.Magnifier;
            Cursor.SetCursor(magnifierTexture, clickPosition, cursorMode);
        }
        else
        {
            currentTool = Tool.None;
            Cursor.SetCursor(null, Vector2.zero, cursorMode);
        }
    }

    public void toggleBrush()
    {
        if (currentTool != Tool.Brush)
        {
            currentTool = Tool.Brush;
            Cursor.SetCursor(brushTexture, clickPosition, cursorMode);
        }
        else
        {
            currentTool = Tool.None;
            Cursor.SetCursor(null, Vector2.zero, cursorMode);
        }
    }
    public void toggleMaterial()
    {
        if (currentTool != Tool.Material)
        {
            currentTool = Tool.Material;
            Cursor.SetCursor(materialTexture, clickPosition, cursorMode);
        }
        else
        {
            currentTool = Tool.None;
            Cursor.SetCursor(null, Vector2.zero, cursorMode);
        }
    }

    public void toggleMenuCursor()
    {

        if (menuAccessed == false)
        {
            menuAccessed = true;
            Cursor.SetCursor(null, Vector2.zero, cursorMode);
            return;
        }

        menuAccessed = false;
        switch (currentTool)
        {
            case Tool.Brush:
                Cursor.SetCursor(brushTexture, clickPosition, cursorMode);
                break;
            case Tool.Magnifier:
                Cursor.SetCursor(magnifierTexture, clickPosition, cursorMode);
                break;
            case Tool.Material:
                Cursor.SetCursor(materialTexture, clickPosition, cursorMode);
                break;
            default:
                break;
        }
        
    }

    public bool getMenuAccessed()
    {
        return menuAccessed;
    }
}
