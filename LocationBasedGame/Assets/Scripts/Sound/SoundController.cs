using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioClip sammeln1, sammeln2, sammeln3, sammeln4, churchBell, crow, box, pages;
    private AudioSource audioPlayer;
    // Start is called before the first frame update
    void Start()
    {
        audioPlayer = this.GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void playSound()
    {
        var random = Random.Range(1, 5);
        switch (random)
        {
            case 1:
                audioPlayer.clip = sammeln1;
                audioPlayer.Play();
                break;
            case 2:
                audioPlayer.clip = sammeln2;
                audioPlayer.Play();
                break;
            case 3:
                audioPlayer.clip = sammeln3;
                audioPlayer.Play();
                break;
            case 4:
                audioPlayer.clip = sammeln4;
                audioPlayer.Play();
                break;
        }
    }

    public void playChurchBell() {
        audioPlayer.clip = churchBell;
        audioPlayer.Play();
    }

    public void playCrow() {
        audioPlayer.clip = crow;
        audioPlayer.Play();
    }

    public void playBox(){
        audioPlayer.clip = box;
        audioPlayer.Play();
    }

    public void playPages(){
        audioPlayer.clip = pages;
        audioPlayer.Play();
    }
}
