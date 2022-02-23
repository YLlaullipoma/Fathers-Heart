using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrulla_Soldado : MonoBehaviour
{
    SoldadoModel soldado;

    public float changeTargetDistance;
    public Transform[] patrolPoints;
    public Vector3 velocity;

    private Vector3 startPosition;

    int currentTarget = 0;

    //private Vector3 currentTarget;
    private Vector3 NewTarget;

    // Start is called before the first frame update
    void Start() {
        soldado = GetComponent<SoldadoModel>();
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update() {
        if (MoveToTarget()) {
            currentTarget = GetNextPoint();
        }

        soldado.soldadoRender.flipX = FlipSoldado();

        if (soldado.playerDetected) {
            soldado.estados.ActivarEstado(soldado.estados.estadoPersecusion);
        }
    }

    private bool MoveToTarget() {
        Vector3 distanceVector = patrolPoints[currentTarget].position - transform.position;
        if(distanceVector.magnitude < changeTargetDistance) {
            return true;
        }
        velocity = distanceVector.normalized;
        transform.position += velocity * soldado.patrolSpeed * Time.deltaTime;


        return false;
    }

    private int GetNextPoint() {
        currentTarget++;
        if(currentTarget >= patrolPoints.Length) {
            currentTarget = 0;
        }

        return currentTarget;
    }

    private bool FlipSoldado() {
        if(velocity.x > 0.1f) {
            return false;
        }
        return true;
    }

    /*private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(soldado.rayOrigin.position, soldado.rayOrigin.position + Vector3.right * soldado.detectionRange);
        Gizmos.DrawLine(soldado.rayOrigin.position, soldado.rayOrigin.position + Vector3.left * soldado.detectionRange);
    }*/
}
