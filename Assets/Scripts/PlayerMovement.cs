using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

  private Camera mainCamera;
  private Rigidbody rb;
  [SerializeField] private float forceMagnitude;
  [SerializeField] private float maxVelocity;
  private Vector3 movementDir;
  private void Start()
  {
    mainCamera = Camera.main;
    rb = this.gameObject.GetComponent<Rigidbody>();
  }

  private void Update()
  {
    ProcessTouchInput();
  }

  private void ProcessTouchInput()
  {
    if (Touchscreen.current.primaryTouch.press.isPressed)
    {
      Vector2 touchPos = Touchscreen.current.primaryTouch.position.ReadValue();
      Vector3 worldPos = mainCamera.ScreenToWorldPoint(touchPos);

      movementDir = worldPos - this.gameObject.transform.position;
      movementDir.z = 0;
      movementDir.Normalize();
    }
    else
    {
      movementDir = Vector3.zero;
    }
  }

  private void FixedUpdate()
  {
    ProcessPhysicsFromInput();
  }

  private void ProcessPhysicsFromInput()
  {
    if (movementDir == Vector3.zero) { return; }

    rb.AddForce(movementDir * forceMagnitude, ForceMode.Force);
    rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxVelocity);
  }
}
