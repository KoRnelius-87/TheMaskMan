using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundtrackScript : MonoBehaviour
{
    public static SoundtrackScript instance;
    private void Awake()
    {
        if(SoundtrackScript.instance == null)
        {
            SoundtrackScript.instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }     
    }
}
