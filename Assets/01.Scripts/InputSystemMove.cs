using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class InputSystemMove : MonoBehaviour
{
    private CharacterController _charController;

    private Rigidbody2D _rigidbody;

    private SpriteRenderer _charSpriteRenderer;

    private Vector2 _direction;

    [SerializeField][Range(5, 1000)] private float _speed;

    private void Awake()
    {
        _charController = gameObject.GetComponent<CharacterController>();
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
        _charSpriteRenderer = gameObject.GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        _charController.OnMoveEvent += Move;
        _charController.OnLookEvent += Look;
    }

    private void FixedUpdate()
    {
        ApplayMovement();
    }

    public void Look(Vector2 dir)
    {
        _charSpriteRenderer.flipX = (dir.x < 0); // 2D Sprite를 뒤집어서 마우스 방향을 바라보게 만듦
    }

    public void Move(Vector2 dir)
    {
        _direction = dir; // 이동 방향 등록
    }

    public void ApplayMovement()
    {
        _rigidbody.velocity = _direction.normalized * _speed;
    }
}
