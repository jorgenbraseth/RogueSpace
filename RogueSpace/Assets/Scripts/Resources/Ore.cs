using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ore : MonoBehaviour {

    [SerializeField]
    private ResourceInventoryItem loot;

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
