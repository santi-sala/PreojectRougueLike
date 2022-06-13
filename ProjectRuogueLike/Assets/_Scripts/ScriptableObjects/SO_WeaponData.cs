using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapons/WeaponData")]
public class SO_WeaponData : ScriptableObject
{
    [field: SerializeField]
    public SO_BulletData BulletData { get; set; }

    [field: SerializeField]
    [field: Range(0, 100)]
    public int AmmoCapacity { get; set; } = 100;

    [field: SerializeField]
    public bool AutomaticFire { get; set; } = false;

    [field: SerializeField]
    [field: Range(0.1f, 2f)]
    public float WeaponDelay { get; set; } = 0.1f;

    [field: SerializeField]
    [field: Range(0, 10)]
    public float SpreadAngle { get; set; } = 5;

    [SerializeField]
    private bool _multiBulletShoot = false;

    [SerializeField]
    [Range(1, 10)]
    private int _bulletCount = 1;


    internal int GetBulletCountToSpawn()
    {
        if (_multiBulletShoot)
        {
            return _bulletCount;
        }
        else
        {
            return 1;
        }
    }
}
