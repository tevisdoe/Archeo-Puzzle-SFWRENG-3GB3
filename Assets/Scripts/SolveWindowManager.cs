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
    List<Button> UIButtons;

    [SerializeField]
    TMPro.TMP_Dropdown regionDropdown;

    [SerializeField]
    TMPro.TMP_Dropdown fromEraDropdown;
    [SerializeField]
    TMPro.TMP_InputField fromYearInput;
    
    [SerializeField]
    TMPro.TMP_Dropdown toEraDropdown;
    [SerializeField]
    TMPro.TMP_InputField toYearInput;

    [SerializeField]
    TMPro.TMP_Text feedbackText;

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
        foreach (Button button in UIButtons)
        {
            button.gameObject.SetActive(false);
        }
    }
    public void hideSolve()
    {
        this.gameObject.SetActive(false);
        foreach (Button button in UIButtons)
        {
            button.gameObject.SetActive(true);
        }
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
        var dateRegex = new Regex(@"^\d+$");

        if (!dateRegex.IsMatch(fromYearInput.text))
        {
            this.feedbackText.text = "Only input the number in the 'From Date' field";
            this.feedbackText.color = Color.red;
            return false;
        }
        if (!dateRegex.IsMatch(toYearInput.text))
        {
            this.feedbackText.text = "Only input the number in the 'To Date' field";
            this.feedbackText.color = Color.red;
            return false;
        }

        return true;
    }

    // Returns a negative year if it is BC, otherwise it should be positive
    private int dateValue(string val, int era)
    {
        var num = Int32.Parse(val);
        return num * (era == -1 ? -1 : 1);
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
            // write to feedback text
            return;
        }

        var toDateNum = this.dateValue(toYearInput.text, toEraDropdown.value);
        var fromDateNum = this.dateValue(fromYearInput.text, fromEraDropdown.value);
        var region = regionDropdown.options[regionDropdown.value].text;

        if (!this.dateContains(this.date, fromDateNum, toDateNum))
        {
            // show fail message for date
            return;
        }

        if (!region.Equals(this.correctRegion))
        {
            // show fail message for region
            return;
        }

        // Show success message

        this.success = true;
    }
}
