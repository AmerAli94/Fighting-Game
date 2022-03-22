using System.Collections;
using UnityEngine;

public class PlayerAnimStateBehaviour : StateMachineBehaviour
{
    public float horizontalForce;
    public float verticalForce;
    public States stateBehaviour;
    public AudioClip soundFX;
    
    protected PlayerBehaviour _player;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_player == null)
        {
            _player = animator.gameObject.GetComponent<PlayerBehaviour>();
        }
        _player.currentState = stateBehaviour;
        Rigidbody rb = _player.GetComponent<Rigidbody>();
        rb.AddRelativeForce(new Vector3(0, verticalForce, 0));

        if(soundFX != null)
        {
            _player.playSound(soundFX);
        }

    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Rigidbody rb = _player.GetComponent<Rigidbody>();
        rb.AddRelativeForce(new Vector3(0, 0, horizontalForce));

    }
}
