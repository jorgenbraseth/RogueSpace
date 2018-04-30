using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapExit : MonoBehaviour {

    private LevelManager levelManager;

    private float exitAt;
    private float exitTime = 1f;
    private bool exiting;

    private void Start()
    {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }

    private void Update()
    {
        if (exiting && exitAt < Time.time)
        {
            levelManager.LevelComplete();
            exiting = false;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            exiting = false;
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            exiting = true;
            exitAt = Time.time + exitTime;
        }
        
    }


}
