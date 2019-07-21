using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraFollow : MonoBehaviour
{
    public GameObject tPlayer;
    public Transform tFollowTarget;

    private CinemachineVirtualCamera virtualCamera;

    // Start is called before the first frame update
    void Start()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (tPlayer == null && GameObject.FindWithTag("Player")!=null)
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
        //gameObject.transform.position = .transform.position+offset;

    }
}
