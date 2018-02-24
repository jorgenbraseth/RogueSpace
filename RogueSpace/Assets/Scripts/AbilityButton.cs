using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AbilityButton : MonoBehaviour
{

    [SerializeField]
    private KeyCode _keyboardShortcut; 

    [SerializeField]
    private GameObject _disabledMask;

    private bool _down;
    private bool _up;

    private float _downTime;
    private float _upTime;

    private void Update()
    {
        if(_upTime < Time.time)
        {
            _up = false;
        }

        if (_downTime < Time.time)
        {            
            _down = false;
        }
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
        _downTime = Time.time;
        _down = true;
    }

    public void PointerUp()
    {
        _upTime = Time.time;
        _up = true;
    }

    public bool Up()
    {
        return _up || Input.GetKeyUp(_keyboardShortcut);
    }

    public bool Down()
    {                
        return _down || Input.GetKeyDown(_keyboardShortcut);
    }
   
}
