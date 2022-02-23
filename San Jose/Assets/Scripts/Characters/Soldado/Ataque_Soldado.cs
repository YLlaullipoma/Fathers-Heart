using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataque_Soldado : MonoBehaviour
{
    SoldadoModel soldado;

    // Start is called before the first frame update
    void Start() {
        soldado = GetComponent<SoldadoModel>();
        soldado.anim.SetTrigger("StartAtack");
    }

    // Update is called once per frame
    void Update() {

    }
}
