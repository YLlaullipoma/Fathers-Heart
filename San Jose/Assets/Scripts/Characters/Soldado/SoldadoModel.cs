using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldadoModel : MonoBehaviour
{
    [Header ("Atributes")]
    public float patrolSpeed;
    public float atackSpeed;
    public float detectionRange;
    public float atackRange;
    public bool canAtack;
    public bool playerDetected;
    //public bool canFollow;

    [Header ("Componetes Refs")]
    public Transform target;
    public Transform rayOrigin;
    public Animator anim;
    public SpriteRenderer soldadoRender;
    public StateMachine_Soldado estados;
    public GameObject espada;
    public LayerMask playerLayer;

    // Start is called before the first frame update
    void Start() {
        anim = GetComponent<Animator>();
        estados = GetComponent<StateMachine_Soldado>();
        soldadoRender = GetComponent<SpriteRenderer>();

        espada.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        playerDetected = Physics2D.Raycast(rayOrigin.position, Vector2.right, detectionRange, playerLayer)
            || Physics2D.Raycast(rayOrigin.position, Vector2.left, detectionRange, playerLayer);

        anim.SetBool("Follow", playerDetected);
    }

    public void Atack() {
        espada.SetActive(true);
    }

    public void FinishAtack() {
        espada.SetActive(false);
    }
    
}
