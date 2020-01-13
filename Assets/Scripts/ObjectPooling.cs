using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public List<GameObject> chunks;
    // Start is called before the first frame update
    void Start()
    {
        SpawnChunk();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnChunk()
    {

    }

    public void GetChunk()
    {
        Debug.Log("Retrieve");
    }
}
