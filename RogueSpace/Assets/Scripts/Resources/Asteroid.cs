using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour, IDamagable {

    [SerializeField]
    private int _oreAmount;

    [SerializeField]
    private int _damageToBreak;

    private int damageTaken = 0;

    [SerializeField]
    private GameObject minedOre;

    [SerializeField]
    private GameObject _deathEffect;

    private void Awake()
    {        
        _oreAmount = (int)((transform.localScale.x - 0.5f) * 2);
    }

    private void Update()
    {
        transform.localScale = Vector3.one * ((_oreAmount + 1 ) / 2);
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
        Destroy(transform.parent.gameObject);
    }

    public void Damage(int amount, Vector3 position, Vector3 direction)
    {
        damageTaken += amount;
        if (damageTaken > _damageToBreak) {
            GameObject mined = Instantiate(minedOre, position, Quaternion.identity);
            mined.GetComponent<Rigidbody>().AddForce(-500*direction);
            _oreAmount--;
            damageTaken = 0;
        }
        
    }
}
