using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GapSystem : MonoBehaviour {
    public GameObject respawnPoint;

    private void OnTriggerEnter(Collider other) {
        if(other.tag =="Player") {
            other.transform.position = Vector3.MoveTowards(other.transform.position, respawnPoint.transform.position, 100);

            other.GetComponent<Health>().ChangeHealth(-25f);
        } 
    }
}
