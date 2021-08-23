using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float jumpForce = 10f;
    bool onGround = false;

    Rigidbody playerRb;
    Rigidbody connectedBody, previousConnectedBody;
    Vector3 connectionVelocity;
    Vector3 connectionLocalPosition;

    //TODO: check for weight limit before sticking to a physics object

    void Start() {
        playerRb = transform.GetComponent<Rigidbody>();
    }

    void Update() {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        playerRb.AddForce(new Vector3(input.x, 0, input.y) * (Time.deltaTime * movementSpeed), ForceMode.Force);

        if (Input.GetKeyDown(KeyCode.Space)) {
            playerRb.velocity += Vector3.up * jumpForce;
        }
    }

    void FixedUpdate() {
        if (connectedBody) {
            connectionVelocity = connectedBody.velocity;
            Vector3 relativeVelocity = playerRb.velocity - connectionVelocity;
            playerRb.AddForce(-relativeVelocity * (150f * Time.deltaTime));

            connectionLocalPosition = connectedBody.transform.InverseTransformPoint(playerRb.position);
            Vector3 connectionMovement = connectedBody.transform.TransformPoint(connectionLocalPosition) - playerRb.position;
            playerRb.AddForce(connectionMovement * (Time.deltaTime * 100f));
        }

        

        previousConnectedBody = connectedBody;
        connectedBody = null;
        connectionVelocity = Vector3.zero;
    }


    void OnCollisionEnter(Collision other) {
        EvaluateCollision(other);
    }

    void OnCollisionStay(Collision other) {
        EvaluateCollision(other);
    }

    void EvaluateCollision(Collision collision) {
        for (int i = 0; i < collision.contactCount; i++) {
            Vector3 normal = collision.GetContact(i).normal;
            onGround = normal.y >= 0.9f;
            connectedBody = collision.rigidbody;
        }
    }
}