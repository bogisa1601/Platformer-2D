using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : BaseCollectable
{
    [field : SerializeField] public float HealthAmount { get; private set; }



    public override void Collect(Player player)
    {
        Player = player;
        StoreInInventory();
    }

    public override void StoreInInventory()
    {
       gameObject.SetActive(false);
        GameplayEvents.RaiseOnAddCollectable(this);
    }

    public override void Use()
    {
        if (Player.TryGetComponent(out Health health))
        {
            health.ModifyHealth(HealthAmount);
            Destroy(gameObject);
            Debug.Log($"Used Health Potion!!!");
        }
    }
}
