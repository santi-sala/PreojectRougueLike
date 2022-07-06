using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceDecision : AIDecision
{
    [field: SerializeField]
    [field: Range(0.1f, 15)]
    public float Distance { get; set; } = 5;

    public override bool MakeAdecision()
    {
        if (Vector3.Distance(_enemyBrain.Target.transform.position, transform.position) < Distance)
        {
            if (_aiActionData.TargetSpotted == false)
            {
                _aiActionData.TargetSpotted = true;               
            }
        }
        else
        {
            _aiActionData.TargetSpotted = false;                
        }

        return _aiActionData.TargetSpotted;
    }

    // For debugging purpose to visualize the radius of "view" of the enemy.
    private void OnDrawGizmos()
    {
        if (UnityEditor.Selection.activeObject == gameObject)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, Distance);
            Gizmos.color = Color.white;
        }
    }
}
