using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RoadChunk : MonoBehaviour
{
	private RoadSpawn[] _vehicleSpawns;

	private List<VehicleAI> _chunkCurrentVehicles;

	public bool CheckValidSpawn(out RoadSpawn spawn)
	{
		if (_vehicleSpawns.Length == 0) Debug.LogWarning("No vehicle spawn point found on chunk " + gameObject.name);

		if (_chunkCurrentVehicles.Count == 0)
		{
			int spawnIndex = Random.Range(0, _vehicleSpawns.Length);
			spawn = _vehicleSpawns[spawnIndex];
			return true;
		}
		
		spawn = null;
		return false;
	}
	
	public void RegisterVehicleInChunk(VehicleAI vehicle)
	{
		_chunkCurrentVehicles.Add(vehicle);
	}
}
