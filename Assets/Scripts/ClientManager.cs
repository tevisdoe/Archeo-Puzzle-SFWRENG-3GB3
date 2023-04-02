using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ClientManager : MonoBehaviour
{
    public List<GameObject> content;
    public List<GameObject> images;
    public List<GameObject> names;
    public List<GameObject> playButtons;

    public void setClient(int clientNum) 
    {
        for (int i = 0; i < content.Count; i++)
        {
            if (i == clientNum-1) {
                content[i].SetActive(true);
                images[i].SetActive(true);
                names[i].SetActive(true);
                playButtons[i].SetActive(true);
                continue;
            }
            content[i].SetActive(false);
            images[i].SetActive(false);
            names[i].SetActive(false);
            playButtons[i].SetActive(false);
        }
    }
}
