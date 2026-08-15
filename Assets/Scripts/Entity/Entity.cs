using FishNet.Object;
using UnityEngine;

public class Entity : NetworkBehaviour
{
    [SerializeField] private string entityName;
    public int entityLevel { get; private set; }
    [SerializeField] private NetworkCurrencyKeeper networkCurrencyKeeper;
    public NetworkCurrencyKeeper NetworkCurrencyKeeper => networkCurrencyKeeper;
    public Inventory Inventory;
    public override void OnStartServer()
    {
        base.OnStartServer();
        Inventory = new Inventory(10,10);
        entityLevel = 10;
        Item item = new Item();
        ItemContainer itemContainer = new ItemContainer(item,10);
        Inventory.TryAddItemAt(itemContainer, new Vector2Int(0,0));
    }
    public override void OnStartClient()
    {
        base.OnStartClient();
        Inventory = new Inventory(10,10);
        entityLevel = 10;
    }



}
