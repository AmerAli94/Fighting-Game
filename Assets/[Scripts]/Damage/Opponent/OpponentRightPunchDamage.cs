using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentRightPunchDamage : MonoBehaviour
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
        damage = Random.Range(5.0f, 7.0f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Opponent punched");
            player.RightPunchDamage(damage);
        }
    }
}
