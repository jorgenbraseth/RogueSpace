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
        return _up || Input.GetKeyUp(_keyboardShortcut);
    }

    public bool Down()
    {        
        return _down || Input.GetKeyDown(_keyboardShortcut);
    }
   
}
