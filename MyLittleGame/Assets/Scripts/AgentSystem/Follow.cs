using UnityEngine;
using UnityEngine.AI;
using System.Collections;


public class Follow : MonoBehaviour {
	public Transform movingpoint;
	public float idleTime = 1f;
	private float t = 0f;
	private bool idle = true;
	private NavMeshAgent agent;

	void Start () {
		this.agent = GetComponent<NavMeshAgent>();
		this.agent.autoBraking = false;
	}

	void Update () {
		if (this.idle) {
			this.t += Time.deltaTime;
			if (this.t > idleTime) {
				this.idle = false;
			}
		}

		if (!this.idle) {
			if (this.movingpoint == null) {
				GameObject player = GameObject.FindWithTag("Player");

				if (player != null)
					this.movingpoint = player.transform;
				else
					return;
			}

			this.agent.destination = this.movingpoint.position;
		}
	}
}
