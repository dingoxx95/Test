using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouseDownTest : MonoBehaviour {

    void OnMouseDown()
    {
        // this object was clicked - do something
        Destroy(this.gameObject);
        Debug.Log("eee");
    }

}
