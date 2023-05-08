using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Collectible : MonoBehaviour
{

    public GameObject[] objectsToSpawn; // List of objects to be spawned
    public int numberOfObjectsToSpawn = 3; // Number of objects to spawn at the beginning
    public List<GameObject> spawnedObjects = new List<GameObject>(); // List of spawned objects
    public List<Vector3> spawnLocations = new List<Vector3>(); // List of spawn locations
    
   
    // Start is called before the first frame update
    void Start()
    {
        
        
        // Get a list of spawn locations
        GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag("CollectibleLocation");
        foreach (GameObject spawnPoint in spawnPoints)
        {   
            spawnLocations.Add(spawnPoint.transform.position);
        }

        // Spawn initial objects
        for (int i = 0; i < numberOfObjectsToSpawn; i++)
        {
            SpawnObject();
        }
    }

    void Update()
    {
      
    }
    void SpawnObject()
    {
        // Select a random object from the list
        int randomIndex = Random.Range(0, objectsToSpawn.Length);
        GameObject objectToSpawn = objectsToSpawn[randomIndex];

        // Spawn the object at a random position
        Vector3 spawnPosition = GetRandomSpawnLocation();
        GameObject spawnedObject = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);

        // Add the spawned object to the list
        spawnedObjects.Add(spawnedObject);
    }

    Vector3 GetRandomSpawnLocation()
    {
        // Select a random spawn location from the list
        int randomIndex = Random.Range(0, spawnLocations.Count);
        Vector3 spawnLocation = spawnLocations[randomIndex];

        // Remove the selected location from the list to avoid spawning multiple objects in the same location
        spawnLocations.RemoveAt(randomIndex);

        return spawnLocation;
    }

    // public void CollectObject(GameObject collectedObject)
    // {
    //     // Remove the collected object from the list
    //     spawnedObjects.Remove(collectedObject);
    //     collected+=1;
    //     // Destroy the collected object after a delay
    //     Destroy(collectedObject);

    // }
}
