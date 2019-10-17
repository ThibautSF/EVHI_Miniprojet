using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlwaysFace : MonoBehaviour {
    public GameObject target;
    public float speed = 360f;

    public float xAngleCorrection = 0f;
    public float yAngleCorrection = 0f;
    public float zAngleCorrection = 0f;

    private void Start() {
        
    }

    // Update is called once per frame
    void LateUpdate() {
        if (target == null) {
            this.target = GameObject.FindWithTag("Player");
            return;
        }
        
        Quaternion targetRotation = Quaternion.LookRotation(target.transform.position - this.transform.position);
        targetRotation *= Quaternion.Euler(xAngleCorrection, yAngleCorrection, zAngleCorrection);

        float s = this.speed * Time.deltaTime;

        this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, targetRotation, s);
    }
}
