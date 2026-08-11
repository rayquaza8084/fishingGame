public class CurrencyKeeper
{
    private int moneyBalance; //base money type, can be dollars, clams/shells, seaweed, etc
    private int laterMoneyBalance; //if more money types are introduces, raffle tickets, special store currencies, etc
    public CurrencyKeeper(int currentMoney)
    {
        this.moneyBalance = currentMoney;
    }

    public int Withdraw(int requestAmount)//need to check type later for which account to withdraw from
    {
        if(requestAmount <= 0) return 0;
        if(requestAmount > moneyBalance)
        {
            int amount = moneyBalance;
            moneyBalance = 0;
            return amount;
        }

        moneyBalance -= requestAmount;
        return requestAmount;

    }

    public bool Deposit(int depositAmount)//need to check type later for which account to deposit into
    {
        if(depositAmount <= 0) return false;
        moneyBalance += depositAmount;
        return true;
    }
    
    public int ViewBalance()
    {
        return moneyBalance;
    }

}
