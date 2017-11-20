using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerController : MonoBehaviour {
	
	void FixedUpdate () {
		if (Input.GetAxisRaw("Horizontal") == 1)
		{
			transform.position = Vector3.Lerp(transform.position, transform.position + Vector3.right, 0.135f);
		}
		if (Input.GetAxisRaw("Horizontal") == -1)
		{
			transform.position = Vector3.Lerp(transform.position, transform.position - Vector3.right, 0.135f);	
		}
		if (Input.GetAxisRaw("Vertical") == 1)
		{
			transform.position = Vector3.Lerp(transform.position, transform.position + Vector3.up, 0.135f);
		}
		if (Input.GetAxisRaw("Vertical") == -1)
		{
			transform.position = Vector3.Lerp(transform.position, transform.position - Vector3.up, 0.135f);
		}
	}
}
