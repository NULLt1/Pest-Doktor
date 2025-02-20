﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;
using DatabaseN;

namespace LocationBasedGame
{
    public class NetworkController : MonoBehaviourPunCallbacks
    {
        public Button ButtonConnect, ButtonJoin, ButtonLos;
        public Image TextConnected, TextJoiningRoom, NameOverlay;
        private Text welcomeText;
        private DatabaseManager databaseManager;
        private InputField nameInput;
        private bool firstLogin, inputButton, connectingToMaster, joiningRoom;

        void Start()
        {
            DontDestroyOnLoad(this.gameObject);
            ButtonLos.gameObject.SetActive(false);
            connectingToMaster = false;
            joiningRoom = false;
            nameInput = GameObject.Find("NameInput").GetComponent<InputField>();
            welcomeText = GameObject.Find("WelcomeText").GetComponent<Text>();
            databaseManager = GameObject.Find("DatabaseManager").GetComponent<DatabaseManager>();

            if (databaseManager.playerNameExists())
            {
                NameOverlay.gameObject.SetActive(false);
                nameInput.gameObject.SetActive(false);
                ButtonLos.gameObject.SetActive(false);
                welcomeText.text = "Willkommen " + databaseManager.getPlayerName();
            }

        }

        void Update()
        {
            if (nameInput.text != "" && ButtonLos != null)
            {
                ButtonLos.gameObject.SetActive(true);
            }
            else if (ButtonLos != null)
            {
                ButtonLos.gameObject.SetActive(false);
            }

            if (ButtonConnect != null)
                ButtonConnect.gameObject.SetActive(!PhotonNetwork.IsConnected && !connectingToMaster);

            if (ButtonJoin != null)
                ButtonJoin.gameObject.SetActive(PhotonNetwork.IsConnected && connectingToMaster && !joiningRoom);

            if (TextConnected != null)
                TextConnected.gameObject.SetActive(PhotonNetwork.IsConnected && connectingToMaster);

            if (TextJoiningRoom != null)
                TextJoiningRoom.gameObject.SetActive(joiningRoom);
        }

        public void AcceptName()
        {
            databaseManager.setPlayerName(nameInput.text);
            NameOverlay.gameObject.SetActive(false);
            nameInput.gameObject.SetActive(false);
            ButtonLos.gameObject.SetActive(false);
            welcomeText.text = "Willkommen " + databaseManager.getPlayerName() + "!";
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