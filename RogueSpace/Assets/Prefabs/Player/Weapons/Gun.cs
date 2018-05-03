using UnityEngine;

public abstract class Gun:InventoryItem {

    public abstract void Shoot(Vector3 aim);

    public abstract int GetDamage();

    public override int GetCount()
    {
        return 1;
    }

    public override bool IsResource()
    {
        return false;
    }

    public override ResourceType GetResourceType()
    {
        return ResourceType.NONE;
    }
}

