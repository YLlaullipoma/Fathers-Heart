using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DoorDetection : MonoBehaviour
{
    public bool doorDetected;
    public bool puertaTut;
    public bool lostCondition = false;
    public float rayDetectionLeght;
    public int contadorPuertas = 0;
    public LayerMask door;
    public PlayerMovement playerController;

    [HideInInspector]
    public bool powerUp;
    public List<GameObject> listaPuertas = new List<GameObject>();
    public GameObject puertaDetectada;

    int vecesAumentado = 0;

    // Update is called once per frame
    void Update() {
        doorDetected = Physics2D.Raycast(playerController.raycastOriginPoint.position, Vector2.right, rayDetectionLeght, door)
            || Physics2D.Raycast(playerController.raycastOriginPoint.position, Vector2.left, rayDetectionLeght, door);
        VerifyDoorInteractions();
        OverPowerSJ(0.6f);
    }

    #region Interación con Puertas

    void VerifyDoorInteractions() {
        if (playerController.onGround && doorDetected && Input.GetKey(KeyCode.C)) {
            TocandoPuerta();
            AgregarPuertaTocada(puertaDetectada);
        }
    }

    public void TocandoPuerta() {
        playerController.NotMove();
        playerController.knockingDoor = true;
    }

    public void AgregarPuertaTocada(GameObject puerta) {
        listaPuertas.Add(puerta);
        HashSet<GameObject> puertasNoDuplicadas = new HashSet<GameObject>(listaPuertas);
        listaPuertas = puertasNoDuplicadas.ToList();
        
    }

    #endregion

    #region Power Ups & Soldados

    public void OverPowerSJ(float aumento) {
        if (vecesAumentado == 0 && powerUp) {
            playerController.maxSpeed += aumento;
            playerController.moveSpeed += aumento;
            playerController.jumpSpeed += aumento;
            vecesAumentado++;
        }
    }

    #endregion

    private void OnDrawGizmos() {
        Gizmos.DrawLine(playerController.raycastOriginPoint.position, transform.position + Vector3.right * rayDetectionLeght);
        Gizmos.DrawLine(playerController.raycastOriginPoint.position, transform.position + Vector3.left * rayDetectionLeght);
    }

    #region Colisiones Triggers

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Door")) {
            puertaDetectada = collision.gameObject;
        }

        if (collision.CompareTag("PowerUp")) {
            powerUp = true;
        }

        if (collision.CompareTag("Enemy")) {
            lostCondition = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Door")) {
            puertaDetectada = null;
        }

        if (collision.CompareTag("PowerUp")) {
            powerUp = false;
        }
    }
    #endregion
}
