using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour {

    private GameObject player;

    [SerializeField]
    private float _speed = 5f;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        MoveTowardsPlayer();
        Shoot();
	}

    void MoveTowardsPlayer()
    {
        transform.LookAt(player.transform);
        GetComponent<Rigidbody>().AddForce(transform.forward * _speed);
    }

    void Shoot()
    {

    }
}
