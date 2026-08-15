using FishNet.Connection;
using FishNet.Object;
using UnityEngine;
public class ShopKeeper : Entity
{
    private Shop shop;
    private ClientShop clientShop;
    public override void OnStartServer()
    {
        base.OnStartServer();
        shop = new Shop(NetworkCurrencyKeeper, Inventory);
    }
    public override void OnStartClient()
    {
        base.OnStartClient();
    }

    //CLIENT SIDE
    public void InitClient(ShopUI shopUI)
    {
        //get shop ui from outside spawn system
        //start client
        clientShop = new ClientShop(Inventory, shopUI);

    }
    
    [Client]
    public void ClientBuyItem(Vector2Int position)
    {
        //client side prediciton
        clientShop.BuyItem();
        //request actual server
        RequestBuyItem(position);

    }
    [Client]
    public void ClientSellItem()
    {
        
    }
    public void ViewItems()
    {
        
    }
    [ServerRpc(RequireOwnership = false)]
    public void RequestBuyItem(Vector2Int position,NetworkConnection sender = null)
    {
        //checks if can buy item 
        //put item into players server side inventory
        Player playerComp = sender.FirstObject.GetComponent<Player>();
        ServerBuyItem(position, playerComp.Inventory, playerComp.NetworkCurrencyKeeper);
        //syncs states
        SyncInventories();
    }
    [ServerRpc(RequireOwnership = false)]
    public void RequestSellItem()
    {
        
    }

    //SERVER SIDE
    [Server]
    public void ServerSellItem()
    {
        UnityEngine.Debug.Log("Bought item on server");
    }
    [Server]
    public void ServerBuyItem(Vector2Int position,Inventory inventory, NetworkCurrencyKeeper keeper)
    {
        var tempBuyer = new TransactionGoodsProvider(inventory,keeper);
        shop.BuyItem(tempBuyer,position);
        UnityEngine.Debug.Log("bought item on server side");
        
    }
    [Server]
    private void SyncInventories()
    {
        UnityEngine.Debug.Log("inventories should be synced here");
    }


    

}
