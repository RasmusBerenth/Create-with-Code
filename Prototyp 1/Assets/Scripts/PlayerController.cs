using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;

    [SerializeField] TextMeshProUGUI speedometerText;
    [SerializeField] float speed;

    [SerializeField] TextMeshProUGUI RpmText;
    [SerializeField] float rpm;

    [SerializeField] GameObject centerOfMass;
    [SerializeField] private float horsePower = 10.0f;
    [SerializeField] private float turnSpeed = 25.0f;
    private float horizontalInput;
    private float forwardInput;

    [SerializeField] List<WheelCollider> allWheels;
    [SerializeField] int wheelsOnGround;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();

        playerRb.centerOfMass = centerOfMass.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Player input
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        if (isOnGround())
        {
            // Move the vehicle forward
            playerRb.AddRelativeForce(Vector3.forward * forwardInput * horsePower);

            // Turn the vehicle
            transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);

            speed = Mathf.RoundToInt(playerRb.velocity.magnitude * 3.6f);
            speedometerText.SetText("Speedometer: " + speed + " Km/h");

            rpm = Mathf.Round((speed % 30) * 40);
            RpmText.SetText("Rpm: " + rpm);
        }
    }

    bool isOnGround()
    {
        wheelsOnGround = 0;
        foreach (WheelCollider wheel in allWheels)
        {
            if (wheel.isGrounded)
            {
                wheelsOnGround++;
            }
        }

        if (wheelsOnGround == 4)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
