using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarreraTutorial : MonoBehaviour
{
    public bool desactivar;
    BoxCollider2D barrera;

    private void Start() {
        barrera = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (desactivar) {
            barrera.enabled = false;
        }
    }
}
