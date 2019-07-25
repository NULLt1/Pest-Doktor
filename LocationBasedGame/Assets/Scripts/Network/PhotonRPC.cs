using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class PhotonRPC : MonoBehaviourPun
{
    private bool rpcButton = false;
    void Start()
    {

    }

    void Update()
    {
        if (GameObject.Find("RPC") != null && rpcButton == false)
        {
            GameObject.Find("RPC").GetComponent<Button>().onClick.AddListener(() => NwRpcSend("Button was pressed"));
            rpcButton = true;
        }



        if (Input.GetKeyDown(KeyCode.Space))
        {
            NwRpcSend("Space was pressed");
        }
    }

    public void NwRpcSend(string blub)
    {
        //Remote Procedure call
        photonView.RPC("NwRpcReceive", RpcTarget.All, blub);
    }

    [PunRPC]
    void NwRpcReceive(int id, string location, PhotonMessageInfo info)
    {
        Debug.Log(id);
        Debug.Log(location);

    }
}
