using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIState : MonoBehaviour
{    
    private EnemyAIBrain _enemyBrain = null;
    [SerializeField]
    private List<AIAction> _actions = null;
    [SerializeField]
    private List<AITransition> _transitions = null;

    private void Awake()
    {
        _enemyBrain = transform.root.GetComponent<EnemyAIBrain>();
    }

    public void UpdateState()
    {
        foreach (var action in _actions)
        {
            action.TakeAction();
        }

        foreach (var transition in _transitions)
        {
            bool result = false;
            foreach (var decision in transition.Decisions)
            {
                result = decision.MakeAdecision();

                if (result == false)
                {
                    break;
                }

            }
            if (result == true)
            {
                if (transition.PositiveResult != null )
                {
                    _enemyBrain.ChangeToState(transition.PositiveResult);
                    return;
                }
            }
            else
            {
                if (transition.NegativeResult != null)
                {
                    _enemyBrain.ChangeToState(transition.NegativeResult);
                    return;
                }
               
            }
        }
    }
}
