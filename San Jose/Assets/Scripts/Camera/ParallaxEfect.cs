using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEfect : MonoBehaviour
{
    Material mt;
    Vector2 offset;
    Transform camPos;

    public float parallaxSpeed;

    // Start is called before the first frame update
    void Start() {
        SpriteRenderer sp = GetComponent<SpriteRenderer>();
        mt = sp.material;
        camPos = Camera.main.transform;
        offset = mt.mainTextureOffset;
    }

    // Update is called once per frame
    void Update() {

        offset.x = camPos.position.x / transform.localScale.x / parallaxSpeed;
        offset.y = camPos.position.y / transform.localScale.y / parallaxSpeed * 0.5f;

        mt.mainTextureOffset = offset;
    }
}
