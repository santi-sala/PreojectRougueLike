using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class AgentMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    [field: SerializeField]
    public SO_MovementData MovementData { get; set; }

    [SerializeField]
    private float _currentVelocity;
    private Vector2 _movementDirection;

    private bool _isKnockedBack = false;

    [field: SerializeField]
    public UnityEvent<float> OnVelocityChange { get; set; }

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        OnVelocityChange?.Invoke(_currentVelocity);
        if (_isKnockedBack == false)
        {
            _rigidbody2D.velocity = _currentVelocity * _movementDirection.normalized;
        }
    }

    public void MoveAgent(Vector2 movementInput)
    {
        if (movementInput.magnitude > 0)
        {
            if (Vector2.Dot(movementInput.normalized, _movementDirection) < 0)
            {
                _currentVelocity = 0;
                _movementDirection = movementInput.normalized;
            }
            _movementDirection = movementInput.normalized;
        }
        _currentVelocity = CalculateSpeed(movementInput, _currentVelocity);
    }

    private float CalculateSpeed(Vector2 movementInput, float currentVelocity)
    {
        if (movementInput.magnitude > 0)
        {
            currentVelocity += MovementData.acceleration * Time.deltaTime;
        }
        else
        {
            currentVelocity -= MovementData.deAcceleration * Time.deltaTime;
        }
        return Math.Clamp(currentVelocity, 0, MovementData.maxSpeed);
    }

    public void StopImmediately()
    {
        _currentVelocity = 0;
        _rigidbody2D.velocity = Vector2.zero;
    }

    public void KnokedBack(Vector2 direction, float power, float duration)
    {
        if (_isKnockedBack == false)
        {
            _isKnockedBack = true;
            StartCoroutine(KnockeBackCoroutine(direction, power, duration));
        }
    }

    public void ResetKnockedBack()
    {
        StopAllCoroutines();
        StopCoroutine("KnockeBackCoroutine");
        ResetKnockedBackParameters();
    }

    IEnumerator KnockeBackCoroutine(Vector2 direction, float power, float duration)
    {
        _rigidbody2D.AddForce(direction.normalized * power, ForceMode2D.Impulse);
        yield return new WaitForSeconds(duration);
        ResetKnockedBackParameters();
    }

    private void ResetKnockedBackParameters()
    {
        _currentVelocity = 0;
        _rigidbody2D.velocity = Vector2.zero;
        _isKnockedBack = false;
    }
}
