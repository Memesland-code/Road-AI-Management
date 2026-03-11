using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RoadLink : MonoBehaviour
{
	[SerializeField] private bool _showColliders;
	[SerializeField] private List<RoadLink> _roadOutPath = new List<RoadLink>();

	public Vector3? GetRandomRoadOutPoint()
	{
		if (_roadOutPath.Count > 0)
		{
			RoadLink selectedOutRoadLink = _roadOutPath[Random.Range(0, _roadOutPath.Count)];
			return selectedOutRoadLink.gameObject.transform.position;
		}

		return null;
	}
	
	private void OnDrawGizmos()
	{
		if (_showColliders)
			Gizmos.DrawWireCube(transform.position, new Vector3(3.5f, 7.5f, 3.5f));
	}
}
