using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour {

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private float _speed = 5f;

    private EnemyShootConstantly shotBehaviour;

	// Use this for initialization
	void Start () {
        shotBehaviour = GetComponent<EnemyShootConstantly>();
	}
	
	// Update is called once per frame
	void Update () {
        MoveTowardsPlayer();
	}

    void MoveTowardsPlayer()
    {
        if(player != null)
        {
            transform.LookAt(player.transform);
            GetComponent<Rigidbody>().AddForce(transform.forward * _speed);
        }
    }

    public void TargetSpotted(GameObject spotted)
    {
        shotBehaviour.enabled = true;
        player = spotted;
    }

    public void TargetOutOfSight(GameObject outOfSight)
    {
        shotBehaviour.enabled = false;
        player = null;
    }


}
