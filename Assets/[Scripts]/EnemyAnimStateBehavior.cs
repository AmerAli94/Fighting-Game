using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimStateBehavior : StateMachineBehaviour
{

    public float horizontalForce;
    public float verticalForce;
    public States opponentStateBehaviour;

    protected EnemyController _enemy;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_enemy == null)
        {
            _enemy = animator.gameObject.GetComponent<EnemyController>();
        }
        _enemy.currentState = opponentStateBehaviour;
        Rigidbody rb = _enemy.GetComponent<Rigidbody>();
        rb.AddRelativeForce(new Vector3(0, verticalForce, 0));

    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Rigidbody rb = _enemy.GetComponent<Rigidbody>();
        rb.AddRelativeForce(new Vector3(0, 0, horizontalForce));

    }
}
