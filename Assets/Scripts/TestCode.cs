using FishNet.Connection;
using FishNet.Managing;
using FishNet.Object;
using UnityEngine;

public class TestCode : NetworkBehaviour
{
    [SerializeField] private ShopKeeper shopKeeper;
    [SerializeField] private Player player;
    [SerializeField] private NetworkManager networkManager;
    // private void Update(){
    //     if (IsOwner)
    //     {
    //         Debug.Log("youre owner");
    //     }

    //     if (IsClientInitialized)
    //     {
    //         Debug.Log("CLIENT: Requesting buy.");

    //         RequestBuyServerRpc();
    //     }

    //     if (!IsClientInitialized)
    //         return;

    //     Debug.Log(
    //         $"Client={IsClientInitialized}, " +
    //         $"Server={IsServerInitialized}, " +
    //         $"Owner={IsOwner}"
    //     );

    // }
    private void Start()
    {
        //need to setup item inside of shopkeepr to be able to buy it
        shopKeeper.RequestBuyItem(new Vector2Int(0,0));
    }
    [ServerRpc(RequireOwnership = false)]
    private void RequestBuyServerRpc(NetworkConnection sender = null)
    {
        Debug.Log($"SERVER: Received buy request from client {sender.ClientId}");
    }


    //setup player character with money, inventory name etc
    //setup up shopkeeper character with money, inventory name etc
    //spawn on both client and server

    //have client call request buy from shopkeeper
    //server does it thing
    //i see results



}
