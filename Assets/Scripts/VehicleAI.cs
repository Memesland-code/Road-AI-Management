using UnityEngine;
using UnityEngine.AI;

public class VehicleAI : MonoBehaviour
{
	private NavMeshAgent _agent;
	
	private void Awake()
	{
		_agent = GetComponent<NavMeshAgent>();
	}

	public void InitVehicle(RoadLink destination)
	{
		_agent.destination = destination.gameObject.transform.position;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("RoadLink"))
		{
			Vector3? newDestination = other.GetComponent<RoadLink>().GetRandomRoadOutPoint();

			if (newDestination.HasValue)
			{
				_agent.destination = newDestination.Value;
			}
		}
	}
	
	//! Register and remove vehicle to chunk
	//! Add weight management depending on nb of vehicles on chunk
}
