using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAttack : MonoBehaviour
{
    private EnemyAIBrain _enemyBrain;

    [field: SerializeField]
    public float AttackDelay { get; private set; } = 1;
    protected bool _waitForNextAttack;

    private void Awake()
    {
        _enemyBrain = GetComponent<EnemyAIBrain>();
    }

    public abstract void Attack(int damage);

    protected IEnumerator WaitBaforeAttackCoroutine()
    {
        _waitForNextAttack = true;
        yield return new WaitForSeconds(AttackDelay);
        _waitForNextAttack = false;
    }

    protected GameObject GetTarget()
    {
        return _enemyBrain.Target;
    }

}


