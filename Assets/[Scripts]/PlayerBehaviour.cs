using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    public Animator anim;
    private Rigidbody _rb;

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

        // Crouch
        if (Input.GetAxis("Vertical") < -0.1)
        {
            anim.SetBool("Crouch", true);
            anim.SetBool("Walk_Back", false);
            anim.SetBool("Walk", false);

        }

        // Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("Jump");
            anim.SetBool("Walk", false);
            anim.SetBool("Walk_Back", false);
            anim.SetBool("Crouch", false);

        }

        //// Punch
        //if (Input.GetKeyDown(KeyCode.Q))
        //{
        //    _anim.SetTrigger("Punch");
        //    _anim.SetBool("Walk", false);
        //    _anim.SetBool("Walk_Back", false);
        //    _anim.SetBool("Crouch", false);

        //}

        //// Kick
        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    _anim.SetTrigger("Kick");
        //    _anim.SetBool("Walk", false);
        //    _anim.SetBool("Walk_Back", false);
        //    _anim.SetBool("Crouch", false);

        //}

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();

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
                case combosList.Punch:
                    anim.SetTrigger("Punch");
                    Debug.Log("Punching");
                    break;
                case combosList.Kick:
                    anim.SetTrigger("Kick");
                    Debug.Log("Kicking");

                    break;
                
            }

            CurrentComboPriorty = 0; //Reset the Combo Priorty
        }
    }

    void ResetTriggers() //Reset All the Animation Triggers so we don't have overlapping animations
    {
        foreach (AnimatorControllerParameter parameter in anim.parameters)
        {
            anim.ResetTrigger(parameter.name);
        }
    }

}
