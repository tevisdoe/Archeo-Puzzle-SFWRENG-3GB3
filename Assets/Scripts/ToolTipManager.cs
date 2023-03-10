using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ToolTipManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI windowText;
    [SerializeField]
    private RectTransform tipWindow;
    [SerializeField]
    private float timeToWait = 3f;

    void Start()
    {
        HideTip();
    }

    public void ShowTip(string info, Vector2 mousePos)
    {
        StopAllCoroutines();
        tipWindow.gameObject.SetActive(true);
        windowText.text = info;
        tipWindow.sizeDelta = new Vector2(windowText.preferredWidth > 500 ? 500 : windowText.preferredWidth + 10, windowText.preferredHeight + 10);
        
        //tipWindow.transform.localPosition = new Vector2(mousePos.x - 700, mousePos.y - 500);
        StartCoroutine(StartTimer());
    }

    public void HideTip()
    {
        tipWindow.gameObject.SetActive(false);
        windowText.text = default;
    }

    private IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(timeToWait);

        HideTip();
    }
}
