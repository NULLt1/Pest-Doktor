using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraFollow : MonoBehaviour
{
    public GameObject tPlayer;
    public Transform tFollowTarget;

    private CinemachineVirtualCamera virtualCamera;

    void Start()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    void Update()
    {
        if (tPlayer == null && GameObject.FindWithTag("Player") != null)
        {
            Debug.Log(GameObject.FindWithTag("Player"));
            tPlayer = GameObject.FindWithTag("Player");
            if (tPlayer != null)
            {
                tFollowTarget = tPlayer.transform;
                virtualCamera.LookAt = tFollowTarget;
                virtualCamera.Follow = tFollowTarget;
            }
        }
    }
}
