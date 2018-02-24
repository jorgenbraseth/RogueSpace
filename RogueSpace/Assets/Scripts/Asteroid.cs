using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : Mineable {

    [SerializeField]
    private int _oreAmount;

    [SerializeField]
    private GameObject _deathEffect;

    private void Awake()
    {        
        _oreAmount = (int)transform.localScale.x/100-2;
    }

    private void Update()
    {
        transform.localScale = Vector3.one * (_oreAmount+2)*100;
    }
    

    override public int Mine()
    {
        if(_oreAmount > 0)
        {
            _oreAmount--;
            return 1;
        }
        else
        {
            return 0;
        }
    }

    private void LateUpdate()
    {
        if (_oreAmount <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        GameObject deathFx = Instantiate(_deathEffect, transform.position, Quaternion.identity);
        Destroy(deathFx, 4f);
        Destroy(gameObject);
    }


}
