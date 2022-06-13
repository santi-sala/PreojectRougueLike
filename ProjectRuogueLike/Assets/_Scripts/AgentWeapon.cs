using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentWeapon : MonoBehaviour
{
    private float _desiredAngle;

    [SerializeField]
    private WeaponRenderer _weaponRenderer;
    [SerializeField]
    private Weapon _weapon;

    private void Awake()
    {
        AssignWeapon();
    }

    private void AssignWeapon()
    {
        _weaponRenderer = GetComponentInChildren<WeaponRenderer>();
        _weapon = GetComponentInChildren<Weapon>();
    }

    public virtual void AimWeapon(Vector2 pointerPosition)
    {
        var aimDirection = (Vector3)pointerPosition - transform.position;
        _desiredAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        AdjustWeaponRendering();
        transform.rotation = Quaternion.AngleAxis(_desiredAngle, Vector3.forward);
    }

    private void AdjustWeaponRendering()
    {
        if (_weaponRenderer != null)
        {
            _weaponRenderer.FlipSprite(_desiredAngle > 90 || _desiredAngle < -90);
            _weaponRenderer.RenderBehindHead(_desiredAngle < 180 && _desiredAngle > 0);
        }
    }

    public void Shoot()
    {
        if (_weapon != null)
        {
            _weapon.TryShooting();
        }
    }

    public void StopShooting()
    {
        if (_weapon != null)
        {
            _weapon.StopShooting();    
        }
    }
}
