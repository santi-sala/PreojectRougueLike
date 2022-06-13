using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIAction : MonoBehaviour
{
    protected AIActionData _aiActionData;
    protected AIMovementData _aiMovementData;
    protected EnemyAIBrain _enemyAIBrain;

    private void Awake()
    {
        _aiActionData = transform.root.GetComponentInChildren<AIActionData>();
        _aiMovementData = transform.root.GetComponentInChildren<AIMovementData>();
        _enemyAIBrain = transform.root.GetComponentInChildren<EnemyAIBrain>();
    }

    public abstract void TakeAction();
}
