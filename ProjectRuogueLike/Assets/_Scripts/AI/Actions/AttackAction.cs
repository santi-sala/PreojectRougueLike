using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAction : AIAction
{
    public override void TakeAction()
    {
        _aiMovementData.Direction = Vector2.zero;
        _aiMovementData.PointOfInterest = _enemyAIBrain.Target.transform.position;
        _enemyAIBrain.Move(_aiMovementData.Direction, _aiMovementData.PointOfInterest);
        _aiActionData.Attack = true;
        _enemyAIBrain.Attack();
    }
}
