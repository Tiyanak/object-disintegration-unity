using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBall : MonoBehaviour {

	public float speed = 10;
    public Transform myTransform;
	public Transform cameraTransform;
	public Rigidbody rigidbody;
	public bool canJump = true;
	public float jumpForce = 200000;
	public float fallForce = 5;

	// Use this for initialization
	void Start () {
		myTransform = GetComponent<Transform>();
		rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		int horizontal = (int) Input.GetAxisRaw("Horizontal");
		int vertical = (int) Input.GetAxisRaw("Vertical");

		if (horizontal != 0) {
			myTransform.Rotate(0, 3 * horizontal, 0);
		} else if (vertical != 0) {
			myTransform.Translate(Vector3.forward * vertical * speed * Time.deltaTime);
		}

		if (Input.GetKey(KeyCode.Space) && canJump) {			
			rigidbody.AddForce(0, jumpForce, 0);
			canJump = false;
		}

		if (rigidbody.velocity.y < 0) {
			 rigidbody.velocity += Vector3.up * Physics.gravity.y * (fallForce - 1) * Time.fixedDeltaTime;
		}

	}

	void OnCollisionStay(Collision collision) {
		
        if (collision.gameObject.tag == "terrain")
        {
            canJump = true;
        }

        if (collision.gameObject.tag != "terrain")
        {
            canJump = false;
        }
	}
}
