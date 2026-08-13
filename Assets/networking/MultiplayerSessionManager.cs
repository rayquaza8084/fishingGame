using FishNet.Managing;
using UnityEngine;

public class MultiplayerSessionManager : MonoBehaviour
{
    //this class will probably not be a monobehavior, can probably be a pure c# class
    //temporary solution for speed and time
    //will populate the fields from existing scene objects instead of spawning/creating them from scratch
    [SerializeField] private NetworkManager networkManager;

    private void Start()
    {
        HostGame();
    }
    public void HostGame()
    {
        //recieve button click
        //makes local machine Host = server + client

        //===========TEMP=============
        networkManager.ServerManager.StartConnection();
        networkManager.ClientManager.StartConnection();

    }

    public void CreateClient()
    {
        //someone ask server to join
        //do some checks or something with steam if theyre allowed to join or not
        //if allowed, create a client
        //assign new player client
    }
    public void DestroyClient()
    {
        //player disconnects
        //find their clients or recieve it idk
        //stop it
    }








    //host migration will probably be a seperate class/system entirely
    //sending snapshots to another player will also be a seperate system

    public void PromoteHost()
    {
        //host choose a new host
        //transfer all game states over the player b
        //remove player a from being host
        //give player b host
    }

    public void MigrateHost()
    {
        //host suddent disconect
        //remove previous host as host
        //give back up host host
        //have back up host rebuild server from snapshot
    }
}
