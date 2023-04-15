using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicCarryOver : MonoBehaviour
{
    public void Awake()
    {
        GameObject[] musicObject = GameObject.FindGameObjectsWithTag("GameMusic");
        if(musicObject.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
