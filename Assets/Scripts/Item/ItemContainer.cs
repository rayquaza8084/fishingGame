public class ItemContainer : IReadOnlyItem
{
    public Item Item;
    public int TempPriceSolution { get; }//temp solution

    public ItemContainer(Item item, int tempPrice)
    {
        Item = item;
        TempPriceSolution =  tempPrice;
    }
    public ItemContainer()
    {
        
    }
}
