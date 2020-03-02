using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkController : MonoBehaviour
{
    private Overlord overlord;
    private ObjectPooling objectPooling;
    private Rigidbody rB;

    // Start is called before the first frame update
    void Start()
    {
        objectPooling = GameObject.FindGameObjectWithTag("Overlord").GetComponent<ObjectPooling>();
        overlord = GameObject.FindGameObjectWithTag("Overlord").GetComponent<Overlord>();
        rB = GetComponent<Rigidbody>();
    }

// Moves the chunk down steadily once the game has started.
    void FixedUpdate()
    {
        if (overlord.gameStarted)
            rB.MovePosition(transform.position -= (transform.up * (overlord.moveSpeed + overlord.rubberBand)));
    }

    // If chunk hits bottom trigger, it deactivates itself and spawns a new chunk at the top.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trigger"))
        {
            objectPooling.GetChunk();
            objectPooling.Deactivate(gameObject);
        }
    }
}
