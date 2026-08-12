using UnityEngine;

public class TestCode : MonoBehaviour
{
    [SerializeField] private ShopGuy guy;
    void Awake()
    {
        //set money to 9999
        var keeper = new CurrencyKeeper(9999);
        //spawn item
        Item actualItem = new Item();
        var item = new ItemContainer(actualItem, 100);
        //create new inventory
        var inventory = new Inventory(10,10);

        if(inventory == null)
        {
            Debug.Log("inventory null");
        }
        inventory.TryAddItemAt(item, new Vector2Int(0,0));
        
        //give him initialized classes
        guy.Init(keeper, inventory);

        var transacitonThing = new TransactionGoodsProvider(inventory, keeper);

        //buy item
        guy.ItemClickEvent(transacitonThing, new Vector2Int(0,0));


    }
}
