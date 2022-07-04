using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour, IAgent, IHittable
{
    [SerializeField]
    private int _maxHealth;

    private int _health;
    
    public int Health {
        get => _health;
        set
        {
            _health = Mathf.Clamp(value, 0, _maxHealth);
            uiHealth.UpdateUI(_health);
        } 
    }

    
    private bool _dead = false;

    [field: SerializeField]
    public UIHealth uiHealth;
    
    [field: SerializeField]
    public UnityEvent OnDie { get; set; }
    
    [field: SerializeField]
    public UnityEvent OnGetHit { get; set; }

    private void Start()
    {
        Health = _maxHealth;
        uiHealth.Initialize(Health);
    }

    public void GetHit(int damage, GameObject damageDealer)
    {
        if (_dead == false)
        {
            Health -= damage;
            OnGetHit?.Invoke();
            if (Health <= 0)
            {
                OnDie?.Invoke();
                _dead = true;
                
            }
        }
        
    }

    
}
