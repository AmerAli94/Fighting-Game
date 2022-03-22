using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public static float MAX_HEALTH = 100f;

    public float health = MAX_HEALTH;

    public Animator anim;
    public Transform playerTransform;
    public Collider opponentRightPunchCollider;
    public Collider opponentLeftPunchCollider;
    public Collider opponentLeftKickCollider;
    public Collider opponentRightKickCollider;
    private AudioSource sound_FX;

    public States currentState = States.IDLE;
    private float random;
    private float randomSetTime;
    public PlayerBehaviour player;

    void Awake()
    {
        if (anim == null)
            anim = GetComponent<Animator>();
        sound_FX = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateOpponentInput();
    }

    public void UpdateOpponentInput()
    {
        anim.SetFloat("Random", random);
        anim.SetFloat("distanceToPlayer", GetDistanceToPlayer());

        if (Time.time - randomSetTime > 1)
        {
            random = Random.value;
            randomSetTime = Time.time;
        }
    }

    public float healthPercent
    {
        get
        {
            return health / MAX_HEALTH;
        }
    }

    private float GetDistanceToPlayer()
    {
        return Mathf.Abs(transform.position.x - playerTransform.transform.position.x);
    }

    public virtual void RightPunchDamage(float damage)
    {
        if(blocking)
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
            anim.SetTrigger("Take_Hit_LP");
        }

        if (health <= 0 && currentState != States.DEAD)
        {
            anim.SetTrigger("Dead");
            player.setPlayerInputOff();
            if (player.isDead)
            {
                anim.SetTrigger("Celebrate 0");
            }
        }
    }

    public virtual void RightKickDamage(float damage)
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
            anim.SetTrigger("Take_Hit_LP");
        }

        if (health <= 0 && currentState != States.DEAD)
        {
            anim.SetTrigger("Dead");
            player.setPlayerInputOff();
            if (player.isDead)
            {
                anim.SetTrigger("Celebrate 0");
            }
        }
    }

    public virtual void LeftKickDamage(float damage)
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
            player.setPlayerInputOff();
            if (player.isDead)
            {
                anim.SetTrigger("Celebrate 0");
            }
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
            player.setPlayerInputOff();
            if (player.isDead)
            {
                anim.SetTrigger("Celebrate 0");
            }
        }

    }

    public void OpenOpponentLeftPunchCollider()
    {
        opponentLeftPunchCollider.enabled = true;
    }

    public void CloseOpponentLeftPunchCollider()
    {
        opponentLeftPunchCollider.enabled = false;
    }

    public void OpenOpponentRightPunchCollider()
    {
        opponentRightPunchCollider.enabled = true;
    }

    public void CloseOpponentRightPunchCollider()
    {
        opponentRightPunchCollider.enabled = false;
    }

    public void OpenOpponentLeftKickCollider()
    {
        opponentLeftKickCollider.enabled = true;
    }

    public void CloseOpponentLeftKickCollider()
    {
        opponentLeftKickCollider.enabled = false;
    }

    public bool blocking
    {
        get
        {
            return currentState == States.BLOCK;
        }
    }


    public void playSound(AudioClip sound)
    {
        GameUtils.playSound(sound, sound_FX);
    }


}
