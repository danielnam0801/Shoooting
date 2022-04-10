using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int damage = 1;
    [SerializeField]
    private int scorePoint = 100;
    private PlayerController playerController;
    PlayerHp HP;
    private void Start()
    {
        HP = FindObjectOfType<PlayerHp>();
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")||collision.CompareTag("Square"))
        {
            HP.TakeDamage(damage);
        }
        OnDie();
    }
    public void OnDie()
    {
        playerController.Score += scorePoint;
        Destroy(gameObject);
    }
}
