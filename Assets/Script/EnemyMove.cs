using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : BulletMove
{
    protected override void Start()
    {
        speed = 10;
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Bullet") || other.CompareTag("Square"))
        {
            Destroy(gameObject);
        }
    }


    
    // Start is called before the first frame update

}
