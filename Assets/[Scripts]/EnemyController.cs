using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public static float MAX_HEALTH = 100f;

    public float health = MAX_HEALTH;

    public Animator anim;
    public Transform playerTransform;
    private Rigidbody _rb;
    private float random;
    private float randonSetTime;
    void Awake()
    {
        if (anim == null)
            anim = GetComponent<Animator>();

    }
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
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
}
