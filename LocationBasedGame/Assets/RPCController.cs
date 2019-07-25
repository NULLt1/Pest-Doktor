using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class RPCController : MonoBehaviourPun
{
    private SpawnPlagueOnMapScript spawnPlagueOnMapScript;
    // Start is called before the first frame update
    void Start()
    {
        spawnPlagueOnMapScript = GameObject.Find("PlagueSpawner").GetComponent<SpawnPlagueOnMapScript>();
        if (PhotonNetwork.IsMasterClient)
        {

        }
        else
        {
            SendHelo();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void sendPlagueSpawnRpc(int id, string location)
    {
        //Remote Procedure call
        GameObject.Find("PlagueSpawner").GetComponent<PhotonView>().RPC("PlagueSpawnRpc", RpcTarget.OthersBuffered, id, location);
        Debug.Log("SEND SEND SEND");
    }

    [PunRPC]
    void PlagueSpawnRpc(int id, string location, PhotonMessageInfo info)
    {
        //Debug.Log(info);
        // SET LOCATION
        // SPAWN DELAYED
        spawnPlagueOnMapScript.setLocationString(location);
        StartCoroutine(spawnPlagueOnMapScript.delayedSpawn(100));

        Debug.Log(id);
        Debug.Log(location);

    }

    public void SendHelo()
    {
        //Remote Procedure call
        string newPlayer = "newPlayer";
        GameObject.Find("PlagueSpawner").GetComponent<PhotonView>().RPC("NewPlayerRpc", RpcTarget.Others, newPlayer);
    }

    [PunRPC]
    void NewPlayerRpc(string newPlayer, PhotonMessageInfo info)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            sendPlagueSpawnRpc(0, "48.04986466,8.21115106");
            //sendPlagueHealt(100);
        }
    }
}
