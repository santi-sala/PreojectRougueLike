using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseAction : AIAction
{
    public override void TakeAction()
    {
        var direction = _enemyAIBrain.Target.transform.position - transform.position;
        _aiMovementData.Direction = direction.normalized;
        _aiMovementData.PointOfInterest = _enemyAIBrain.Target.transform.position;
        _enemyAIBrain.Move(_aiMovementData.Direction, _aiMovementData.PointOfInterest);
    }
}
