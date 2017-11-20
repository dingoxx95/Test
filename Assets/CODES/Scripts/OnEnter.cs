using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnter : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(this.gameObject);
        Debug.Log("eee");
    }
}
