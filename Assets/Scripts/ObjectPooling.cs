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
    
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject chunk in chunks)
        {
            chunkToPlace = Instantiate(chunk, spawnPoint.transform.position, spawnPoint.transform.rotation, GameObject.FindGameObjectWithTag("Overlord").transform);
            chunkToPlace.SetActive(false);
            inactiveChunks.Add(chunkToPlace);
        }
    }

    public void GetChunk()
    {
        Debug.Log("Getting a chunk");
        chunkToPlace = ChooseChunk();

        Debug.Log("Spawning chunk");
        chunkToPlace.transform.position = spawnPoint.transform.position;
        chunkToPlace.SetActive(true);
        inactiveChunks.Remove(chunkToPlace);
        // chunkToPlace.transform.parent = GameObject.FindGameObjectWithTag("Overlord").transform;
    }

    private GameObject ChooseChunk()
    {
        GameObject newChunk = chunks[Random.Range(0, chunks.Count)];
        foreach (GameObject chunk in inactiveChunks)
        {
            if(chunk.name.Contains(newChunk.name))
            {
                return chunk;
            }
        }
        return Instantiate(newChunk, spawnPoint.transform.position, spawnPoint.transform.rotation, GameObject.FindGameObjectWithTag("Overlord").transform);
    }

    public void Deactivate(GameObject chunk)
    {
        inactiveChunks.Add(chunk);
        chunk.SetActive(false);
    }
}
