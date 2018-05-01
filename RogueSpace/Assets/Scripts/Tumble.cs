using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tumble : MonoBehaviour {

    [SerializeField]
    private float _tumbleAmount = 2f;

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * _tumbleAmount;        
    }
	

}

