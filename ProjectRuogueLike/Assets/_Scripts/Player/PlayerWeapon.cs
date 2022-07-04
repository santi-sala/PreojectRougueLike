using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : AgentWeapon
{
    [SerializeField]
    private UIAmmo _uiAmmo = null;

    public bool AmmoFull { get => _weapon != null && _weapon.AmmoFull;}

    private void Start()
    {
        if (_weapon != null)
        {
            _weapon.OnAmmoChange.AddListener(_uiAmmo.UpdateBulletText);
            _uiAmmo.UpdateBulletText(_weapon.Ammo);
        }
    }

    public void AddAmmo(int amount)
    {
        if (_weapon != null)
        {
            _weapon.Ammo += amount;
        }
    }
}
