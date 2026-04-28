using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RoadChunk : MonoBehaviour
{
	[SerializeField] private RoadSpawn[] vehicleSpawns;

	private List<VehicleAI> chunkCurrentVehicles = new List<VehicleAI>();

	public bool CheckValidSpawn(out RoadSpawn spawn)
	{
		if (vehicleSpawns.Length == 0)
		{
			Debug.LogWarning("No vehicle spawn point found on chunk " + gameObject.name + " at location " + gameObject.transform.position);
			spawn = null;
			return false;
		}
		
		if (chunkCurrentVehicles.Count == 0)
		{
			int spawnIndex = Random.Range(0, vehicleSpawns.Length);
			spawn = vehicleSpawns[spawnIndex];
			return true;
		}
		
		spawn = null;
		return false;
	}
	
	public void RegisterVehicleInChunk(VehicleAI vehicle)
	{
		chunkCurrentVehicles.Add(vehicle);
	}
}
