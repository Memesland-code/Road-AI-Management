using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RoadLink : MonoBehaviour
{
	[SerializeField] private bool showColliders;
	[SerializeField] private List<RoadLink> roadOutPath = new List<RoadLink>();

	public Vector3? GetRandomRoadOutPoint()
	{
		if (roadOutPath.Count > 0)
		{
			RoadLink selectedOutRoadLink = roadOutPath[Random.Range(0, roadOutPath.Count)];
			return selectedOutRoadLink.gameObject.transform.position;
		}

		return null;
	}
	
	private void OnDrawGizmos()
	{
		if (showColliders)
			Gizmos.DrawWireCube(transform.position, new Vector3(3.5f, 7.5f, 3.5f));
		
		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere(transform.position, 0.25f);
	}
}
