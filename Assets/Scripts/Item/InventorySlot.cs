using UnityEngine;

public class InventorySlot
{
    public ItemContainer ItemContainer {get; private set;}
    public Vector2Int position { get ;}
    public bool IsEmpty => ItemContainer == null;

    public void AddItem(ItemContainer container)
    {
        ItemContainer = container;
    }
}
