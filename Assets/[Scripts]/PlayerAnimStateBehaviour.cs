using System.Collections;
using UnityEngine;

public class PlayerAnimStateBehaviour : StateMachineBehaviour
{
    public float horizontalForce;
    public float verticalForce;

    protected PlayerBehaviour _player;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_player == null)
        {
            _player = animator.gameObject.GetComponent<PlayerBehaviour>();
        }

        Rigidbody rb = _player.GetComponent<Rigidbody>();
        rb.AddRelativeForce(new Vector3(0, verticalForce, 0));

    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Rigidbody rb = _player.GetComponent<Rigidbody>();
        rb.AddRelativeForce(new Vector3(0, 0, horizontalForce));

    }
}
