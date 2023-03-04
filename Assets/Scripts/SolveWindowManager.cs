using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SolveWindowManager : MonoBehaviour
{
    public Button solveButton;
    public Dropdown region;
    private string fromDateStr;
    private string toDateStr;

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

    public void updateFromDate(string val) {
        fromDateStr = val;
        Debug.Log(val);
    }
    public void updateToDate(string val) {
        toDateStr = val;
        Debug.Log(val);
    }

    public void getRegion(int val) {
        Debug.Log(val);
    }

    public void solve() {
    }
}
