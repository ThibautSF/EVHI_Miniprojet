using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonActions : MonoBehaviour {
    public void exitGame() {
        Application.Quit();
    }

    public void restartGame() {
        SceneManager.LoadScene("MainScene");
    }
}
