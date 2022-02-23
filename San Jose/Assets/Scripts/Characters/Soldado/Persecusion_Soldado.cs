using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persecusion_Soldado : MonoBehaviour
{
    SoldadoModel soldado;

    // Start is called before the first frame update
    void Start() {
        soldado = GetComponent<SoldadoModel>();
    }

    // Update is called once per frame
    void Update() {

        FollowPlayer();

        soldado.canAtack = Physics2D.Raycast(transform.position, Vector2.right, soldado.atackRange, soldado.playerLayer)
            || Physics2D.Raycast(transform.position, Vector2.left, soldado.atackRange, soldado.playerLayer);

        if (soldado.canAtack) {
            soldado.estados.ActivarEstado(soldado.estados.estadoAtaque);
        }

        if (!soldado.playerDetected) {
            soldado.estados.ActivarEstado(soldado.estados.estadoPatrulla);
        }
    }

    void FollowPlayer() {
        soldado.soldadoRender.flipX = FlipSoldado();
        transform.position = Vector2.MoveTowards(transform.position, soldado.target.position, soldado.atackSpeed*Time.deltaTime);
    }
    private bool FlipSoldado() {
        if (soldado.target.position.x > transform.position.x) {
            return false;
        }
        return true;
    }

    /*private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(soldado.rayOrigin.position, soldado.rayOrigin.position + Vector3.right * soldado.atackRange);
        Gizmos.DrawLine(soldado.rayOrigin.position, soldado.rayOrigin.position + Vector3.left * soldado.atackRange);
    }*/
}
