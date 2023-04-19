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
    int date;

    [SerializeField]
    string correctRegion;

    [SerializeField]
    GameObject solveDialog;

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

    private bool validateInput()
    {
        try
        {
            int toYear = Int32.Parse(toYearInput.text);
            if (toYear < 0)
            {
                return false;
            }
        }
        catch (FormatException)
        {
            return false;
        }
        try
        {
            int fromYear = Int32.Parse(fromYearInput.text);
            if (fromYear < 0)
            {
                return false;
            }
        }
        catch (FormatException)
        {
            return false;
        }


        return true;
    }

    // Returns a negative year if it is BC, otherwise it should be positive
    private int dateValue(string val, int era)
    {
        var num = Int32.Parse(val);
        return num * (era == 0 ? -1 : 1);
    }

    private bool dateContains(int year, int from, int to)
    {
        return from <= year && year <= to;
    }

    int points()
    {
        int points = 100;

        int fromDateNum = this.dateValue(fromYearInput.text, fromEraDropdown.value);
        int toDateNum = this.dateValue(toYearInput.text, toEraDropdown.value);

        int diff = Math.Abs(toDateNum - fromDateNum) / 10;

        return Math.Max(0, points - diff);
    }

    public void solve()
    {
        if (!this.validateInput())
        {
            // write to feedback text
            this.showDialog("Year must be a positive number");
            return;
        }

        var toDateNum = this.dateValue(toYearInput.text, toEraDropdown.value);
        var fromDateNum = this.dateValue(fromYearInput.text, fromEraDropdown.value);
        var region = regionDropdown.options[regionDropdown.value].text;

        bool success = true;
        string hint = "";
        if (!this.dateContains(this.date, fromDateNum, toDateNum))
        {
            success = false;
            hint += "I am not sure the date is correct...\n";
        }

        if (!region.Equals(this.correctRegion))
        {
            success = false;
            hint += "I am not sure the region is correct...\n";
        }

        // Show success message
        if (success)
        {
            int points = this.points();
            if (points < 50)
            {
                this.showDialog("Date range is too large!");
            }
            else
            {
                this.showDialog(points);
            }
        }
        else
        {
            this.showDialog(hint);
        }
    }

    void showDialog(int score)
    {
        GameObject obj = Instantiate(solveDialog);
        obj.GetComponent<SolveDialog>().init(score);
    }

    void showDialog(string hint)
    {
        GameObject obj = Instantiate(solveDialog);
        obj.GetComponent<SolveDialog>().init(hint);
    }
}