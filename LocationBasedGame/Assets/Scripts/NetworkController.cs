using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

namespace LocationBasedGame
{
    public class NetworkController : MonoBehaviourPunCallbacks
    {
        public Button ButtonConnect;
        public Button ButtonJoin;
        public Image TextConnected;
        public Image TextJoiningRoom;

        private bool connectingToMaster;
        private bool joiningRoom;

        void Start()
        {
            DontDestroyOnLoad(this.gameObject);
            connectingToMaster = false;
            joiningRoom = false;
        }

        void Update()
        {
            if (ButtonConnect != null)
                ButtonConnect.gameObject.SetActive(!PhotonNetwork.IsConnected && !connectingToMaster);

            if (ButtonJoin != null)
                ButtonJoin.gameObject.SetActive(PhotonNetwork.IsConnected && connectingToMaster && !joiningRoom);

            if (TextConnected != null)
                TextConnected.gameObject.SetActive(PhotonNetwork.IsConnected && connectingToMaster);

            if (TextJoiningRoom != null)
                TextJoiningRoom.gameObject.SetActive(joiningRoom);
        }

        public void Button_Connect()
        {
            PhotonNetwork.ConnectUsingSettings();
        }

        public void Button_JoinRoom()
        {
            if (!PhotonNetwork.IsConnected)
                return;

            joiningRoom = true;
            PhotonNetwork.JoinRandomRoom();
        }

        public override void OnConnectedToMaster()
        {
            base.OnConnectedToMaster();
            connectingToMaster = true;
        }

        public override void OnDisconnected(DisconnectCause cause)
        {
            base.OnDisconnected(cause);
            connectingToMaster = false;
            joiningRoom = false;
            Debug.Log(cause);
        }

        public override void OnJoinRandomFailed(short returnCode, string message)
        {
            base.OnJoinRandomFailed(returnCode, message);
            PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 20 });
        }

        public override void OnCreateRoomFailed(short returnCode, string message)
        {
            base.OnCreateRoomFailed(returnCode, message);
            Debug.Log(message);
            base.OnCreateRoomFailed(returnCode, message);
            joiningRoom = false;
        }

        public override void OnJoinedRoom()
        {
            base.OnJoinedRoom();
            SceneManager.LoadScene("LocationBasedGame");
        }
    }
}