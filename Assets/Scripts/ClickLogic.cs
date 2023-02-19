using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickLogic : MonoBehaviour
{
    [SerializeField]
    private LayerMask clickLayer;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit rayHit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out rayHit, 100f, clickLayer))
            {
                rayHit.collider.GetComponent<ArtifactPiece>().onClick();
            }
        }
    }
}
