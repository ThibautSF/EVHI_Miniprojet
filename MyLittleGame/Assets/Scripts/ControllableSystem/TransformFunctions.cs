using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformFunctions : MonoBehaviour {
	public float moveSpeed = 2f;
	public float moveRunSpeed = 5f;
	public float jumpSpeed = 0.6f;

	public bool isGrounded;

	// Start is called before the first frame update
	void Start() {
		
	}

	void OnCollisionStay() {
        isGrounded = true;
    }

	// Update is called once per frame
	void Update() {
		float mSpeed = (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) ? this.moveRunSpeed : this.moveSpeed;
		
		float movement = Input.GetAxis("Vertical");
		movement *= Time.deltaTime * mSpeed;
		float sideStep = Input.GetAxis ("Horizontal");
		sideStep *= Time.deltaTime * mSpeed;

		this.transform.Translate(Vector3.forward * movement);
		this.transform.Translate(Vector3.right * sideStep);

		if (Input.GetAxis("Jump") > 0 && isGrounded) {
			this.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
			this.isGrounded = false;
		}
	}
}
