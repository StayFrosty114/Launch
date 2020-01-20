using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody rB;
    private float launchForce = 5.0f;
    private GameObject cannon;

    private void Awake()
    {
        rB = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rB.AddRelativeForce(0, launchForce, 0, ForceMode.Impulse);
        Invoke("Kill", 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Kill()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            if (GameObject.FindGameObjectWithTag("Cannon").GetComponent<Cannon>().moving == false)
                GameObject.FindGameObjectWithTag("Cannon").GetComponent<Cannon>().moving = true;

            cannon = GameObject.FindGameObjectWithTag("Cannon");
            cannon.transform.position = transform.position;
            GameObject.Find("Overlord").GetComponent<ObjectPooling>().SpawnChunk();
            Destroy(gameObject);
        }
    }
}
