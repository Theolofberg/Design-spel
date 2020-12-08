using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingController : MonoBehaviour
{
    public float speed;
    public float attackSpeed;

    public bool attack;

    private GameObject Player;
    private Rigidbody2D rb;



    void Start()
    {
        Player = GameObject.Find("Player");
        transform.position = new Vector3(Player.transform.position.x + 22, -2f, 0);
        rb = GetComponent<Rigidbody2D>();
    }



    void Update()
    {
        if (!attack)
        {
            if (transform.position.x - Player.transform.position.x < 5f)
            {
                rb.AddForce(new Vector2(0, attackSpeed), ForceMode2D.Impulse);

                attack = true;
            }
            else
                GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, rb.velocity.y);
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-speed*2.5f, rb.velocity.y);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!attack)
            rb.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
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
