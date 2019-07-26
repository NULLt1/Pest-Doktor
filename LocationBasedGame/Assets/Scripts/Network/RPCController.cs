using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
// NULLt1
public class RPCController : MonoBehaviourPun
{
    private string[] locationStrings;
    private PhotonView photonView;
    private SpawnPlagueOnMapScript spawnPlagueOnMapScript;
    void Start()
    {
        photonView = GameObject.Find("PlagueSpawner").GetComponent<PhotonView>();
        spawnPlagueOnMapScript = GameObject.Find("PlagueSpawner").GetComponent<SpawnPlagueOnMapScript>();
        if (PhotonNetwork.IsMasterClient)
        {
            locationStrings = GameObject.Find("PlagueSpawner").GetComponent<SpawnPlagueOnMapScript>().getLocations();
        }
        else
        {
            SendNewPlayerRPC();
        }
    }

    void Update()
    {

    }

    public void SendPlagueSpawnRpc(int id, string location)
    {
        photonView.RPC("PlagueSpawnRpc", RpcTarget.OthersBuffered, id, location);
    }

    [PunRPC]
    void PlagueSpawnRpc(int id, string location, PhotonMessageInfo info)
    {
        spawnPlagueOnMapScript.setLocationString(id, location);
        if (id == GameObject.Find("PlagueSpawner").GetComponent<SpawnPlagueOnMapScript>().getLocations().Length - 1)
            StartCoroutine(spawnPlagueOnMapScript.delayedSpawn(100));
    }

    public void SendPlagueHealth(int id)
    {
        photonView.RPC("PlagueHealthRPC", RpcTarget.Others, id);
    }

    [PunRPC]
    void PlagueHealthRPC(int id, PhotonMessageInfo info)
    {
        var plagueControllers = FindObjectsOfType<PlagueController>();
        foreach (PlagueController plagueController in plagueControllers)
        {
            if (plagueController.getPlagueId() == id)
            {
                plagueController.decrementHealth();
                ActualizePlagueHealth(id, plagueController.getHealth());
            }
        }
    }

    public void SendNewPlayerRPC()
    {
        string newPlayer = "newPlayer";
        photonView.RPC("NewPlayerRpc", RpcTarget.Others, newPlayer);
    }

    [PunRPC]
    void NewPlayerRpc(string newPlayer, PhotonMessageInfo info)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            int i = 0;
            foreach (string location in locationStrings)
            {
                SendPlagueSpawnRpc(i, location);
                SendPlagueHealth(i);
                i++;
            }
        }
    }

    public void PlayerInsidePlague(int id)
    {
        photonView.RPC("PlayerInsidePlague", RpcTarget.MasterClient, id);
    }

    [PunRPC]
    void PlayerInsidePlague(int id, PhotonMessageInfo info)
    {
        var plagueControllers = FindObjectsOfType<PlagueController>();
        foreach (PlagueController plagueController in plagueControllers)
        {
            if (plagueController.getPlagueId() == id)
            {
                plagueController.decrementHealth();
                ActualizePlagueHealth(id, plagueController.getHealth());
            }
        }
    }

    public void PlayerInsidePlagueName(int id, string name)
    {
        photonView.RPC("PlayerInsidePlagueName", RpcTarget.All, id, name);
    }

    [PunRPC]
    void PlayerInsidePlagueName(int id, string name, PhotonMessageInfo info)
    {
        var plagueControllers = FindObjectsOfType<PlagueController>();
        foreach (PlagueController plagueController in plagueControllers)
        {
            if (plagueController.getPlagueId() == id)
            {
                plagueController.AddPlayer(name);
            }
        }
    }

    public void ActualizePlagueHealth(int id, int health)
    {
        photonView.RPC("ActualizePlagueHealth", RpcTarget.Others, id, health);
    }

    [PunRPC]
    void ActualizePlagueHealth(int id, int health, PhotonMessageInfo info)
    {
        var plagueControllers = FindObjectsOfType<PlagueController>();
        foreach (PlagueController plagueController in plagueControllers)
        {
            if (plagueController.getPlagueId() == id)
            {
                plagueController.setHealth(health);
            }
        }
    }
}
