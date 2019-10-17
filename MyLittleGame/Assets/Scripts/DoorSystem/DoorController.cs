using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {
	public float activationDistance = 3f;
	public MyDoor[] doors;

	private bool doorIsMoving;
	
	// Start is called before the first frame update
	void Start() {
		//Init each door's component
		foreach (MyDoor door in doors) {
			door.doorComponent = door.doorObject.GetComponent<Door>();
		}
	}

	void OnMouseOver() {
		if (Input.GetButtonDown("Action")) {
			Vector3 distance = Camera.main.transform.position - this.transform.position;

			if (distance.sqrMagnitude <= activationDistance) {
				if (this.doorIsMoving == false) {
					this.doorIsMoving = true;
					
					this.GetComponent<Animator>().Play("ButtonActivate");


					foreach (MyDoor door in doors) {
						switch (door.doorComponent.status) {
							case DoorStatus.Opened:
								door.doorObject.GetComponent<Animator>().SetBool("open", false);
								door.doorComponent.status = DoorStatus.Closed;
								break;

							case DoorStatus.Closed:
								door.doorObject.GetComponent<Animator>().SetBool("open", true);
								door.doorComponent.status = DoorStatus.Opened;
								break;
						}
					}
				}
			}
		}
	}

	// Update is called once per frame
	void Update() {
		if (this.doorIsMoving == true) {
			bool done = true;
			//Check if all doors have ended their animation
			foreach (MyDoor door in doors) {
				if (!door.doorObject.GetComponent<Animator>().IsInTransition(0)) {
					done = false;
					break;
				}
			}

			if (done) {
				this.doorIsMoving = false;
				this.GetComponent<Animator>().Play("ButtonBase");
			}
		}
	}
}

[System.Serializable]
public class MyDoor {
	public GameObject doorObject;

	[HideInInspector]
	public Door doorComponent;
}
