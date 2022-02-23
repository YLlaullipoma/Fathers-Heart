using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SJ_AudioController : MonoBehaviour
{

    [Header("SJ_ Sound Effects")]
    public AudioClip Steps;
    public AudioClip jump;
    public AudioClip Door;

    [Header("Components")]
    public AudioSource audioSJ;
    public PlayerMovement sjController;


    // Start is called before the first frame update
    void Start() {
        audioSJ.loop = false;
        FindObjectOfType<MusicController>().StopMusic("Menu");
        FindObjectOfType<MusicController>().PlayMusic("AdventureMusic");
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void Pisando() {
        audioSJ.clip = Steps;
        audioSJ.volume = 0.25f;
        audioSJ.Play();
    }

    public void TocandoPuertaSonido() {
        audioSJ.clip = Door;
        audioSJ.volume = 1f;
        audioSJ.Play();
    }

    public void JumpSound() {
        audioSJ.Stop();
        audioSJ.clip = jump;
        audioSJ.volume = 1f;
        audioSJ.Play();
    }
}
