public class CurrencyKeeper
{
    private int currentBalance;
    private int laterBalance;
    public CurrencyKeeper(int currentMoney)
    {
        currentBalance = currentMoney;
    }

    public int TryWithdraw(int requestAmount)//need to check type later for which account to withdraw from
    {
        if(requestAmount <= 0) return 0;
        if(requestAmount > currentBalance) return 0;

        currentBalance -= requestAmount;
        return requestAmount;

    }

    public bool Deposit(int depositAmount)//need to check type later for which account to deposit into
    {
        if(depositAmount <= 0) return false;
        currentBalance += depositAmount;
        return true;
    }
    
    public int ViewBalance()
    {
        return currentBalance;
    }

}
