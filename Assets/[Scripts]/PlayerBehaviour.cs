using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public static float MAX_HEALTH = 100f;

    public float health = MAX_HEALTH;
    public Animator anim;
    public States currentState = States.IDLE;
    private Rigidbody _rb;
    public Collider rightPunchCollider;
    public Collider leftPunchCollider;
    public Collider leftKickCollider;
    public Collider rightKickCollider;
    private Collider playerCollider;

    int CurrentComboPriorty = 0;

    ControlManager controlManager;

    void Awake()
    {
        if (anim == null)
            anim = GetComponent<Animator>();
        if (controlManager == null)
            controlManager = FindObjectOfType<ControlManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        playerCollider = GetComponent<Collider>();
        
    }


    // Update is called once per frame
    void Update()
    {
        UpdatePlayerInput();
    }

    public void UpdatePlayerInput()
    {
        //Idle
        if (Input.GetAxis("Horizontal") == 0.0)
        {
            anim.SetBool("Walk", false);
            anim.SetBool("Walk_Back", false);
            anim.SetBool("Crouch", false);
            //_anim.SetFloat("WalkSpeed", 1, 0.1f, Time.deltaTime);
        }

        if (Input.GetAxis("Vertical") == 0.0)
        {
            anim.SetBool("Walk", false);
            anim.SetBool("Walk_Back", false);
            anim.SetBool("Crouch", false);
            //_anim.SetFloat("WalkSpeed", 1, 0.1f, Time.deltaTime);
        }

        // Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("Jump");
            anim.SetBool("Walk", false);
            anim.SetBool("Walk_Back", false);
            anim.SetBool("Crouch", false);

        }

        //Block
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            anim.SetBool("Block", true);
            anim.SetBool("Walk", false);
            anim.SetBool("Walk_Back", false);
            anim.SetBool("Crouch", false);

        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            anim.SetBool("Block", false);
            anim.SetBool("Walk", false);
            anim.SetBool("Walk_Back", false);
            anim.SetBool("Crouch", false);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();

        }

        if(transform.rotation.eulerAngles.y == 90.0f)
        {
            DefaultHorizontalMovement();
        }
        else
        {
            invertedHorizontalInput();
        }



    }
    public void PlayMove(combosList combo, int ComboPriorty) //Get the Move and the Priorty
    {
        if (combosList.None != combo) //if the move is none ignore the function
        {
            if (ComboPriorty >= CurrentComboPriorty) //if the new move is higher Priorty play it and ignore everything else
            {
                CurrentComboPriorty = ComboPriorty; //Set the new Combo
                ResetTriggers(); //Reset All Animation Triggers
                controlManager.ResetCombo(); //Reset the List in the ControlsManager
            }
            else
                return;

            //Set the Animation Triggers
            switch (combo)
            {
                case combosList.Punch_R:
                    anim.SetTrigger("Punch");
                    break;
                case combosList.Punch_L:
                    anim.SetTrigger("Punch_L");
                    break;
                case combosList.Punch_Combo:
                    anim.SetTrigger("Punch_Combo");
                    break;
                case combosList.Kick_R:
                    anim.SetTrigger("Kick_R");
                    break;
                case combosList.Kick_L:
                    anim.SetTrigger("Kick_L");
                    break;
                case combosList.Block:
                    anim.SetBool("Block", true);
                    break;
            }

            CurrentComboPriorty = 0; //Reset the Combo Priorty
        }
    }

    void DefaultHorizontalMovement()
    {
      
        //Walk front
        if (Input.GetAxis("Horizontal") > 0.1)
        {
            anim.SetBool("Walk", true);
            anim.SetBool("Walk_Back", false);
            anim.SetBool("Crouch", false);
            //_anim.SetFloat("WalkSpeed", 1, 0.1f, Time.deltaTime);
        }

        // Walk Back
        if (Input.GetAxis("Horizontal") < -0.1)
        {
            anim.SetBool("Walk_Back", true);
            anim.SetBool("Walk", false);
            anim.SetBool("Crouch", false);
            // _anim.SetFloat("WalkSpeed", 1, 0.1f, Time.deltaTime);
        }
    }

    void invertedHorizontalInput()
    {

        //Walk front
        if (Input.GetAxis("Horizontal") > 0.1)
        {
            anim.SetBool("Walk", false);
            anim.SetBool("Walk_Back", true);
            anim.SetBool("Crouch", false);
            //_anim.SetFloat("WalkSpeed", 1, 0.1f, Time.deltaTime);
        }

        // Walk Back
        if (Input.GetAxis("Horizontal") < -0.1)
        {
            anim.SetBool("Walk_Back", false);
            anim.SetBool("Walk", true);
            anim.SetBool("Crouch", false);
            // _anim.SetFloat("WalkSpeed", 1, 0.1f, Time.deltaTime);
        }
    }
    void ResetTriggers() //Reset All the Animation Triggers so we don't have overlapping animations
    {
        foreach (AnimatorControllerParameter parameter in anim.parameters)
        {
            anim.ResetTrigger(parameter.name);
        }
    }

    public float healthPercent
    {
        get
        {
            return health / MAX_HEALTH;
        }
    }

    public void OpenColliderForJump()
    {
        playerCollider.enabled = true;
    }

    public void CloseColliderForJump()
    {
        playerCollider.enabled = false;
    }

    public void OpenRightPunchCollider()
    {
        rightPunchCollider.enabled = true;
    }
    public void CloseRightPunchCollider()
    {
        rightPunchCollider.enabled = false;
    }
    public void OpenLeftPunchCollider()
    {
        leftPunchCollider.enabled = true;
    }
    public void CloseLeftPunchCollider()
    {
        leftPunchCollider.enabled = false;
    }

    public void OpenLeftKickCollider()
    {
        leftKickCollider.enabled = true;
    }
    public void CloseLeftKickCollider()
    {
        leftKickCollider.enabled = false;
    }

    public void OpenRightKickCollider()
    {
        rightKickCollider.enabled = true;
    }
    public void CloseRightKickCollider()
    {
        rightKickCollider.enabled = false;
    }


    public virtual void RightPunchDamage(float damage)
    {
        if (blocking)
        {
            damage *= 0.2f;
        }
        if (health >= damage)
        {
            health -= damage;
        }
        else
        {
            health = 0;
        }

        if (health > 0 && currentState != States.BLOCK)
        {
            anim.SetTrigger("Take_Hit");
        }

        if (health <= 0 && currentState != States.DEAD)
        {
            anim.SetTrigger("Dead");
        }
    }

    public virtual void LeftPunchDamage(float damage)
    {

        if (blocking)
        {
            damage *= 0.2f;
        }
        if (health >= damage)
        {
            health -= damage;
        }
        else
        {
            health = 0;
        }

        if (health > 0 && currentState != States.BLOCK)
        {
            anim.SetTrigger("Take_Hit");
        }

        if (health <= 0 && currentState != States.DEAD)
        {
            anim.SetTrigger("Dead");
        }
    }

    public bool blocking
    {
        get
        {
            return currentState == States.BLOCK;
        }
    }


}
