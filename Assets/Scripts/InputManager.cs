using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [Header("References")]
    PlayerControls playerControls;

    [Header("Input Variables")]
    public static Vector2 movementInput;

    void Awake()
    {
        playerControls = new PlayerControls();
    }

    void Update()
    {
        movementInput = playerControls.Sled.Steer.ReadValue<Vector2>();
    }

    void OnEnable()
    {
        playerControls.Enable();
    }

    void OnDisable()
    {
        playerControls.Disable();
    }
}
