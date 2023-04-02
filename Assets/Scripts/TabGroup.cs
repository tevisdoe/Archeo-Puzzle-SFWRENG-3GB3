using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabGroup : MonoBehaviour
{
    public List<TabButton> tabButtons;
    public Image databankBackground;
    public ScrollRect scrollArea;
    public AudioSource artifactSource;
    public AudioClip tabClip;
    public List<GameObject> info;
    private int currentIndex;

    public void Subscribe(TabButton button)
    {
        tabButtons ??= new List<TabButton>();

        tabButtons.Add(button);
    }

    public void onTabSelected(TabButton button)
    {
        ResetTabs();
        button.background.color = button.selectedColour;
        databankBackground.color = button.selectedColour;

        int index = button.transform.GetSiblingIndex();
        if (index != currentIndex && artifactSource) artifactSource.PlayOneShot(tabClip);
        currentIndex = index;

        for (int i = 0; i < info.Count; i++)
        {
            if (i == index)
            {
                info[i].SetActive(true);
                scrollArea.content = info[i].GetComponent<RectTransform>();
                scrollArea.verticalNormalizedPosition = 1f;
                
            }
            else info[i].SetActive(false);
        }

    }

    public void ResetTabs()
    {
        foreach(TabButton button in tabButtons)
        {
            button.background.color = button.baseColour;
        }
    }
}
