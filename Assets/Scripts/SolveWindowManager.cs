using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SolveWindowManager : MonoBehaviour
{
    public Button solveButton;
    
    public void Start()
    {
        this.gameObject.SetActive(false);
    }
    public void showSolve()
    {
        this.gameObject.SetActive(true);
        solveButton.gameObject.SetActive(false);
    }
    public void hideSolve()
    {
        this.gameObject.SetActive(false);
        solveButton.gameObject.SetActive(true);
    }
}
