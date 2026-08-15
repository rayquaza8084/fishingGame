public struct TransactionGoodsProvider
{
    public Inventory inventory; 
    public NetworkCurrencyKeeper networkCurrencyKeeper;

    public TransactionGoodsProvider(Inventory inventory, NetworkCurrencyKeeper keeper)
    {
        this.inventory = inventory;
        networkCurrencyKeeper = keeper;
    }
}
