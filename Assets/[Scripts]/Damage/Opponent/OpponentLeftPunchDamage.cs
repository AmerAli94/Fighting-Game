using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentLeftPunchDamage : MonoBehaviour
{
    public PlayerBehaviour player;
    public float damage;
    private Collider punchCollider;
    public void Start()
    {
        punchCollider = GetComponent<Collider>();
        punchCollider.enabled = false;
    }
    private void Update()
    {
        damage = Random.Range(2.5f, 3.5f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Opponent punched");
            player.LeftPunchDamage(damage);
        }
    }
}
