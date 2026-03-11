using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class RoadManager : MonoBehaviour
{
	[SerializeField] private GameObject _vehiclePrefab;
	
	private int _carSpawnNumber = 1;
	private GameObject[] _roadsArray;
	
    void Start()
    {
	    _roadsArray = GameObject.FindGameObjectsWithTag("Road");
	    InitVehicles();
    }

    private void InitVehicles()
    {
	    for (int i = 0; i < _carSpawnNumber; i++)
	    {
		    RoadChunk spawnRoad = _roadsArray[Random.Range(0, _roadsArray.Length)].GetComponent<RoadChunk>();
		    if (spawnRoad.CheckValidSpawn(out RoadSpawn spawn))
		    {
			    print(spawn.SpawnPoint.position);
				VehicleAI vehicle = Instantiate(_vehiclePrefab, spawn.SpawnPoint.position, spawn.SpawnPoint.rotation, GameObject.FindWithTag("VehiclesContainer").transform).GetComponent<VehicleAI>();
				vehicle.InitVehicle(spawn.Destination);
		    }
	    }
    }
}

[Serializable]
public class RoadSpawn
{
	public Transform SpawnPoint;
	public Transform Destination;
}
