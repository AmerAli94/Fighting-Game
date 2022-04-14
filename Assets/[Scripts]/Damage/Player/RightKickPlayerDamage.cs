using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightKickPlayerDamage : MonoBehaviour
{
    public EnemyController enemy;
    public float damage;
    private Collider punchCollider;
    public void Start()
    {
        punchCollider = GetComponent<Collider>();
        punchCollider.enabled = false;
    }
    private void Update()
    {
        damage = Random.Range(4.5f, 6.0f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Opponent"))
        {
            enemy.LeftKickDamage(damage);
        }
    }
}
