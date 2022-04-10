using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float speed;


    // Start is called before the first frame update
    protected virtual void Start()
    {
        speed = 20;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Square"))
        {
            //other.GetComponent<Enemy>().OnDie();
            Destroy(gameObject);
        }

    }
}
