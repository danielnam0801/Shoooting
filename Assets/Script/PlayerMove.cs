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

        //���α��� ���� : -1  �ȴ����� : 0  ������ :1
        float hori = Input.GetAxisRaw("Horizontal");
        //���α��� �� : 1 �ȴ����� : 0 �� : -1
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