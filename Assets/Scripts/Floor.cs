using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    private Overlord overlord;
    
    private Rigidbody rB;
    void Start()
    {
        overlord = GameObject.FindGameObjectWithTag("Overlord").GetComponent<Overlord>();
        rB = GetComponent<Rigidbody>();
    }

    // Moves the chunk down steadily once the game has started.
    void FixedUpdate()
    {
        if (overlord.gameStarted)
            rB.MovePosition(transform.position -= (transform.up * overlord.moveSpeed));
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trigger"))
        {
            gameObject.SetActive(false);
        }
    }
}
