using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxCamera : MonoBehaviour {	
	
    private float scrollSpeed = 10;
	// Update is called once per frame
	void Update () {

        Vector3 mainPos = Camera.main.transform.position;
        transform.localRotation = Quaternion.Euler(-mainPos.z / 10, mainPos.x / 10, 0);

	}
}
