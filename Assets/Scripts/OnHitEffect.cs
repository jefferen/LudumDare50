using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHitEffect : MonoBehaviour
{
    [SerializeField]
    GameObject Effect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Triggered(collision);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Triggered(collision);
    }

    void Triggered(Collider2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            Instantiate(Effect, transform.position, Quaternion.identity);   
            Destroy(gameObject);
        }
    }
}
