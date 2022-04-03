using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollider : MonoBehaviour
{
    Eaten Eaten;

    private void Awake()
    {
        Eaten = GameObject.FindGameObjectWithTag("Player").GetComponent<Eaten>();
    }
    void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Eaten.GetHeat(10);
        }
    }
}
