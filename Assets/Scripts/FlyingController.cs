using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingController : MonoBehaviour
{
    public float speed;

    public bool attack;

    private GameObject Player;

    void Start()
    {
        Player = GameObject.Find("Player");
        transform.position = Player.transform.position + new Vector3(30, Random.Range(2,6), 0);
    }

    void Update()
    {
        if (!attack)
        {
            if (transform.position.x - Player.transform.position.x > 5f)
                GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, GetComponent<Rigidbody2D>().velocity.y);

            else
            {
                attack = true;

                GetComponent<Rigidbody2D>().velocity = new Vector2(-speed*2, 0);
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -(transform.position.y - Player.transform.position.y)*1.5f), ForceMode2D.Impulse);

            }
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (!attack)
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, -8);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!attack)
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 0);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Player)
            --Player.GetComponent<PlayerController>().health;

        Destroy(gameObject);
    }
}
