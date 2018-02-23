using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cakeslice;

public class Mining : MonoBehaviour {
    
    private GameObject _miningTarget;

    [SerializeField]
    private GameObject _miningSparksFx;

    [SerializeField]
    private GameObject _miningBeamFx;

    [SerializeField]
    private GameObject _minedOrePrefab;


    [SerializeField]
    private AudioClip _miningSound;

    [SerializeField]
    private float _miningRate = 10f;
    private float _nextMine = 0f;

    [SerializeField]
    private LayerMask _minableLayer;

    [SerializeField]
    private MiningButton _button;

    private GameObject miningBeam;

    private AudioSource audioPlayer;

    private bool _isMining;

    private void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
    }



    // Update is called once per frame
    void Update () {
        SelectMinable();
        SetButtonState();
        Mine();        
    }

    private void SetButtonState()
    {
        if (_miningTarget == null)
        {
            _button.Disable();
        }
        else
        {
            Vector3 direction = _miningTarget.transform.position - transform.position;
            RaycastHit hitInfo;
            bool hitSomething = Physics.Raycast(transform.position, direction, out hitInfo, _miningRange, _minableLayer);
            if (hitSomething && hitInfo.collider.gameObject == _miningTarget)
            {
                _button.Enable();
            }
            else
            {
                _button.Disable();
            }
        }
    }

    private void SelectMinable()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity, _minableLayer))
            {
                Outline outline = hitInfo.collider.GetComponent<Outline>();
                if (outline != null)
                {
                    outline.enabled = true;
                }
                _miningTarget = outline.gameObject;
            }
        }
    }

    [SerializeField]
    private float _miningRange = 40f;

    private RaycastHit _miningTargetHitInfo;
    

    private void Mine()
    {
        bool hasMiningTarget = _miningTarget != null;
        bool miningTargetInRange = false;
        if (hasMiningTarget)
        {
            Vector3 direction = _miningTarget.transform.position - transform.position;            
            bool hitSomething = Physics.Raycast(transform.position, direction, out _miningTargetHitInfo, _miningRange, _minableLayer);
            miningTargetInRange = hitSomething && _miningTargetHitInfo.collider.gameObject == _miningTarget;
        }

        
        if (miningTargetInRange && _button.Down()) {            
            StartMining();           
        } else if (_button.Up() && _isMining) {
            StopMining();
        }

        if (_isMining) {
            Vector3 direction = transform.position - _miningTargetHitInfo.point;
            miningBeam.transform.position = _miningTargetHitInfo.point;
            miningBeam.transform.rotation = Quaternion.LookRotation(direction);

            if (Time.time > _nextMine)
            {
                GameObject mined = Instantiate(_minedOrePrefab, _miningTargetHitInfo.point, Quaternion.identity);
                mined.GetComponent<Rigidbody>().AddForce(direction * 10f);
                _nextMine = Time.time + _miningRate;

                GameObject sparks = Instantiate(_miningSparksFx, _miningTargetHitInfo.point, Quaternion.LookRotation(direction));
                Destroy(sparks, 2f);

            }
        }

    }

    private void StopMining()
    {
        if (miningBeam != null)
        {
            Destroy(miningBeam);            
        }
        miningBeam = null;
        audioPlayer.Stop();
        _isMining = false;
    }

    private void StartMining()
    {
        Vector3 direction = _miningTargetHitInfo.point - transform.position;
        miningBeam = Instantiate(_miningBeamFx, _miningTargetHitInfo.point, Quaternion.LookRotation(-direction));
        miningBeam.GetComponent<ParticleSystem>().trigger.SetCollider(0, transform);
        audioPlayer.Play();
        _isMining = true;
    }
}
