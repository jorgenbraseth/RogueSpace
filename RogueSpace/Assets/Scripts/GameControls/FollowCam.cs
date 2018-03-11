using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour {

    [SerializeField]
    private GameObject _following;
	
	// Update is called once per frame
	void Update () {
        Vector3 _followingPos = _following.transform.position;
        Vector3 myPos = transform.position;
        transform.transform.position = new Vector3(_followingPos.x, myPos.y, _followingPos.z);
	}
}
