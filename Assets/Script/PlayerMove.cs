using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    public float speed = 10f;

    private Rigidbody2D rb = null;

    public GameObject bullet = null;

    public float shootDuration = 0.5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Shooting());
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {

        //가로기준 왼쪽 : -1  안누르면 : 0  오른쪽 :1
        float hori = Input.GetAxisRaw("Horizontal");
        //세로기준 위 : 1 안누르면 : 0 밑 : -1
        float verti = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector2(hori, verti).normalized * speed;
    }

    private IEnumerator Shooting()
    {
        while (true)
        {
            yield return new WaitForSeconds(shootDuration);
            Instantiate(bullet, transform.position, Quaternion.identity);
        }
    }


}   