using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Showcased : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0.5f, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
