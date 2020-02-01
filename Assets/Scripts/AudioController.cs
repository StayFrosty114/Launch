using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{

    public AudioSource aS;
    // Start is called before the first frame update
    void Start()
    {
        aS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound(AudioClip aC)
    {
        aS.PlayOneShot(aC);
    }
}
