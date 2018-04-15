using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ObjectivePointers : MonoBehaviour {    
    [SerializeField]
    private GameObject enemyPointer;

    [SerializeField]
    private GameObject asteroidPointer;

    [SerializeField]
    private GameObject exitPointer;    

    private List<ObjectivePointer> objectivePointers = new List<ObjectivePointer>();

	// Use this for initialization
	void Start () {        
           
	}

    public void AddExit(MapExit exit)
    {
        objectivePointers.Add(new ObjectivePointer(exit.gameObject, Instantiate(exitPointer, transform)));
    }

    public void AddEnemy(Enemy enemy)
    {
        objectivePointers.Add(new ObjectivePointer(enemy.gameObject, Instantiate(exitPointer, transform)));
    }

    public void AddObjective(GameObject objective)
    {
        objectivePointers.Add(new ObjectivePointer(objective, Instantiate(exitPointer, transform)));
    }

    public void AddResource(GameObject resource)
    {
        objectivePointers.Add(new ObjectivePointer(resource, Instantiate(asteroidPointer, transform)));
    }

    // Update is called once per frame
    void Update () {        
        MovePointers();
	}

    private void LateUpdate()
    {
        List<ObjectivePointer> toDelete = new List<ObjectivePointer>();
        foreach (ObjectivePointer op in objectivePointers)
        {
            if (op._objective == null)
            {
                toDelete.Add(op);                
            }            
        }
        
        foreach(ObjectivePointer op in toDelete)
        {
            objectivePointers.Remove(op);
            Destroy(op._pointer);
        }
    }



    private void MovePointers()
    {
        Camera cam = Camera.main;
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(cam);

        Vector3 centerScreen = new Vector3(Screen.width / 2, Screen.height / 2, 0);

        foreach (ObjectivePointer op in objectivePointers)
        {
            GameObject obj = op._objective;

            if(obj == null)
            {
                Debug.Log(op._pointer);
                continue;
            }
           
            GameObject p = op._pointer;

            Vector3 objScreenPos = Camera.main.WorldToScreenPoint(obj.transform.position);
            Collider objCol = obj.GetComponent<Collider>();

            p.SetActive(obj.activeInHierarchy && !GeometryUtility.TestPlanesAABB(planes, objCol.bounds));

            Vector3 diff = objScreenPos - centerScreen;
            float angle = Vector3.Angle(new Vector3(0, 1, 0), diff);

            if (diff.x > 0)
            {
                angle = -angle;
            }

            p.transform.localRotation = Quaternion.Euler(0, 0, angle);
            Vector3 ppos = objScreenPos;
            ppos.x = Mathf.Clamp(ppos.x, 30, Screen.width - 30);
            ppos.y = Mathf.Clamp(ppos.y, 30, Screen.height - 30);
            p.transform.position = ppos;
        }
    }
}

[Serializable]
public class ObjectivePointer
{
    public GameObject _objective;
    public GameObject _pointer;

    public ObjectivePointer(GameObject objective, GameObject pointer)
    {
        _objective = objective;
        _pointer = pointer;
    }
}

