using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    public GameObject pausePanel;
    public Animator pausePanelAnim;
    public bool isPaused = false;

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.Escape) && !isPaused) {
            pausePanelAnim.SetTrigger("Pause");
            isPaused = true;
        }
    }

    public void Pausar() {
        Time.timeScale = 0f;
    }

    public void Reanudar() {
        isPaused = false;
        Time.timeScale = 1f;
        pausePanelAnim.SetTrigger("Pause");
    }
}
