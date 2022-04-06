using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject player = null;
    public GameObject bullet = null;
    public GameObject enemy = null;
    public float enemyDuration = 3f;
    public Vector3 spawnPos = Vector3.zero;
    public Transform maxPos = null;
    public Transform minPos = null;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        // Quaternion.identity : ������ 0 0 0 ���� �ٲپ� �ش�
        //GameObject g = Instantiate(player, spawnPos, Quaternion.identity);
        //rb = g.GetComponent<Rigidbody2D>();
        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    //void Update()
    //{
    //    Move();
    //    SpawnBullet();
    //}

    private void Move()
    {

        //���α��� ���� : -1  �ȴ����� : 0  ������ :1
        float hori = Input.GetAxisRaw("Horizontal");
        //���α��� �� : 1 �ȴ����� : 0 �� : -1
        float verti = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector2(hori, verti).normalized * 10f;
    }


    private void SpawnBullet()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet, rb.transform.position , Quaternion.identity);
        }
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            Instantiate(enemy, new Vector2(Random.Range(minPos.position.x, maxPos.position.x), maxPos.position.y), enemy.transform.rotation);
            yield return new WaitForSeconds(enemyDuration);
        }
        
    }
}