using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouthShooter : MonoBehaviour
{
    [SerializeField]
    GameObject mouth;

    [SerializeField]
    Transform firePoint;

    [SerializeField]
    float FireRate;

    private void Awake()
    {
        InvokeRepeating("SpawnMouth", Random.Range(1f,2f), Random.Range(FireRate - 0.5f, FireRate + 0.5f));
    }

    void SpawnMouth()
    {
        Instantiate(mouth, firePoint.position, transform.rotation);
    }
}
