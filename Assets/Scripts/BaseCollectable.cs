using UnityEngine;

public abstract class BaseCollectable : MonoBehaviour
{
    [field: SerializeField] public CollectableData Data { get; set; }
    [field: SerializeField] public Player Player { get; set; }
    
    [field: SerializeField] public Sprite IconItemSprite { get; set; }




    public abstract void Collect(Player player);

    public abstract void StoreInInventory();

    public abstract void Use();
   
}
