using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SledController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Rigidbody rb;
    [SerializeField] Transform slopeCheckerTransform;
    [SerializeField] LayerMask groundLayer;

    [Header("Steering Settings")]
    [SerializeField] float steeringPower = 1000f;

    void Start()
    {

    }

    void FixedUpdate()
    {
        SteerSled(InputManager.movementInput);
        ApplyDownwardForceOnSlope();
    }

    private void SteerSled(Vector2 movementInput)
    {
        // Change this to rotate the rb and the downward slope force


        // Only need horizontal movement
        Vector3 movementDirection = new Vector3(movementInput.x, 0f, 0f);

        var var = movementDirection * steeringPower * Time.fixedDeltaTime;
        Debug.Log("Movement Dir: " + var);
        rb.AddForce(var);
    }

    private void ApplyDownwardForceOnSlope()
    {
        if (Physics.Raycast(slopeCheckerTransform.position, Vector3.down, out RaycastHit hit, 0.5f, groundLayer))
        {
            // Gets the line perpendicular to the downward slope
            Vector3 left = Vector3.Cross(hit.normal, Vector3.up);

            // Gets the downward direction of the slope
            Vector3 slope = Vector3.Cross(hit.normal, left);
            Debug.DrawRay(hit.point, slope * 1000f, Color.red, 0.5f);

            var var = slope * 70f;
            Debug.Log("Slope: " + var);
            // Need to make this gradual somehow
            rb.AddForce(var);
        }
        else
        {
            Debug.Log("No Slope Detected");
        }
    }
}
