using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shootball : MonoBehaviour
{
    public GameObject ball;
    public GameObject ballSpawn;

    private AudioController audioCon;
    public AudioClip cannonShot;
    

    private void Start()
    {
        audioCon = GameObject.FindGameObjectWithTag("Overlord").GetComponent<AudioController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Checks for input.
        if (Input.GetMouseButtonUp(0))
        {
            Fire();
            audioCon.PlaySound(cannonShot);
        }
    }

    // Instantiates a cannonball and fires it in the barrel direction.
    private void Fire()
    {
        Instantiate(ball, ballSpawn.transform.position, ballSpawn.transform.rotation);
    }
}
