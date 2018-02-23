using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MiningButton : MonoBehaviour
{   
    [SerializeField]
    private GameObject _disabledMask;

    [SerializeField]
    private GameObject _clickableArea;

    private bool _down;
    private bool _up;

    private float _lastEvent = 0f;

    private void LateUpdate()
    {
        _down = false;
        _up = false;
    }
   
    public void Disable()
    {
        _disabledMask.SetActive(true);
    }    

    public void Enable()
    {
        _disabledMask.SetActive(false);
    }

    public void PointerDown()
    {        
        _down = true;        
    }

    public void PointerUp()
    {        
        _up = true;
    }

    public bool Up()
    {
        return _up || Input.GetButtonUp("FireMiningBeam");
    }

    public bool Down()
    {
        if(_down)
            Debug.Log("Down!");
        return _down || Input.GetButtonDown("FireMiningBeam");
    }
   
}
