
using System.Threading;
using System.Threading.Tasks;
using Mapbox.Unity.Location;
using UnityEngine;
using UnityEngine.UI;



public class GameMaster : MonoBehaviour


{
    [SerializeField]
    private LocationProviderFactory LocationProviderFactory;

    public Text latText;
    public Text longText;

    private Task locTask;


    // Start is called before the first frame update
    void Awake()
    {
        locTask = new Task(setCurrentLocation);

        locTask.Start();

    }

    // Update is called once per frame
    void Update()
    {

        if (locTask.IsCompleted)
        {
            var loc = LocationProviderFactory.DefaultLocationProvider.CurrentLocation.LatitudeLongitude;
            longText.text = loc.x.ToString();
            latText.text = loc.y.ToString();
            locTask = new Task(setCurrentLocation);
            locTask.Start();
        }
    }


    private void setCurrentLocation()
    {

        var loc = LocationProviderFactory.DefaultLocationProvider.CurrentLocation.LatitudeLongitude;
        Debug.Log("Task" + "x: " + loc.x + " , y: " + loc.y);
//        PhotonInteractionHandler.setProperty(JsonUtility.ToJson(new GeoLocation(loc.x, loc.y)), "location");
        Thread.Sleep(2000);

    }
}