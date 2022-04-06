using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int damage = 1;
    PlayerHp HP;
    private void Start()
    {
        HP = FindObjectOfType<PlayerHp>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")||collision.CompareTag("Square"))
        {
            HP.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
