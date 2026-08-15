using UnityEngine;

public class Shop 
{
    private NetworkCurrencyKeeper networkCurrencyKeeper;
    private Inventory inventory;
    private Transaction transaction;

    public Inventory Inventory => inventory;

    public Shop(NetworkCurrencyKeeper keeper, Inventory inventory)
    {
        //use to initialize class
        networkCurrencyKeeper = keeper;
        this.inventory = inventory;
        transaction = new Transaction();
        //will be used for UI
        //use to subscribe to click events 
        //event += ItemClickEvent();
    }

    public void BuyItem(TransactionGoodsProvider buyer, Vector2Int position)//start a transaction
    {
        //find item at location
        inventory.ViewItemAt(position);
        //pass item price to transacition class
        var transactionProvier = new TransactionGoodsProvider(inventory, networkCurrencyKeeper);
        var payment = transaction.BuyItem(buyer,transactionProvier,0);
        //check returned money
        if(payment == 0)
        {
            networkCurrencyKeeper.ServerDeposit(payment);
            inventory.TryRemoveItemAt(position);
            //add item to buyer
            UnityEngine.Debug.Log("bought item");

        }
        //item was not bought

    }

    public void GenerateItems()
    {
        //another system that has all items? available generates items for this class
        //put those items into inventory
        //use on Start()?

    }
}
