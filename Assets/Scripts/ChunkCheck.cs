﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkCheck : MonoBehaviour
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

// Update is called once per frame
    void FixedUpdate()
    {
        if (overlord.gameStarted)
            rB.MovePosition(transform.position -= (transform.forward * overlord.moveSpeed));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trigger"))
        {
            objectPooling.GetChunk();
            objectPooling.Deactivate(gameObject);
        }
    }
}
