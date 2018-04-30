using UnityEngine;

public abstract class Gun:InventoryItem {

    public abstract void Shoot(Vector3 aim);

    public abstract int GetDamage();
    
}

