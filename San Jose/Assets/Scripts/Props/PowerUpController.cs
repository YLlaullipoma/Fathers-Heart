using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{

    bool isCollected  = false;
    public Animator animPowerUp;
    public AudioSource soundEffect;

    private void Start() {
        animPowerUp = GetComponent<Animator>();
        soundEffect = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {
        animPowerUp.SetBool("IsCollected", isCollected);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            isCollected = true;
            soundEffect.Play();
        }
    }

    public void DestroyThisPwUp() {
        Destroy(this.gameObject);
    }
}
