using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimAtTarget : MonoBehaviour
{
    GameObject Target;

    [SerializeField]
    Vector2 AimRangeDegree;

    [SerializeField]
    float AimSpeed;

    private void Awake()
    {
        Target = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        float angle = Mathf.Atan2(Target.transform.position.y - transform.position.y, Target.transform.position.x - transform.position.x) * Mathf.Rad2Deg;
        angle = Mathf.Clamp(angle, AimRangeDegree.x, AimRangeDegree.y);
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, AimSpeed * Time.deltaTime);
    }
}
