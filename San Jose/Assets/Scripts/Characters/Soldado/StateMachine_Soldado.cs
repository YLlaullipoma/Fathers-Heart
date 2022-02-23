using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine_Soldado : MonoBehaviour
{
    [Header("Estados")]
    public Idle_Soldado estadoIdle;
    public Persecusion_Soldado estadoPersecusion;
    public Ataque_Soldado estadoAtaque;
    public Patrulla_Soldado estadoPatrulla;

    public MonoBehaviour estadoActual;
    public MonoBehaviour estadoInicial;

    void Awake() {
        estadoIdle = GetComponent<Idle_Soldado>();
        estadoPersecusion = GetComponent<Persecusion_Soldado>();
        estadoAtaque = GetComponent<Ataque_Soldado>();
        estadoPatrulla = GetComponent<Patrulla_Soldado>();
    }

    // Start is called before the first frame update
    void Start() {
        ActivarEstado(estadoInicial);
    }

    // Update is called once per frame
    void Update() {

    }

    public void ActivarEstado(MonoBehaviour nuevoEstado) {
        if (estadoActual != null) {
            estadoActual.enabled = false;
        }
        estadoActual = nuevoEstado;
        estadoActual.enabled = true;
    }
}
