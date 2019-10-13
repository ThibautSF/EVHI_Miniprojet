using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {
	public float activationDistance = 3f;

	public GameObject door;
	public DoorStatus doorStatus = DoorStatus.Closed;

	private bool doorIsMoving;
	private Animator doorAnim;
	private Animator btnAnim;

	public enum DoorStatus {
		Opened,
		Closed
	}
	
	// Start is called before the first frame update
	void Start() {
		this.doorAnim = this.door.GetComponent<Animator>();
		this.btnAnim = this.GetComponent<Animator>();
	}

	void OnMouseOver() {
		if (Input.GetButtonDown("Action")) {
			Vector3 distance = Camera.main.transform.position - door.transform.position;

			if (distance.sqrMagnitude <= activationDistance) {
				if (this.doorIsMoving == false) {
					this.doorIsMoving = true;

					btnAnim.Play("ButtonActivate");

					switch(doorStatus) {
						case DoorStatus.Opened:
							doorAnim.SetBool("open", false);
							this.doorStatus = DoorStatus.Closed;
							break;

						case DoorStatus.Closed:
							doorAnim.SetBool("open", true);
							this.doorStatus = DoorStatus.Opened;
							break;
					}
				}
			}
		}
	}

	// Update is called once per frame
	void Update() {
		if (this.doorIsMoving == true && this.doorAnim.IsInTransition(0)) {
			this.doorIsMoving = false;
		}
	}
}
