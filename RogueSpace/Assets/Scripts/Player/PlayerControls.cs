using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerControls : MonoBehaviour {

    [SerializeField]
    private float _enginePower = 10;
    [SerializeField]
    private float _turnPower = 10;

    [SerializeField]
    private GameObject _leftThruster;

    [SerializeField]
    private GameObject _rightThruster;

    [SerializeField]
    private GameObject _mainEngine;

    private ParticleSystem _engineFlame;

    Rigidbody _body;

	// Use this for initialization
	void Start () {
        _body = GetComponent<Rigidbody>();
        _engineFlame = _mainEngine.GetComponent<ParticleSystem>();

    }
	
	// Update is called once per frame
	void Update () {
        float horizontal = CrossPlatformInputManager.GetAxis("Horizontal") + Input.GetAxis("Horizontal");                
        float vertical = CrossPlatformInputManager.GetAxis("Vertical") + Input.GetAxis("Vertical");
        
        Vector3 targetDirection = new Vector3(horizontal, 0, vertical);
        Vector3 lookDirection = Vector3.RotateTowards(transform.forward, targetDirection, _turnPower * Time.deltaTime, 0.0f);

        transform.rotation = Quaternion.LookRotation(lookDirection);

        ParticleSystem.MainModule mainModule = _engineFlame.main;

        bool isFacingTargetPos = Vector3.Cross(transform.forward, targetDirection).magnitude < 0.1;

        if (isFacingTargetPos && Mathf.Abs(horizontal) + Mathf.Abs(vertical) > 0)
        {
            _body.AddForce(transform.forward * _enginePower * Time.deltaTime);
            mainModule.loop = true;

            if (!_engineFlame.isPlaying)
            {                
                
                _engineFlame.Play();
            }
            
        } else {
            mainModule.loop = false;
        }

    }
}
