using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentLeftKickDamage : MonoBehaviour
{
    public PlayerBehaviour player;
    public float damage;
    private Collider kickCollider;
    public void Start()
    {
        kickCollider = GetComponent<Collider>();
        kickCollider.enabled = false;
    }
    private void Update()
    {
        damage = Random.Range(4.5f, 6.0f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.LeftKickDamage(damage);
        }
    }
}
