using UnityEngine;
using UnityEngine.AI;

public class VehicleAI : MonoBehaviour
{
	private NavMeshAgent agent;
	
	private void Awake()
	{
		agent = GetComponent<NavMeshAgent>();
	}

	public void InitVehicle(RoadLink destination)
	{
		agent.destination = destination.gameObject.transform.position;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("RoadLink"))
		{
			Vector3? newDestination = other.GetComponent<RoadLink>().GetRandomRoadOutPoint();

			if (newDestination.HasValue)
			{
				agent.destination = newDestination.Value;
			}
		}
	}
	
	//! Register and remove vehicle to chunk
	//! Add weight management depending on nb of vehicles on chunk
}
