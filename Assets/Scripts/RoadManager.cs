using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class RoadManager : MonoBehaviour
{
	[SerializeField] private GameObject vehiclePrefab;
	
	[SerializeField] private int vehicleSpawnNumber = 1;
	[SerializeField] private int spawnErrorsLimit = 100;
	private GameObject[] roadsArray;
	
    void Start()
    {
	    roadsArray = GameObject.FindGameObjectsWithTag("Road");
	    InitVehicles();
    }

    private void InitVehicles()
    {
	    int successfullySpawned = 0;
	    int currentSpawnErrors = 0;

	    while (successfullySpawned < vehicleSpawnNumber && currentSpawnErrors < spawnErrorsLimit)
	    {
		    RoadChunk spawnRoad = roadsArray[Random.Range(0, roadsArray.Length)].GetComponent<RoadChunk>();
		    if (spawnRoad.CheckValidSpawn(out RoadSpawn spawn))
		    {
			    VehicleAI vehicle = Instantiate(vehiclePrefab, spawn.SpawnPoint.position, spawn.SpawnPoint.rotation, GameObject.FindWithTag("VehiclesContainer").transform).GetComponent<VehicleAI>();
			    vehicle.InitVehicle(spawn.ExitLinkDestination);
			    successfullySpawned++;
		    }
		    else
		    {
			    currentSpawnErrors++;
		    }
	    }
	    
	    Debug.Log($"InitVehicle() finished executing!" +
	              $"\nSpawned {successfullySpawned}/{vehicleSpawnNumber} vehicles with {currentSpawnErrors} spawn errors.");
    }
}

[Serializable]
public class RoadSpawn
{
	public Transform SpawnPoint;
	public RoadLink ExitLinkDestination;
}
