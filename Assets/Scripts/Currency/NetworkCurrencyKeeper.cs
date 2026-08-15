using FishNet.Connection;
using FishNet.Object;
using FishNet.Object.Synchronizing;

public class NetworkCurrencyKeeper : NetworkBehaviour
{
    private readonly SyncVar<int> moneyBalance = new();
    private readonly SyncVar<int> laterMoneyBalance = new();
    private int lastWithdraw = 0;

    public CurrencyKeeper CurrencyKeeper {get; private set; }

    public override void OnStartServer()
    {
        base.OnStartServer();
        CurrencyKeeper = new CurrencyKeeper(100);
        moneyBalance.Value = CurrencyKeeper.ViewBalance();
    }

    public override void OnStartClient()
    {
        base.OnStartClient();
    }
    //LOCAL API





    //CLIENT API
    

    [Client]
    public int ClientViewBalance()
    {
        UnityEngine.Debug.Log($"viewing client side balancing: {moneyBalance}");
        return moneyBalance.Value;
    }


    //SERVER API
    [Server]
    public int ServerDeposit(int amount)
    {
        if (!CurrencyKeeper.Deposit(amount))
            return 0;

        SyncCurrency();

        return amount;
    }
    [Server]
    public int TryServerWithdraw(int amount)
    {
        int withdrawn = CurrencyKeeper.TryWithdraw(amount);

        if (withdrawn > 0)
            SyncCurrency();

        return withdrawn;
    }

    //SERVER ONLY

    [Server]
    private void SyncCurrency()
    {
        moneyBalance.Value = CurrencyKeeper.ViewBalance();
        UnityEngine.Debug.Log("server synced money balance with client");
    }

    [Server]
    public int ServerViewBalance()
    {
        return moneyBalance.Value;
    }


    
    // =========================
    // CLIENT > SERVER REQUESTS
    // =========================

    [ServerRpc]
    public void RequestDeposit(int amount)
    {
        if(!CurrencyKeeper.Deposit(amount)) return;
        moneyBalance.Value = CurrencyKeeper.ViewBalance();
    }

    [ServerRpc]
    public void RequestWithdraw(int amount, NetworkConnection sender = null)
    {
        var withdraw = CurrencyKeeper.TryWithdraw(amount);
        TargetWithdrawResult(sender, withdraw);
    }
    

    // =========================
    // SERVER > CLIENT RESPONSE
    // =========================
    
    [TargetRpc]
    public void TargetWithdrawResult(NetworkConnection connection,  int amount)
    {
        lastWithdraw = amount;
    }


}
