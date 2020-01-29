using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody rB;
    private float launchForce = 5.0f;
    private GameObject cannon;

    private Overlord overlord;
    private ObjectPooling objectPooling;

    // Start is called before the first frame update
    void Start()
    {
        overlord = GameObject.FindGameObjectWithTag("Overlord").GetComponent<Overlord>();
        objectPooling = GameObject.FindGameObjectWithTag("Overlord").GetComponent<ObjectPooling>();
        cannon = GameObject.FindGameObjectWithTag("Cannon");

        rB = GetComponent<Rigidbody>();
        rB.AddRelativeForce(0, launchForce, 0, ForceMode.Impulse);
        Invoke("Kill", 3);
    }

    // Destroys itself if idle for too long.
    private void Kill()
    {
        Destroy(gameObject);
    }

    // Checks for collision with the TOP of a platform and teleports the cannon to that platform.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            if (transform.position.y >= cannon.transform.position.y)
            {
                overlord.AddPoint();
                cannon.transform.position = transform.position;
                cannon.gameObject.transform.parent = other.gameObject.transform;

                if (overlord.gameStarted == false)
                    overlord.GameStart();
            }
            

            Destroy(gameObject);
        }
    }
}
