using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaPotion : BaseCollectable
{
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
        Destroy(gameObject);
        Debug.Log($"Used Mana Potion!!!");
    }   

   
    
}
