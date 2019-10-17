using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill : MonoBehaviour {
    public GameObject target;

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        if (this.target == null) {
			GameObject player = GameObject.FindWithTag("Player");

            if (player != null)
	        	this.target = player;
			else
				return;
        }

        this.transform.LookAt(target.transform);
        this.GetComponent<MyWeapon>().weapon.GetComponent<Weapon>().RemoteFire();
    }
}
