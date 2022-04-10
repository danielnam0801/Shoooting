using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private string nextSceneName;
    [SerializeField]
    private StageData stageData;
    [SerializeField]
    private KeyCode keycodeAttack = KeyCode.Space;
    private Weapon weapon;

    private int score;
    public int Score
    {
        set => score = Mathf.Max(0,value);
        get => score;
    }

    public float speed = 10f;

    private Rigidbody2D rb = null;

    public GameObject bullet = null;

    public float shootDuration = 0.5f;

    private void Start()
    {
        weapon = GetComponent<Weapon>();
        rb = GetComponent<Rigidbody2D>();

        //StartCoroutine(Shooting());
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (Input.GetKeyDown(keycodeAttack))
        {
            weapon.StartFiring();
        }
        else if (Input.GetKeyUp(keycodeAttack))
        {
            weapon.StopFiring();
        }
    }

    private void Move()
    {

        //가로기준 왼쪽 : -1  안누르면 : 0  오른쪽 :1
        float hori = Input.GetAxisRaw("Horizontal");
        //세로기준 위 : 1 안누르면 : 0 밑 : -1
        float verti = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector2(hori, verti).normalized * speed;
    }

    public void OnDie()
    {
        SceneManager.LoadScene(nextSceneName);
    }

    /*private IEnumerator Shooting()
    {
        while (true)
        {
            yield return new WaitForSeconds(shootDuration);
            Instantiate(bullet, transform.position, Quaternion.identity);
        }
    }*/


}   