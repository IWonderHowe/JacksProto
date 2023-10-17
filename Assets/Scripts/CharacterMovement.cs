using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    // Movement variables
    [SerializeField] private float _accelTime = 0.25f;
    [SerializeField] private float _decelTime = 0.25f;
    [SerializeField] private float _maxSpeed = 3f;

    private Rigidbody2D _rb;

    private float _accelForce;
    private float _decelForce;
    private float _xVelocity;
    private float _yVelocity;
    private Vector2 _velocity;

    private Vector2 _moveInput = Vector2.zero;


    // Start is called before the first frame update
    void Start()
    {
        SetMovementForces();
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_moveInput != Vector2.zero)
        {
            _rb.drag = 0;
            _rb.AddForce(_moveInput * _accelForce, ForceMode2D.Force);
        }
        else
        {
            _rb.drag = _decelForce;
        }

        _rb.velocity = Vector2.ClampMagnitude(_rb.velocity, _maxSpeed);
    }

    /* Setting the movement forces for the player.
     * Calculating based on acceleration/deceleration time and max speed
     * Done this way for easier iteration */
    private void SetMovementForces()
    {
        _accelForce = _maxSpeed / _accelTime;
        _decelForce = 1 / _decelTime;
    }

    private void OnMove(InputValue value)
    {
        _moveInput = value.Get<Vector2>();
    }
}
