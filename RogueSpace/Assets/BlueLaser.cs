using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueLaser : Gun {
    
    [SerializeField]
    private GameObject beamVisual;

    [SerializeField]
    private BeamProperties props = new BeamProperties();

    [SerializeField]
    private GameObject hitDecal;

    bool shotThisFrame;

    internal void BeamNoHit()
    {
        beamVisual.transform.localScale = new Vector3(1, 1, props.range);
    }


    private void LateUpdate()
    {
        if (!shotThisFrame)
        {
            beamVisual.SetActive(false);
        }
        shotThisFrame = false;        
    }

    private void Awake()
    {
        props.itemKey = itemLibraryKey;
    }

    public override int GetDamage()
    {
        return props.damage;
    }

    public override EquipPosition GetEquippablePosition()
    {
        return EquipPosition.MAIN_GUN;
    }

    public override string GetProperties()
    {
        return "";
    }

    public override InventoryItem InstantiateFromJson(string json)
    {
        var newprops = JsonUtility.FromJson<BeamProperties>(json);
        var newme = Instantiate(this);
        newme.props = newprops;
        newme.SetId(newprops.id);
        return newme;
    }

    public override SerializableProperties SerializableValues()
    {
        return props;
    }

    public override void Shoot(Vector3 aim)
    {
        shotThisFrame = true;
        beamVisual.transform.rotation = Quaternion.LookRotation(aim);
        if (!beamVisual.activeSelf)
        {
            beamVisual.SetActive(true);
        }
      
        RaycastHit hit;
        if (Physics.Raycast(new Ray(transform.position, aim), out hit, props.range, LayerMask.GetMask("Enemy","Mineable")))
        {
            var newScale = new Vector3(beamVisual.transform.localScale.x, beamVisual.transform.localScale.y, hit.distance);
            beamVisual.transform.localScale = newScale;

            Instantiate(hitDecal, hit.point, Quaternion.LookRotation(-1 * beamVisual.transform.eulerAngles));
            var enemy = hit.collider.gameObject.GetComponent<IDamagable>();
            enemy.Damage(props.damage, hit.point, beamVisual.transform.eulerAngles);
        }
        else
        {
            var newScale = new Vector3(beamVisual.transform.localScale.x, beamVisual.transform.localScale.y, props.range);
            beamVisual.transform.localScale = newScale;
        }        

    }
    
    public void BeamHit(Collider other)
    {
        var distance = (other.transform.position - transform.position).magnitude;
        beamVisual.transform.localScale = new Vector3(1,1,distance);
    }
}

[System.Serializable]
public class BeamProperties : SerializableProperties
{
    public int damage = 1;
    public float range = 100f;
}

