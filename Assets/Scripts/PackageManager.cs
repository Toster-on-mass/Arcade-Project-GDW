using System.Linq;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PackageManager : MonoBehaviour
{
    public Package packagePrefab;
    public Vector3[] spawnLocations;
    private Package[] spawnedPackages;

    void Start()
    {
        SpawnPackages(2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnPackages(int packagesToSpawn)
    {
        for (int i = 0; i < packagesToSpawn; i++)
        {
            int spawnIndex = Random.Range(0, spawnLocations.Length);
            SpawnPackageAtPosition(spawnLocations[spawnIndex]);
        }

        // My attempt on having be in diffrent spawn locations
        // Currently they can spawn in the same spot
        
        /*Debug.Log("Spawning Packages");
        Vector3[] spawningPositions = new Vector3[0];

        for (int i = 0; i < packagesToSpawn; i++)
        {
            Vector3 newSpawnPos;
            newSpawnPos = GetUniqueSpawnPos(spawningPositions);
            spawnLocations
            spawningPositions.Append<Vector3>(newSpawnPos);
            Debug.Log("Got Spawn Location");
            Debug.Log(spawningPositions);
        }

        for (int i = 0; i < spawningPositions.Length; i++)
        {
            SpawnPackageAtPosition(spawningPositions[i]);
            Debug.Log("Spawned Package");
        }*/
    }

    void SpawnPackageAtPosition(Vector3 spawnPoint)
    {
        Package newPackage = Instantiate(packagePrefab,spawnPoint,packagePrefab.transform.rotation);
        newPackage.transform.SetParent(gameObject.transform);
    }

    public void RemoveAllChildren()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }

    public void ResetPackages()
    {
        RemoveAllChildren();
        SpawnPackages(2);
    }

    // Has a chance to go infinite, so need to make sure there are plenty of spawn points and not too many packages called 
    Vector3 GetUniqueSpawnPos(Vector3[] currentSpawnPositions)
    {
        int spawnIndex = -1;

        while (spawnIndex == -1 || currentSpawnPositions.Contains(spawnLocations[spawnIndex]))
        {
            spawnIndex = Random.Range(0,spawnLocations.Length);
        }

        return spawnLocations[spawnIndex];
    }
}
