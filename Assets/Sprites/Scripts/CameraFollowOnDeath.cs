using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraFollowOnDeath : MonoBehaviour
{
    private CinemachineVirtualCamera cinemachine;
    void Start()
    {
        cinemachine = gameObject.GetComponent<CinemachineVirtualCamera>();
    }

    void Update()
    {
        cinemachine.Follow = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
}
