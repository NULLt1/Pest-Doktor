using UnityEngine;
using Mapbox.Utils;
using Mapbox.Unity.Map;
using Mapbox.Unity.MeshGeneration.Factories;
using Mapbox.Unity.Utilities;
using System.Collections.Generic;
// NULLt1
public class SpawnOnMap : MonoBehaviour
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

    void Start()
    {
        locations = new Vector2d[locationStrings.Length];
        spawnedObjects = new List<GameObject>();
        for (int i = 0; i < locationStrings.Length; i++)
        {
            var locationString = locationStrings[i];
            locations[i] = Conversions.StringToLatLon(locationString);
            var instance = Instantiate(markerPrefab);
            instance.transform.localPosition = map.GeoToWorldPosition(locations[i], true);
            instance.transform.localScale = new Vector3(spawnScale, spawnScale, spawnScale);
            spawnedObjects.Add(instance);
        }
    }

    private void Update()
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
