using UnityEngine;
using FishNet.Object;

public class NetworkInventory : NetworkBehaviour
{
     private Inventory inventory;
     public override void OnStartServer()
     {
          inventory = new Inventory(10,10);
     }
    public override void OnStartClient()
    {
        base.OnStartClient();
        inventory = new Inventory(10,10);
    }
     //LOCAL FUNCTIONS
     public void TryAddItemAt(ItemContainer container, Vector2Int position)
     {
          if (IsServerInitialized)
          {
               inventory.TryAddItemAt(container,position);
               return;
          }

          //client prediction & request
          inventory.TryAddItemAt(container,position);
          RequestTryAddItemAt(container,position);

     }
     public void TryRemoveItemAt(Vector2Int position)
    {
        
    }
    public void ViewItemAt(Vector2Int position)
    {

    }
    private bool HasItem(Vector2Int position)
    {
          return false;
    }

     //CLIENT > SERVER REQUEST
     [ServerRpc]
     public void RequestTryAddItemAt(ItemContainer container, Vector2Int position)
     {
          TryAddItemAt(container,position);
     }
     [ServerRpc]
     public void RequestRemoveItemAt(Vector2Int position)
     {
          TryRemoveItemAt(position);
     }
}
