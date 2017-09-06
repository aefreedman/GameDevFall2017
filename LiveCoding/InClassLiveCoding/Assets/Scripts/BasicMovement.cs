using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
	public Rigidbody2D MyRigidbody2D;
	public float ForceStrength;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetAxis("Vertical") > 0)
		{
			Debug.Log("this button moves me up");
//			transform.Translate(new Vector3(0, 1, 0));
//			transform.Translate(Vector2.up * 5);
			MyRigidbody2D.AddForce(Vector2.up * ForceStrength);
			// move up
		}
		if (Input.GetAxis("Vertical") < 0)
		{
			// move down
			
//			transform.Translate(Vector2.down * 5);
//			MyRigidbody2D.MovePosition(Vector2.down * ForceStrength);
			MyRigidbody2D.AddForce(Vector2.down * ForceStrength);

		}
		if (Input.GetAxis("Horizontal") < 0)
		{
			// move left
			MyRigidbody2D.AddForce(Vector2.left * ForceStrength);

		}
		if (Input.GetAxis("Horizontal") > 0)
		{
			// move right
			MyRigidbody2D.AddForce(Vector2.right * ForceStrength);

		}
		
	}
}
