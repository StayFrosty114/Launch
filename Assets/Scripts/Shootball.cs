using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shootball : MonoBehaviour
{
    public GameObject ball;
    public GameObject ballSpawn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Fire();
        }
    }

    private void Fire()
    {
        Instantiate(ball, ballSpawn.transform.position, ballSpawn.transform.rotation);
    }
}
