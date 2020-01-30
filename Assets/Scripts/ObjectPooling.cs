using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    private Overlord overlord;

    public bool moving = false;
    public List<GameObject> chunks;
    public List<GameObject> inactiveChunks;
    private GameObject chunkToPlace;
    public GameObject spawnPoint;
    
    // Start is called before the first frame update.
    void Start()
    {
        overlord = GetComponent<Overlord>();

        foreach (GameObject chunk in chunks)
        {
            chunkToPlace = Instantiate(chunk, spawnPoint.transform.position, spawnPoint.transform.rotation, overlord.transform);
            chunkToPlace.SetActive(false);
            inactiveChunks.Add(chunkToPlace);
        }
    }

    // Grabs a chunk from the inactive list and places it at the top.
    public void GetChunk()
    {
        Debug.Log("Getting a chunk");
        chunkToPlace = ChooseChunk();

        Debug.Log("Spawning chunk");
        chunkToPlace.transform.position = spawnPoint.transform.position;
        chunkToPlace.SetActive(true);
        inactiveChunks.Remove(chunkToPlace);
    }

    // Finds the correct type of chunk in the inactive list.
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
        return Instantiate(newChunk, spawnPoint.transform.position, spawnPoint.transform.rotation, overlord.transform);
    }

    // Deactivates a chunk that hits the bottom trigger and adds it to the inactive list.
    public void Deactivate(GameObject chunk)
    {
        inactiveChunks.Add(chunk);
        chunk.SetActive(false);
    }
}
