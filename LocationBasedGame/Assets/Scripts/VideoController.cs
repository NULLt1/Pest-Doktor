using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    private VideoPlayer videoPlayer;
    // Start is called before the first frame update
    void Start()
    {
        videoPlayer = GameObject.Find("VideoPlayer").GetComponent<VideoPlayer>();
        GameObject.Find("VideoPlayer").SetActive(true);
        videoPlayer.Play();
    }

    // Update is called once per frame
    void Update()
    {
        videoPlayer.loopPointReached += EndReached;
    }

    public void stopVideo()
    {
        videoPlayer.Stop();
        GameObject.Find("VideoPlayer").SetActive(false);
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        GameObject.Find("VideoPlayer").SetActive(false);
    }
}
