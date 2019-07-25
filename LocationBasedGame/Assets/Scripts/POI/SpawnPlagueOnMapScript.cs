using System.Collections;
using UnityEngine;
using Mapbox.Utils;
using Mapbox.Unity.Map;
using Mapbox.Unity.MeshGeneration.Factories;
using Mapbox.Unity.Utilities;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;

public class SpawnPlagueOnMapScript : MonoBehaviour
{
    [SerializeField]
    AbstractMap map;

    [SerializeField]
    [Geocode]
    string[] locationStrings;
    Vector2d[] locations;

    [SerializeField]
    float spawnScale = 100f;

    [SerializeField]
    GameObject markerPrefab;

    List<GameObject> spawnedObjects;

    private float delay = 2f;
    bool plagueUpdateFlag = false;

    void Start()
    {
        //Debug.Log(PhotonNetwork.IsConnected);
        //Debug.Log(PhotonNetwork.IsMasterClient);
        //PhotonNetwork.LoadLevel(1);
        if (PhotonNetwork.IsMasterClient)
        {
            //spawnPlague();
            StartCoroutine(delayedSpawn());

        }
    }

    private void Update()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            updatePlaguePositon();
        }
    }

    private void spawnPlague()
    {
        locations = new Vector2d[locationStrings.Length];
        spawnedObjects = new List<GameObject>();
        for (int i = 0; i < locationStrings.Length; i++)
        {
            var locationString = locationStrings[i];
            //sendPlagueSpawnRpc(i, locationString);
            locations[i] = Conversions.StringToLatLon(locationString);
            var instance = Instantiate(markerPrefab);
            instance.GetComponent<PlagueController>().setPlagueAttribute(new PlagueAttribute(i, 100));
            instance.transform.localPosition = map.GeoToWorldPosition(locations[i], true);
            instance.transform.localScale = new Vector3(spawnScale, spawnScale, spawnScale);
            spawnedObjects.Add(instance);
            //spawnPlague = false;
        }
    }

    private void updatePlaguePositon()
    {
        if (PhotonNetwork.IsMasterClient && plagueUpdateFlag == true)
        {
            int count = spawnedObjects.Count;
            for (int i = 0; i < count; i++)
            {
                var spawnedObject = spawnedObjects[i];
                var location = locations[i];
                spawnedObject.transform.localPosition = map.GeoToWorldPosition(location, true);
                spawnedObject.transform.localScale = new Vector3(spawnScale, spawnScale, spawnScale);
            }
        }
    }

    private IEnumerator delayedSpawn()
    {
        yield return new WaitForSeconds(2f);
        spawnPlague();
        plagueUpdateFlag = true;
    }


    public IEnumerator delayedSpawn(int health)
    {
        Debug.Log("delayedSpawn client");
        yield return new WaitForSeconds(2f);
        spawnPlague();
        plagueUpdateFlag = true;
    }


    public void setLocationString(string location)
    {
        locationStrings[0] = location;
        Debug.Log(locationStrings[0]);
    }
}
