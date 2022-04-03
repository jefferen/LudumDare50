using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CineMachineSetPlayerTarget : MonoBehaviour
{ 
    void Awake()
    {
        var v = GetComponent<CinemachineVirtualCamera>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        v.Follow = player.transform;
        v.LookAt = player.transform;
    }
}
