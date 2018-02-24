using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TractorBeam : MonoBehaviour {
    [SerializeField]
    private GameObject _tractorBeamFx;
    
    [SerializeField]
    private float _strength = 10;

    [SerializeField]
    private List<Rigidbody> _targets;
    private Dictionary<Rigidbody, GameObject> _beams;

    // Use this for initialization
    void Start () {
        _targets = new List<Rigidbody>();
        _beams = new Dictionary<Rigidbody, GameObject>();
	}
	
	// Update is called once per frame
	void Update () {

        

        if (_targets.Count > 0)
        {
            List<Rigidbody> targetsToRemove = new List<Rigidbody>();

            foreach (Rigidbody target in _targets)
            {
                if(target != null)
                {
                    Vector3 direction = transform.position - target.transform.position;
                    target.AddForce(direction * _strength / Mathf.Pow(direction.magnitude, 2));

                    GameObject beam;
                    _beams.TryGetValue(target, out beam);
                    beam.transform.position = target.transform.position;
                    beam.transform.rotation = Quaternion.LookRotation(direction);
                }
                else
                {
                    GameObject beam;
                    _beams.TryGetValue(target, out beam);
                    Destroy(beam.gameObject);
                    _beams.Remove(target);
                    targetsToRemove.Add(target);
                }
                
            }

            foreach (Rigidbody target in targetsToRemove)
            {
                _targets.Remove(target);
            }
            
        }

        
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Pickups"))
        {
            Rigidbody target = other.GetComponent<Rigidbody>();
            _targets.Add(target);

            Vector3 targetDirection = transform.position - target.transform.position;
            _beams.Add(target, Instantiate(_tractorBeamFx, target.transform.position, Quaternion.LookRotation(targetDirection)));            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Rigidbody target = other.GetComponent<Rigidbody>();
        GameObject beam;
        _beams.TryGetValue(target, out beam);  
        if(beam != null)
        {
            Destroy(beam.gameObject);
            _beams.Remove(target);
        }
        
        _targets.Remove(target);
    }        
}
