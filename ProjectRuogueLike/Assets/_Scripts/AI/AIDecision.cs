using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIDecision : MonoBehaviour
{
    protected AIActionData _aiActionData;
    protected AIMovementData _aiMovementData;
    protected EnemyAIBrain _enemyBrain;

    private void Awake()
    {
        _aiActionData = transform.root.GetComponentInChildren<AIActionData>();
        _aiMovementData = transform.root.GetComponentInChildren<AIMovementData>();
        _enemyBrain = transform.root.GetComponentInChildren<EnemyAIBrain>();
    }

    public abstract bool MakeAdecision();
}
