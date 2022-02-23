using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicacionesScene : MonoBehaviour
{
    public void GoGameplay() {
        string scene = "GamePlay_Lvl1";
        FindObjectOfType<SceneController>().CambiarEscena(scene);
    }
}
