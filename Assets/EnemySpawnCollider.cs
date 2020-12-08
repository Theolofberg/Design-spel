using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnCollider : MonoBehaviour
{
    public bool flying;
    public bool throwing;
    public bool walking;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == ("Player"))
        {
            if (flying)
                GameObject.Find("Enemy spawner").GetComponent<Enemyspawner>().spawnFlying = true;

            if (walking)
                GameObject.Find("Enemy spawner").GetComponent<Enemyspawner>().spawnWalking = true;

            if (throwing)
                GameObject.Find("Enemy spawner").GetComponent<Enemyspawner>().spawnThrowing = true;

            Destroy(gameObject);
        }
    }
}
