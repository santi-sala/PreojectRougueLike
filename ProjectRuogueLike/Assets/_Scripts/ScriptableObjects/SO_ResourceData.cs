using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Items/ResourceData")]
public class SO_ResourceData : ScriptableObject
{
    [field: SerializeField]
    public ResourceTypeEnum ResourceType { get; set; }

    [SerializeField]
    private int _minAmount = 1, _maxAmount = 5;

    public int GetAmount()
    {
        return Random.Range(_minAmount, _maxAmount + 1);
    }
}

public enum ResourceTypeEnum
{
    None,
    Health,
    Ammo
}
