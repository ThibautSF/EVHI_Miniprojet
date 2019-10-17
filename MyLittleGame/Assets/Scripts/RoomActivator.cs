using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomActivator : MonoBehaviour {
    public GameObject roomBeacon;
    public GameObject roomLights;
    public Transform bossSpawner;
    public GameObject boss;

    // Start is called before the first frame update
    void Start() {
        if (roomBeacon != null)
            this.roomBeacon.SetActive(true);

        if (roomLights != null)
            this.roomLights.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (roomBeacon != null)
            this.roomBeacon.SetActive(false);

        if (roomLights != null)
            this.roomLights.SetActive(true);
        
        GameObject b = Instantiate(boss, bossSpawner.position, bossSpawner.rotation) as GameObject;

        this.gameObject.SetActive(false);
    }
}
