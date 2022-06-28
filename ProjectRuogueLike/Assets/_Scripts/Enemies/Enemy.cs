using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour, IHittable, IAgent
{
    [field: SerializeField]
    public SO_EnemyData EnemyData { get; set; }

    [field: SerializeField]
    public int Health { get; private set; } = 2;

    [field: SerializeField]
    public EnemyAttack enemeyAttack { get; set; }

    [SerializeField]
    private bool _dead = false;

    [field: SerializeField]
    public UnityEvent OnGetHit { get; set; }

    [field: SerializeField]
    public UnityEvent OnDie { get; set; }


    private void Awake()
    {
        if (enemeyAttack == null)
        {
            enemeyAttack = GetComponent<EnemyAttack>();
        }
    }

    private void Start()
    {
        Health = EnemyData.MaxHealth;
    }

    public void GetHit(int damage, GameObject damageDealer)
    {
        if (_dead == false)
        {
            Health -= damage;
            OnGetHit?.Invoke();
            if (Health <= 0)
            {
                _dead = true;
                OnDie?.Invoke();
            }
        }

    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public void PerformAttack()
    {
        if (_dead == false)
        {
            enemeyAttack.Attack(EnemyData.Damage);
        }
    }
}
