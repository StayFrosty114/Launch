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

    private float currentTime;

    private GameObject lastChunk;
    private GameObject newChunk;
    private int spawnRangeMin;
    private int spawnRangeMax;

    public GameObject[] cannons;
    public int cannonSelect = 0;
    public GameObject cannonSpawn;
    
    // Start is called before the first frame update.
    void Start()
    {
        currentTime = 0;
        overlord = GetComponent<Overlord>();

        foreach (GameObject chunk in chunks)
        {
            chunkToPlace = Instantiate(chunk, spawnPoint.transform.position, spawnPoint.transform.rotation, overlord.transform);
            chunkToPlace.SetActive(false);
            inactiveChunks.Add(chunkToPlace);
        }

        // Instantiates 4 random chunks to start
        lastChunk = chunks[2];
        GetChunk();
        chunkToPlace.transform.Translate(0, -chunkToPlace.transform.GetComponent<Collider>().bounds.size.y * 3, 0);
        GetChunk();
        chunkToPlace.transform.Translate(0, -chunkToPlace.transform.GetComponent<Collider>().bounds.size.y * 2, 0);
        GetChunk();
        chunkToPlace.transform.Translate(0, -chunkToPlace.transform.GetComponent<Collider>().bounds.size.y, 0);
        GetChunk();

        // Instantiates the cannon that the player has equipped
        Instantiate(cannons[cannonSelect], cannonSpawn.transform.position, cannonSpawn.transform.rotation, overlord.transform);
    }

    private void Update()
    {
        currentTime = Time.deltaTime * 1;
    }

    // Grabs a chunk from the inactive list and places it at the top.
    public void GetChunk()
    {
        Debug.Log("Getting a chunk");
        chunkToPlace = ChooseChunk();

        Debug.Log("Spawning chunk");
        chunkToPlace.transform.position = spawnPoint.transform.position;
        chunkToPlace.SetActive(true);
        lastChunk = chunkToPlace;
        inactiveChunks.Remove(chunkToPlace);
    }

    // Finds the correct type of chunk in the inactive list.
    private GameObject ChooseChunk()
    {
        
        if (currentTime <= 30)
        {
            spawnRangeMin = 0;
            spawnRangeMax = 5;
            
        }
        else if (currentTime >= 30 && currentTime <= 60)
        {
            spawnRangeMin = 0;
            spawnRangeMax = chunks.Count;
        }
        else
        {
            spawnRangeMin = 2;
            spawnRangeMax = chunks.Count;
        }
        newChunk = chunks[Random.Range(spawnRangeMin, spawnRangeMax)];
        newChunk = CheckChunk(newChunk, lastChunk);
        foreach (GameObject chunk in inactiveChunks)
        {
            if (chunk.name.Contains(newChunk.name))
            {
                return chunk;
            }
        }
        return Instantiate(newChunk, spawnPoint.transform.position, spawnPoint.transform.rotation, overlord.transform);

        // else if (currentTime >= 30 && currentTime <= 60)
        // {
        //     GameObject newChunk = chunks[Random.Range(0, chunks.Count)];
        //     foreach (GameObject chunk in inactiveChunks)
        //     {
        //         if(chunk.name.Contains(newChunk.name))
        //         {
        //             return chunk;
        //         }
        //     }
        //     return Instantiate(newChunk, spawnPoint.transform.position, spawnPoint.transform.rotation, overlord.transform);
        // }
        // else
        // {
        //     GameObject newChunk = chunks[Random.Range(2, chunks.Count)];
        //     foreach (GameObject chunk in inactiveChunks)
        //     {
        //         if (chunk.name.Contains(newChunk.name))
        //         {
        //             return chunk;
        //         }
        //     }
        //     return Instantiate(newChunk, spawnPoint.transform.position, spawnPoint.transform.rotation, overlord.transform);
        // }
    }

    private GameObject CheckChunk(GameObject chunkToCheck, GameObject lastChunk)
    {
        if (lastChunk.name.Contains("L"))
        {
            while (chunkToCheck.name.Contains("R"))
            {
                chunkToCheck = chunks[Random.Range(spawnRangeMin, spawnRangeMax)];
            }
            return chunkToCheck;
        }
        else if (lastChunk.name.Contains("R"))
        {
            while (chunkToCheck.name.Contains("L"))
            {
                chunkToCheck = chunks[Random.Range(spawnRangeMin, spawnRangeMax)];
            }
            return chunkToCheck;
        }
        else if (lastChunk.name.Contains("C"))
        {
            while (chunkToCheck.name.Contains("C"))
            {
                chunkToCheck = chunks[Random.Range(spawnRangeMin, spawnRangeMax)];
            }
            return chunkToCheck;
        }
        else
        {
            Debug.LogError("Checking for unknown piece");
            return chunkToCheck;
        }
    }

    // Deactivates a chunk that hits the bottom trigger and adds it to the inactive list.
    public void Deactivate(GameObject chunk)
    {
        inactiveChunks.Add(chunk);
        chunk.SetActive(false);
    }
}
