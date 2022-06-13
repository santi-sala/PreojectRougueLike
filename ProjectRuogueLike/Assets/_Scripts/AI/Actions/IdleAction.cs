using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleAction : AIAction
{
    public override void TakeAction()
    {
        _aiMovementData.Direction = Vector2.zero;
        _aiMovementData.PointOfInterest = transform.position;
        _enemyAIBrain.Move(_aiMovementData.Direction, _aiMovementData.PointOfInterest);
    }
}
