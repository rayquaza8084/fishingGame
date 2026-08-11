using UnityEngine;

public class Inventory : IReadOnlyInventory
{
    private InventorySlot [][] inventoryArray;

    public Inventory(int width, int height)
    {
        inventoryArray = new InventorySlot [height][];
        
        for(int i = 0; i < height; i++)
        {
            inventoryArray[i] = new InventorySlot [width];
        }
    }
    public void TryAddItemAt(ItemContainer itemContainer, Vector2Int position)
    {
        if (!HasItem(position))//found no item, can place
        {
            var slot = inventoryArray[position.y][position.x];
            slot.AddItem(itemContainer);
            return;
        }

        //found an item in placing location, return displaced item 

        return;
    }

    public void TryRemoveItemAt(Vector2Int position)
    {
        
    }

    public void ViewItemAt(Vector2Int position)
    {

    }

    private bool HasItem(Vector2Int position)
    {
        var slot = inventoryArray[position.y][position.x];
        if(slot.ItemContainer.Item == null) return false;
        return true;
    }




}
