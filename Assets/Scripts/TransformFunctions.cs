using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformFunctions : MonoBehaviour
{
	public float moveSpeed = 2f;
    public float moveRunSpeed = 5f;
	public float turnSpeed = 100f;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        float mSpeed = (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) ? moveRunSpeed : moveSpeed;
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Z)) {
        	transform.Translate(Vector3.forward * mSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) {
        	transform.Translate(-Vector3.forward * mSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.Q)) {
        	transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) {
        	transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
        }
    }
}
