using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    private CharacterController _charControl;

    private void Awake()
    {
        _charControl = gameObject.GetComponent<CharacterController>();
    }

    public void OnMove(InputValue value)
    {
        Vector2 direction = value.Get<Vector2>();
        _charControl.CallMoveEvent(direction);
    }

    public void OnLook(InputValue value)
    {
        Vector2 mousePosition = value.Get<Vector2>();
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 direction = mousePosition - (Vector2)transform.position;
        _charControl.CallLookEvent(direction);
    }
}
