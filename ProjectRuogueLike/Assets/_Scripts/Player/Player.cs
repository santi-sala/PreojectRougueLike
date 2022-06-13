using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour, IAgent, IHittable
{
    [field: SerializeField]
    public int Health { get; set; }

    [SerializeField]
    private bool _dead = false;
    
    [field: SerializeField]
    public UnityEvent OnDie { get; set; }
    
    [field: SerializeField]
    public UnityEvent OnGetHit { get; set; }

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
                StartCoroutine(DeathCoroutine());
            }
        }
        
    }

    IEnumerator DeathCoroutine()
    {
        yield return new WaitForSeconds(0.25f);
        Destroy(gameObject);
    }
}
