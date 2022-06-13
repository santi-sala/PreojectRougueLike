using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class WeaponRenderer : MonoBehaviour
{
    [SerializeField]
    private int _playerSortingOrder = 0;

    private SpriteRenderer _weaponRenderer;

    private void Awake()
    {
        _weaponRenderer = GetComponent<SpriteRenderer>();
    }

    public void FlipSprite(bool value)
    {
        //int flipModifier = value ? -1 : 1;
        int flipModifier;
        if (value)
        {
            flipModifier = -1;
        }
        else
        {
            flipModifier = 1;
        }
        
        transform.localScale = new Vector3(transform.localScale.x, flipModifier * Mathf.Abs(transform.localScale.y), transform.localScale.z);
    }

    public void RenderBehindHead(bool value)
    {
        if (value)
        {
            _weaponRenderer.sortingOrder = _playerSortingOrder - 1;
        }
        else
        {
            _weaponRenderer.sortingOrder = _playerSortingOrder + 1;
        }
    }
}
