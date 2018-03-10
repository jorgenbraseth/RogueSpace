using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyViewRange : MonoBehaviour {

    [SerializeField]
    private EnemyFollow followBehaviour;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            followBehaviour.TargetSpotted(other.gameObject);
        }       
    }
    

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            followBehaviour.TargetOutOfSight(other.gameObject);
        }
    }

}
