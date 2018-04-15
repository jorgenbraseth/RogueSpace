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
    Player _player;

	// Use this for initialization
	void Start () {
        _player = GetComponent<Player>();
        _body = GetComponent<Rigidbody>();
        _engineFlame = _mainEngine.GetComponent<ParticleSystem>();
        _engineFlame.Play();
    }
	
	// Update is called once per frame
	void Update () {
        Move();
        Shoot();
    }

    private void Shoot()
    {
        float aimX = CrossPlatformInputManager.GetAxis("WeaponHorizontal");
        float aimY = CrossPlatformInputManager.GetAxis("WeaponVertical");

        Vector3 aim = new Vector3(aimX, 0, aimY);

        if (aim.magnitude > 0.01)
        {
            _player.Shoot(aim);
        }
    }

    private void Move()
    {
        float horizontal = CrossPlatformInputManager.GetAxis("Horizontal") + Input.GetAxis("Horizontal");
        float vertical = CrossPlatformInputManager.GetAxis("Vertical") + Input.GetAxis("Vertical");

        Vector3 targetDirection = new Vector3(horizontal, 0, vertical);
        Vector3 lookDirection = Vector3.RotateTowards(transform.forward, targetDirection, _turnPower * Time.deltaTime, 0.0f);

        ParticleSystem.MainModule main = _engineFlame.main;
        main.startSpeed = 5f * targetDirection.magnitude;

        transform.rotation = Quaternion.LookRotation(lookDirection);

        bool isFacingTargetPos = Vector3.Cross(transform.forward, targetDirection).magnitude < 0.1;

        if (isFacingTargetPos && Mathf.Abs(horizontal) + Mathf.Abs(vertical) > 0)
        {
            _body.AddForce(transform.forward * _enginePower * Time.deltaTime * targetDirection.magnitude);

        }
    }
}
