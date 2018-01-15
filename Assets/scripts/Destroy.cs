using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {

	public GameObject destroyedVersion;

	void OnCollisionEnter(Collision collision) {

		if (collision.collider.tag == "Player") {
			Instantiate(destroyedVersion, transform.position, transform.rotation);
			Destroy(gameObject);
		}

	}

}
