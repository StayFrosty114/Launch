using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionManager : MonoBehaviour
{
    void Start()
    {
        FindObjectOfType<SettingsManager>().LoadOptions();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
