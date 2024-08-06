using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystemMove : MonoBehaviour
{
    private Vector3 _moveDir;
    private float _moveSpeed = 5f;

    private void Update()
    {
        bool hasControl = (_moveDir != Vector3.zero);

        if (hasControl)
        {
            transform.rotation = Quaternion.LookRotation(_moveDir);
            transform.Translate(Vector3.forward * _moveSpeed * Time.deltaTime);
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();

        if (input != null)
        {
            _moveDir = new Vector3(input.x, input.y, 0);
            Debug.Log($"UNITY_EVENTS : {input.magnitude}");
        }
    }
}
