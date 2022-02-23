using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour {
    [Header("Player Detection")]
    public bool playerDetected;
    public float rayDetectionLeght;
    public LayerMask Player;
    public GameObject buttomAlert;

    public Animator doorAnim;
    bool openDoor;
    bool closeDoor;
    [HideInInspector]
    public bool hasBeKnocked = false;

    [Header("Interaction")]
    public bool knocking;
    public bool isClose;
    public PlayerMovement SJ_Controller;

    private void Start() {
        buttomAlert.GetComponent<GameObject>();
        doorAnim = GetComponent<Animator>();
    }

    private void Update() {
        playerDetected = Physics2D.Raycast(transform.position, Vector2.right, rayDetectionLeght, Player) || Physics2D.Raycast(transform.position, Vector2.left, rayDetectionLeght, Player);

        PlayerDetection();
    }

    void PlayerDetection() {

        doorAnim.SetBool("OpenDoor", openDoor);
        doorAnim.SetBool("CloseDoor", closeDoor);

        if (playerDetected) {
            buttomAlert.SetActive(true);
        }

        if (playerDetected && SJ_Controller.confirmDoor) {
            if (!hasBeKnocked) {
                OpenTheDoor();
            }
            else {
                SJ_Controller.PlayerCanMove();
                SJ_Controller.confirmDoor = false;
            }
        }

        if (!playerDetected) {
            buttomAlert.SetActive(false);
        }
    }

    public void OpenTheDoor() {
        openDoor = true;
        closeDoor = false;
        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }
    public void CloseTheDoor() {
        openDoor = false;
        closeDoor = true;
        hasBeKnocked = true;
        SJ_Controller.confirmDoor = false;
        SJ_Controller.PlayerCanMove();
    }
}