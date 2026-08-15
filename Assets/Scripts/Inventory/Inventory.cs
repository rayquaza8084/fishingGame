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

        for(int i =0; i < height; i++)
        {
            for(int k =0; k< width; k++)
            {
                inventoryArray[i][k] = new InventorySlot();
            }
        }
    }
    public void TryAddItemAt(ItemContainer itemContainer, Vector2Int position)
    {
        if (!HasItem(position))//found no item, can place
        {
            Debug.Log($"found no item at location placing at: {position}");
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
        InventorySlot slot = inventoryArray[position.y][position.x];
        if(slot.IsEmpty) return false;
        return true;
    }




}
