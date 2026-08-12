using System.Transactions;

public struct TransactionGoodsProvider
{
    public Inventory inventory; 
    public CurrencyKeeper currencyKeeper;

    public TransactionGoodsProvider(Inventory inventory, CurrencyKeeper keeper)
    {
        this.inventory = inventory;
        currencyKeeper = keeper;
    }
}
