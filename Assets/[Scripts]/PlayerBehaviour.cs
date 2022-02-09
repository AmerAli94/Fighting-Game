using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    private Animator _anim;
    private Rigidbody _rb;


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
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
            _anim.SetBool("Walk", false);
            _anim.SetBool("Walk_Back", false);
            _anim.SetBool("Crouch", false);
            //_anim.SetFloat("WalkSpeed", 1, 0.1f, Time.deltaTime);
        }

        if (Input.GetAxis("Vertical") == 0.0)
        {
            _anim.SetBool("Walk", false);
            _anim.SetBool("Walk_Back", false);
            _anim.SetBool("Crouch", false);
            //_anim.SetFloat("WalkSpeed", 1, 0.1f, Time.deltaTime);
        }
        //Walk front
        if (Input.GetAxis("Horizontal") > 0.1)
        {
            _anim.SetBool("Walk", true);
            _anim.SetBool("Walk_Back", false);
            _anim.SetBool("Crouch", false);
            //_anim.SetFloat("WalkSpeed", 1, 0.1f, Time.deltaTime);
        }

        // Walk Back
        if (Input.GetAxis("Horizontal") < -0.1)
        {
            _anim.SetBool("Walk_Back", true);
            _anim.SetBool("Walk", false);
            _anim.SetBool("Crouch", false);
            // _anim.SetFloat("WalkSpeed", 1, 0.1f, Time.deltaTime);


        }

        // Crouch
        if (Input.GetAxis("Vertical") < -0.1)
        {
            _anim.SetBool("Crouch", true);
            _anim.SetBool("Walk_Back", false);
            _anim.SetBool("Walk", false);

        }

        // Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _anim.SetTrigger("Jump");
            _anim.SetBool("Walk", false);
            _anim.SetBool("Walk_Back", false);
            _anim.SetBool("Crouch", false);

        }

        // Punch
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _anim.SetTrigger("Punch");
            _anim.SetBool("Walk", false);
            _anim.SetBool("Walk_Back", false);
            _anim.SetBool("Crouch", false);

        }

        // Kick
        if (Input.GetKeyDown(KeyCode.E))
        {
            _anim.SetTrigger("Kick");
            _anim.SetBool("Walk", false);
            _anim.SetBool("Walk_Back", false);
            _anim.SetBool("Crouch", false);

        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();

        }

    }

}
