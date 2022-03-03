using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicacionesScene : MonoBehaviour
{
    public GameObject skipButton;
    private void Update() {
        if (FindObjectOfType<GameManager>().isFirstTime) {
            skipButton.SetActive(false);
            return;
        }
        skipButton.SetActive(true);
    }
    public void GoGameplay() {
        string scene = "GamePlay_Lvl1";
        FindObjectOfType<SceneController>().CambiarEscena(scene);
        FindObjectOfType<GameManager>().isFirstTime = false;
    }
}
