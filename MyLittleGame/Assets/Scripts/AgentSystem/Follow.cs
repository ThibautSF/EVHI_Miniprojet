using UnityEngine;
using UnityEngine.AI;
using System.Collections;


public class Follow : MonoBehaviour {
	public Transform movingpoint;
	private NavMeshAgent agent;

	void Start () {
		agent = GetComponent<NavMeshAgent>();
		agent.autoBraking = false;
	}

	void Update () {
		if (movingpoint == null)
			return;
		agent.destination = movingpoint.position;
	}
}
