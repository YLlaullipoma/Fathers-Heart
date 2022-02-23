using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MariaController : MonoBehaviour
{
    [Header("Estados")]
    public EstadoEspera estadoEspera_;
    public EstadoDolor estadoDolor_;
    public EstadoSeguir estadoSeguir_;

    public MonoBehaviour estadoActual;
    public MonoBehaviour estadoInicial;

    void Awake() {
        estadoEspera_ = GetComponent<EstadoEspera>();
        estadoDolor_ = GetComponent<EstadoDolor>();
        estadoSeguir_ = GetComponent<EstadoSeguir>();
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
