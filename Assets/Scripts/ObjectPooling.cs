using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    private bool gameStarted = false;
    public bool moving = false;
    public List<GameObject> chunks;
    public List<GameObject> inactiveChunks;
    private GameObject chunkToPlace;
    public GameObject spawnPoint;

    private Rigidbody rB;
    private float moveSpeed = 0.002f;
    // Start is called before the first frame update
    void Start()
    {
        rB = GetComponent<Rigidbody>();
    }

    public void GameStart()
    {
        if (gameStarted == false)
        {
            StartCoroutine(MoveLevel());
            StartCoroutine(Accelerate());
            gameStarted = true;
        } 
    }

    private IEnumerator MoveLevel()
    {
        Debug.Log("Coroutine started");
        while (moving)
        {
            Debug.Log("Moving down");
            rB.MovePosition(transform.position -= (transform.up * moveSpeed));
            yield return new WaitForSeconds(0);
        }
    }

    private IEnumerator Accelerate()
    {
        while (moving)
        {
            yield return new WaitForSeconds(15);
            Debug.Log("Speeding up" + moveSpeed);
            moveSpeed *= 1.5f;
        }
    }

    public void GetChunk()
    {
        Debug.Log("Getting a chunk");
        ChooseChunk();

        Debug.Log("Spawning chunk");
        // Instantiate(chunkToPlace, spawnPoint.transform.position, spawnPoint.transform.rotation);
        Instantiate(chunkToPlace, spawnPoint.transform.position, spawnPoint.transform.rotation, GameObject.FindGameObjectWithTag("Overlord").transform);
        // chunkToPlace.transform.parent = GameObject.FindGameObjectWithTag("Overlord").transform;
    }

    private void ChooseChunk()
    {
        chunkToPlace = chunks[Random.Range(0, chunks.Count)];
    }
}
