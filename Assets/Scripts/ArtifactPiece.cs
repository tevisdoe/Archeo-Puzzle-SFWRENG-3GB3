using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactPiece : MonoBehaviour
{
    [SerializeField]
    private String message;

    public void onClick()
    {
        Debug.Log(message);
    }
}
