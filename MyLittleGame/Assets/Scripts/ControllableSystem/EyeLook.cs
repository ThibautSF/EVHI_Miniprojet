using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeLook : MonoBehaviour {
	// The parent object
	public GameObject myBody;
	// Mouse direction.
	public Vector2 mD;

	void Start () {
		Cursor.lockState = CursorLockMode.Locked;
	}

	void Update () {
		// See mouse cursor again
		if (Input.GetKey(KeyCode.Escape)) {
			if (Cursor.lockState == CursorLockMode.Locked) {
				Cursor.lockState = CursorLockMode.None;
			} else {
				Cursor.lockState = CursorLockMode.Locked;
			}
		}

		if (Cursor.lockState == CursorLockMode.Locked) {
			// How much has the mouse moved?
			Vector2 mC = new Vector2(
				Input.GetAxisRaw ("Mouse X") * 3f,
				Input.GetAxisRaw("Mouse Y") * 3f
				);

			// To prevent over-rotation...
			if (this.transform.rotation.eulerAngles.x < 42f ||
				this.transform.rotation.eulerAngles.x > 360f-42f) {
				mD += mC;
			} else {
				mD.y -= mC.y * 3f;
			}
			// Multiply by 3f in order to create a little 'bounce' so that user does not rotate beyond threshold.

			myBody.transform.localRotation = Quaternion.AngleAxis(mD.x, Vector3.up);

			// Vertical rotation for camera (horizontal is object)
			this.transform.localRotation = Quaternion.AngleAxis(-mD.y, Vector3.right);
		}
	}

	private void OnDestroy() {
		Cursor.lockState = CursorLockMode.None;
	}
}
