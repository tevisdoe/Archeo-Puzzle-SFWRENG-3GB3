using System;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SolveWindowManager : MonoBehaviour
{
    [SerializeField]
    Button solveButton;
    [SerializeField]
    TMPro.TMP_Dropdown regionDropdown;
    [SerializeField]
    TMPro.TMP_InputField fromDateInput;
    [SerializeField]
    TMPro.TMP_InputField toDateInput;
    [SerializeField]
    TMPro.TMP_Text resultText;
    [SerializeField]
    int date;
    [SerializeField]
    string correctRegion;

    private bool success;
    private float time = 2.5f;

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

    void Update()
    {
        if (!success)
            return;
        time -= Time.deltaTime;
        if (time <= 0)
        {
            SceneManager.LoadScene("Menu");
        }
    }

    private bool validateInput()
    {
        var dateRegex = new Regex(@"\d+(BC|AD)");


        if (!dateRegex.IsMatch(fromDateInput.text))
        {
            this.resultText.text = "The 'From Date' is in the wrong format";
            this.resultText.color = Color.red;
            return false;
        }
        if (!dateRegex.IsMatch(toDateInput.text))
        {
            this.resultText.text = "The 'To Date' is in the wrong format";
            this.resultText.color = Color.red;
            return false;
        }

        return true;
    }

    // Returns a negative year if it is BC, otherwise it should be positive
    private int dateNum(string val)
    {
        int len = val.Length;
        string sub = val.Substring(0, len - 2);

        var num = Int32.Parse(sub);
        if (val.Substring(len - 2) == "BC")
            num *= -1;

        return num;
    }

    private bool dateContains(int year, int from, int to)
    {
        return from <= year && year <= to;
    }

    public void solve()
    {
        if (!this.validateInput())
        {
            Debug.Log("Failed validation...");
            return;
        }

        var toDateNum = this.dateNum(toDateInput.text);
        var fromDateNum = this.dateNum(fromDateInput.text);
        var region = regionDropdown.options[regionDropdown.value].text;

        if (!this.dateContains(this.date, fromDateNum, toDateNum))
        {
            this.resultText.text = "The year is wrong...";
            this.resultText.color = Color.red;
            return;
        }

        if (!region.Equals(this.correctRegion))
        {
            Debug.Log("correct region...");
            this.resultText.text = "The region is wrong...";
            this.resultText.color = Color.red;
            return;
        }

        this.resultText.text = "Success!\nReturning to Main Menu...";
        this.resultText.color = Color.green;

        this.success = true;
    }
}
