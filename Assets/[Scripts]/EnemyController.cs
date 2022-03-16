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

    private float random;
    private float randonSetTime;

    void Awake()
    {
        if (anim == null)
            anim = GetComponent<Animator>();

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

        if(Time.time - randonSetTime > 1)
        {
            random = Random.value;
            randonSetTime = Time.time;
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
        if (health >= damage)
        {
            health -= damage;
        }
        else
        {
            health = 0;
        }

        if (health > 0)
        {
            anim.SetTrigger("Take_Hit");
        }

        if (health <= 0)
        {
            anim.SetTrigger("Dead");
        }
    }


    public virtual void LeftPunchDamage(float damage)
    {
        if (health >= damage)
        {
            health -= damage;
        }
        else
        {
            health = 0;
        }

        if (health > 0)
        {
            anim.SetTrigger("Take_Hit_LP");
        }
        if (health <= 0)
        {
            anim.SetTrigger("Dead");
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

}
