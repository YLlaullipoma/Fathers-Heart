using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearnJump : MonoBehaviour
{
    public GameObject text;

    private void Start() {
        //text = GameObject.FindGameObjectWithTag("Respawn");
        text.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            text.SetActive(true);
        }
    }
}
