using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingController : MonoBehaviour
{
    public float speed;

    public bool attack;

    private GameObject Player;
    private Rigidbody2D rb;

    public GameObject projectile;



    void Start()
    {
        Player = GameObject.Find("Player");
        transform.position = new Vector3(Player.transform.position.x + 16, -2f, 0);
        rb = GetComponent<Rigidbody2D>();
    }



    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, rb.velocity.y);

        if (!attack)
        {
            if (transform.position.x - Player.transform.position.x < 5f)
            {
                Instantiate(projectile, new Vector3(transform.position.x, transform.position.y + 1.3f, transform.position.z), Quaternion.identity);
                attack = true;
            }
        }

    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Player)
        {
            --Player.GetComponent<PlayerController>().health;

            Destroy(gameObject);
        }

    }
}
