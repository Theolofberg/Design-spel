using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{

    private GameObject Player;


    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(-600, 100));
        Player = GameObject.Find("Player");
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Player.GetComponent<PlayerController>().health -= 1;
        }

        Destroy(gameObject);
    }
}
