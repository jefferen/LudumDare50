using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof( Rigidbody2D))]
public class MoveForward : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField]
    float Speed; 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.velocity = transform.right * Speed;
    }
}
