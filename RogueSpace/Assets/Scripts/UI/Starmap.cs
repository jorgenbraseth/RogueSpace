using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starmap : MonoBehaviour {
	
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.back, 0.1f, Space.Self);
	}
}
