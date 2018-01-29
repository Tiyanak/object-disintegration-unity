using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.scripts;
public class Fracture : MonoBehaviour {

	// Use this for initialization
	public GameObject fracturingObject;

    void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.tag == "Player")
        {
          StartCoroutine(gameObject.GetComponent<TriangleExplosion>().SplitMesh(true));
        }

    }
}
