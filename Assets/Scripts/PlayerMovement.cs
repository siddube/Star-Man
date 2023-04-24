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
    KeepShipOnScreen();
  }
  private void FixedUpdate()
  {
    ProcessPhysicsFromInput();
  }

  private void ProcessTouchInput()
  {
    if (Touchscreen.current.primaryTouch.press.isPressed)
    {
      Vector2 touchPos = Touchscreen.current.primaryTouch.position.ReadValue();
      Vector3 worldPos = mainCamera.ScreenToWorldPoint(touchPos);

      movementDir = worldPos - transform.position;
      movementDir.z = 0;
      movementDir.Normalize();
    }
    else
    {
      movementDir = Vector3.zero;
    }
  }

  private void KeepShipOnScreen()
  {
    Vector3 newPos = transform.position;
    Vector3 viewportPos = mainCamera.WorldToViewportPoint(transform.position);
    if (viewportPos.x > 1)
    {
      newPos.x = -newPos.x + 0.1f;
    }
    else if (viewportPos.x < -1)
    {
      newPos.x = -newPos.x - 0.1f;
    }
    else if (viewportPos.y > 1)
    {
      newPos.y = -newPos.y + 0.1f;
    }
    else if (viewportPos.y < -1)
    {
      newPos.y = -newPos.y - 0.1f;
    }

    transform.position = newPos;
  }

  private void ProcessPhysicsFromInput()
  {
    if (movementDir == Vector3.zero) { return; }

    rb.AddForce(movementDir * forceMagnitude, ForceMode.Force);
    rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxVelocity);
  }
}
