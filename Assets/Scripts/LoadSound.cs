using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSound : MonoBehaviour
{
    private void Awake()
    {
        SetUpSingleton();
    }

    private void SetUpSingleton()
    {
        int loadSoundLength = FindObjectsOfType<LoadSound>().Length;
        if (loadSoundLength > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}