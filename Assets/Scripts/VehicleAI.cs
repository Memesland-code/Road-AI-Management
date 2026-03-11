using UnityEngine;
using UnityEngine.AI;

public class VehicleAI : MonoBehaviour
{
	private NavMeshAgent _agent;
	
	private void Start()
	{
		_agent = GetComponent<NavMeshAgent>();
	}

	public void InitVehicle(Transform destination)
	{
		_agent.SetDestination(destination.position);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("RoadLink"))
		{
			Vector3? newDestination = other.GetComponent<RoadLink>().GetRandomRoadOutPoint();

			if (newDestination.HasValue)
			{
				_agent.SetDestination(newDestination.Value);
			}
		}
	}
	
	//! Register and remove vehicle to chunk
	//! Add weight management depending on nb of vehicles on chunk
}
