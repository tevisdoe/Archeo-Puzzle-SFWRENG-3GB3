using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Image))]
public class TabButton : MonoBehaviour, IPointerClickHandler
{
    public TabGroup tabGroup;

    public Color baseColour;
    public Color selectedColour;
    public Image background;

    public void OnPointerClick(PointerEventData eventData)
    {
        tabGroup.onTabSelected(this);
    }

    private void Start()
    {
        tabGroup.Subscribe(this);
    }
}
