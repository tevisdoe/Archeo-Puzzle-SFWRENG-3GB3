using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactPiece : MonoBehaviour
{
    [SerializeField]
    private String message;

    public void noneClick()
    {
        Debug.Log(message);
    }

    public void magnifierClick()
    {
        Debug.Log("You used the magnifying glass.");
    }

    public void brushClick()
    {
        Debug.Log("You used the brush.");
    }

    public void materialClick()
    {
        Debug.Log("You used the material analyzer.");
    }
}
