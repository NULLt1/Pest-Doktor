using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class PhotonRPC : MonoBehaviourPun
{
    private bool rpcButton = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
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
    void NwRpcReceive(string blub, PhotonMessageInfo info)
    {
        Debug.Log(blub);
    }
}
