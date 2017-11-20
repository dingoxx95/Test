using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

   
    private Transform thisTransform = null;
    private SpriteRenderer thisRenderer = null;
    private Animator thisAnimator = null;
    float horizontalAxis, verticalAxis;
    public float speed = 100f;
    Vector2 mouse, player = new Vector2();
    bool flipped = false;

    void Awake () {
        thisTransform = GetComponent<Transform>();
        thisRenderer = GetComponent<SpriteRenderer>();
        thisAnimator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void FixedUpdate() {
        mouse = Input.mousePosition;
        player = Camera.main.WorldToScreenPoint(thisTransform.transform.position);
        //if (mouse.x < player.x)
        //{
        //    thisAnimator.Play("SpikeGoLeft");
        //}
        //else
        //{
        //    thisAnimator.Play("SpikeIdle");
        //}

        verticalAxis = Input.GetAxis("Vertical");
        horizontalAxis = Input.GetAxis("Horizontal");
       
        thisTransform.position += thisTransform.up * speed * verticalAxis * Time.deltaTime;
        thisTransform.position += thisTransform.right * speed * horizontalAxis * Time.deltaTime;
    }

}
