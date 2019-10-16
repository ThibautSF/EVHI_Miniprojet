using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {
    public DoorStatus status;

    private void Start() {
        //Init opened door to his correct animation state
        if (this.status == DoorStatus.Opened) {
			this.GetComponent<Animator>().SetBool("open", true);
			this.GetComponent<Animator>().Play("DoorOpened");
		}
    }
}
