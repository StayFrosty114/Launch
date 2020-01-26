using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    private bool gameStarted = false;
    public List<GameObject> chunks;
    public GameObject spawnPoint;

    private Rigidbody rB;
    private float moveSpeed = 0.001f;
    // Start is called before the first frame update
    void Start()
    {
        rB = GetComponent<Rigidbody>();

        foreach (GameObject chunk in chunks)
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnChunk()
    {
        if (gameStarted == false)
        {
            StartCoroutine(MoveLevel());
            gameStarted = true;
        }

        // GameObject[] activeChunks = GameObject.FindGameObjectsWithTag("Chunk");
        // Debug.Log("Grabbing chunks");
        // foreach (GameObject chunk in activeChunks)
        // {
        //     if (chunk.gameObject.activeInHierarchy)
        //     {
        //         Debug.Log("moving active chunks");
        //         float vertPos = chunk.transform.position.y;
        //         vertPos -= 1.6f;
        //         chunk.transform.position = new Vector3(chunk.transform.position.x, vertPos, chunk.transform.position.z);
        //     }
        // }
    }

    private IEnumerator MoveLevel()
    {
        Debug.Log("Coroutine started");
        while (GetComponentInChildren<Cannon>().moving)
        {
            Debug.Log("Moving down");
            rB.MovePosition(transform.position -= (transform.up * moveSpeed));
            yield return new WaitForSeconds(0);
        }
    }

    public void GetChunk()
    {
        Debug.Log("Retrieve");
        foreach (GameObject chunk in chunks)
        {
            if (chunk.gameObject.activeInHierarchy == false)
            {
                chunk.gameObject.transform.position = spawnPoint.transform.position;
            }
        }
        // chunks[Random.Range]
    }
}
