using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = 9;
    private float jumpPwr = 700;
    public bool grounded;

    public int health = 3;
    


    void Start()
    {
        //Ger rb = rigidbodyn på spelaren (förkortning).
        rb = GetComponent<Rigidbody2D>();
    }



    void Update()
    {
        //Går höger
        if (Input.GetKey(KeyCode.D))
            rb.velocity = new Vector2(speed, rb.velocity.y);
        if (Input.GetKeyUp(KeyCode.D))
            rb.velocity = new Vector2(0, rb.velocity.y);

        //Gå vänster
        if (Input.GetKey(KeyCode.A))
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        if (Input.GetKeyUp(KeyCode.A))
            rb.velocity = new Vector2(0, rb.velocity.y);

        //Hoppa
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(new Vector2(0, jumpPwr));
            grounded = false;
        }

        //Ducka
        if (Input.GetKeyDown(KeyCode.S))
        {
            GetComponent<Transform>().localScale = Vector3.one;
            GetComponent<Transform>().localPosition = new Vector2(transform.position.x, transform.position.y - 0.5f);
            GameObject.Find("Main Camera").transform.localPosition = new Vector3(0, 0.5f, -10);
        }
        //Ducka inte längre
        if (Input.GetKeyUp(KeyCode.S))
        {
            GetComponent<Transform>().localScale = new Vector3(1,2,1);
            GetComponent<Transform>().localPosition = new Vector2(transform.position.x, transform.position.y + 0.5f);
            GameObject.Find("Main Camera").transform.localPosition = new Vector3(0, 0, -10);
        }

    }


    //Känner av när spelaren nuddar något. Känner sedan av om collidern som nuddades har taggen "Ground". Om detta stämmer blir spelaren grounded vilket ger möjlighet att hoppa.
    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.tag == "Ground")
        {
            grounded = true;
        }
    }
    

    //Samma som ovan fast när spelaren lämnar objektet. 
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.ToString() == "Ground")
        {
            grounded = false;
        }
        if (collision.gameObject.name.ToString() == "Danger")
            {
            SceneManager.LoadScene("Map");
            }
    }
}
