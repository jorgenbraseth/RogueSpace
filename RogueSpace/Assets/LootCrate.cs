using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootCrate : MonoBehaviour {

    [SerializeField]
    private InventoryItem loot;

    public void SetLoot(InventoryItem loot)
    {
        this.loot = loot;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Player p = other.gameObject.GetComponent<Player>();
            if (p.AddLoot(loot))
            {
                Destroy(gameObject);
            }

        }
    }
}
