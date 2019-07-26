using Photon.Pun;
using UnityEngine.SceneManagement;
using Photon.Realtime;
// NULLt1
namespace LocationBasedGame
{
    public class GameController : MonoBehaviourPunCallbacks
    {
        private void Awake()
        {
            if (!PhotonNetwork.IsConnected)
            {
                SceneManager.LoadScene("Login");
                return;
            }
        }

        void Start()
        {

        }
    }
}