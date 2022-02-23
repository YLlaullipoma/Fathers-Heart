using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public string escenaCambiante;
    public float transitionTime;
    public Animator animUI;

    private void Start() {
        if (SceneManager.GetActiveScene().name == "MainMenu") {
            FindObjectOfType<MusicController>().StopMusic("AdventureMusic");
            FindObjectOfType<MusicController>().PlayMusic("Intro");
        }

        if (SceneManager.GetActiveScene().name == "WinLvl1") {
            FindObjectOfType<MusicController>().StopMusic("AdventureMusic");
            FindObjectOfType<MusicController>().PlayMusic("Intro");
        }
    }

    public void CambiarEscena(string Escena) {
        StartCoroutine(LoadScene(Escena));
    }

    public void SalirDelJuego() {
        Application.Quit();
    }

    IEnumerator LoadScene(string newScene) {
        animUI.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(newScene);
    }
}
