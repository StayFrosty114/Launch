using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugGooglePlayText : MonoBehaviour
{
    void Start()
    {
        //Remove when testing
#if UNITY_ANDROID
        this.gameObject.SetActive(false);
    #endif
    }
}
