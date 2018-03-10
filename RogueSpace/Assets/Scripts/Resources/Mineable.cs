using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class Mineable : MonoBehaviour, IPointerClickHandler
{
    public abstract int Mine();

    public void OnPointerClick(PointerEventData eventData)
    {
        MiningBeam _miningBeam = GameObject.Find("MiningBeam").GetComponent<MiningBeam>();
        _miningBeam.Select(gameObject);
    }
}

