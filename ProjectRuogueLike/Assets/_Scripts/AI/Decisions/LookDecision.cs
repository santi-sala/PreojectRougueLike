using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LookDecision : AIDecision
{
    [SerializeField]
    [Range(1, 15)]
    private float _distance = 15;

    [SerializeField]
    private LayerMask _raycastMask = new LayerMask();

    [field: SerializeField]
    public UnityEvent OnplayerSpotted { get; set; }

    public override bool MakeAdecision()
    {
        var direction = _enemyBrain.Target.transform.position - transform.position;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, _distance, _raycastMask);
        if (hit.collider != null && hit.collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            OnplayerSpotted?.Invoke();
            return true;
        }
        return false;
    }

    private void OnDrawGizmos()
    {
        if (UnityEditor.Selection.activeObject == gameObject && _enemyBrain != null && _enemyBrain.Target != null)
        {
            Gizmos.color = Color.yellow;
            var direction = _enemyBrain.Target.transform.position - transform.position;
            Gizmos.DrawRay(transform.position, direction.normalized * _distance);
        }
    }
}
