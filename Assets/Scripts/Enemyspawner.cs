using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyspawner : MonoBehaviour
{

    public bool spawnFlying;
    public bool spawnThrowing;
    public bool spawnWalking;

    public int flyingAmount;
    public int throwingAmount;
    public int walkingAmount;

    public GameObject Flying;
    public GameObject Throwing;
    public GameObject Walking;


    private void Update()
    {
        if (spawnFlying)
        {
            spawnFlying = false;
            flyingAmount++;
            Instantiate(Flying, new Vector3(0, 0, 0), Quaternion.identity);
        }

        if (spawnThrowing)
        {
            spawnThrowing = false;
            throwingAmount++;
            Instantiate(Throwing, new Vector3(0, 0, 0), Quaternion.identity);
        }

        if (spawnWalking)
        {
            spawnWalking = false;
            walkingAmount++;
            Instantiate(Walking, new Vector3(0, 0, 0), Quaternion.identity);
        }
    }
}
