public class Transaction
{
    public int BuyItem(TransactionGoodsProvider buyer, TransactionGoodsProvider seller, int itemPrice)
    {
        //check buyer balance vs item cost
        var buyerBalance = buyer.currencyKeeper.ViewBalance();
        if(buyerBalance < itemPrice)
        {
            return 0;
        }
        //if true, widthdraw money from buyer
        var payment = buyer.currencyKeeper.Withdraw(itemPrice);
        //return money to shop
        return payment;
    }
}
