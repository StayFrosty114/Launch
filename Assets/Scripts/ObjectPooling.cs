using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public List<GameObject> chunks;
    // Start is called before the first frame update
    void Start()
    {
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
        GameObject[] activeChunks = GameObject.FindGameObjectsWithTag("Chunk");
        Debug.Log("Grabbing chunks");
        foreach (GameObject chunk in activeChunks)
        {
            if (chunk.gameObject.activeInHierarchy)
            {
                Debug.Log("moving active chunks");
                float vertPos = chunk.transform.position.y;
                vertPos = vertPos - 1.6f;
                chunk.transform.position = new Vector3(chunk.transform.position.x, vertPos, chunk.transform.position.z);
            }
        }
    }

    public void GetChunk()
    {
        Debug.Log("Retrieve");
    }
}
