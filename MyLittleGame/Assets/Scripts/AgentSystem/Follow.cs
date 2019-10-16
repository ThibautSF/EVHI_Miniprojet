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
		agent.destination = movingpoint.position;
	}
}
