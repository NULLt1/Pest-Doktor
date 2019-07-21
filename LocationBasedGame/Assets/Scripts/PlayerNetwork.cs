using Photon.Pun;
using UnityEngine;
using Mapbox.Unity.Location;
using Mapbox.Unity.Map;

namespace LocationBasedGame
{
    public class PlayerNetwork : MonoBehaviourPun
    {
        private void Awake()
        {

            if (!photonView.IsMine && this.GetComponent<ImmediatePositionWithLocationProvider>() != null)
                Destroy(this.GetComponent<ImmediatePositionWithLocationProvider>());

            if (!photonView.IsMine && this.gameObject.transform.GetChild(0).GetComponent<PlayerCollisionScript>() != null)
            {
                Destroy(this.gameObject.transform.GetChild(0).GetComponent<PlayerCollisionScript>());
            }
            if (photonView.IsMine && this.gameObject.transform.GetChild(0) != null)
            {
                this.gameObject.transform.GetChild(0).tag="Player";
            }
        }

        public static void RefreshInstance(ref PlayerNetwork player, PlayerNetwork Prefab)
        {
            var position = Vector3.zero;
            var rotation = Quaternion.identity;
            if (player != null)
            {
                position = player.transform.position;
                rotation = player.transform.rotation;
                PhotonNetwork.Destroy(player.gameObject);
            }

            player = PhotonNetwork.Instantiate(Prefab.gameObject.name, position, rotation).GetComponent<PlayerNetwork>();
        }
    }
}