using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mute : MonoBehaviour
{

    private SettingsManager sM;
    // Start is called before the first frame update
    void Start()
    {
        sM = GameObject.FindObjectOfType<SettingsManager>();
        GetComponent<Button>().onClick.AddListener(() =>  sM.ToggleMute());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
