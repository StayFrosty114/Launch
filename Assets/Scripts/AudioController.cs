using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{

    public AudioSource aS;

    public bool muted = false;

    private AudioSource camAS;
    // Start is called before the first frame update
    void Start()
    {
        camAS = FindObjectOfType<Camera>().GetComponent<AudioSource>();
        aS = GetComponent<AudioSource>();
        Mute(FindObjectOfType<SettingsManager>().mute);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound(AudioClip aC)
    {
        aS.PlayOneShot(aC);
    }

    public void Mute(bool muted)
    {
        if (muted)
        {
            camAS.mute = true;
            aS.mute = true;
        }
        else
        {
            camAS.mute = false;
            aS.mute = false;
        }
    }
}
