using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

  private Camera mainCamera;

  void Start()
  {
    mainCamera = Camera.main;
  }

  void Update()
  {
    if (Touchscreen.current.primaryTouch.press.isPressed)
    {
      Vector2 touchPos = Touchscreen.current.primaryTouch.position.ReadValue();
      Vector3 worldPos = mainCamera.ScreenToWorldPoint(touchPos);
      Debug.Log("World: " + worldPos);
    }
  }
}
