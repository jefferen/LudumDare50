using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardRotation : MonoBehaviour
{
    void Awake()
    {
        transform.rotation = Quaternion.identity; // freezing rotation to up
    }
}
