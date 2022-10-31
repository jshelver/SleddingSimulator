using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityChecker : MonoBehaviour
{
    [SerializeField] Rigidbody rb;

    void Start()
    {

    }

    void Update()
    {
        Vector3 flatVelocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        Debug.Log(flatVelocity.magnitude);
    }
}
