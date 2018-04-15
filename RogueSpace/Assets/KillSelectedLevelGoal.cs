using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillSelectedLevelGoal : MonoBehaviour {

    LevelManager level;

    [SerializeField]
    Enemy[] toKill;

	// Use this for initialization
	void Start () {
        level = GameObject.Find("LevelManager").GetComponent<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
        bool allKilled = true;
		foreach (Enemy e in toKill)
        {
            if (e != null)
            {
                allKilled = false;
            }
        }

        if (allKilled)
        {
            level.ObjectiveComplete();
        }
	}
    
}
