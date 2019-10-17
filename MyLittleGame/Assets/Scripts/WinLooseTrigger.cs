using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLooseTrigger : MonoBehaviour {
    public bool destructionMakeWin = true;

    private GameObject winScreen;
    private GameObject looseScreen;

    private void Start() {
        GameObject endScreen = GameObject.FindWithTag("EndScreen");

        if (endScreen != null) {
            winScreen = endScreen.transform.Find("WinScreen").gameObject;
            looseScreen = endScreen.transform.Find("LooseScreen").gameObject;
        }
    }

    private void OnDestroy() {
        if (winScreen != null)
            winScreen.SetActive(destructionMakeWin);
        
        if (looseScreen != null)
            looseScreen.SetActive(!destructionMakeWin);
        
        if (destructionMakeWin) {
            GameObject player = GameObject.FindWithTag("Player");
            if (player)
                player.SetActive(false);
        }

        Cursor.lockState = CursorLockMode.None;
    }
}
