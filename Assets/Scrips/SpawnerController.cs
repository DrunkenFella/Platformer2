using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [SerializeField]
    GameObject laser;
    [SerializeField]
    GameObject wall;
    [SerializeField]
    GameObject coin;
    [SerializeField]
    float timer = 0;

    [SerializeField]
    float timerBetweenSpawn = 1f;
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > timerBetweenSpawn)
        {
            int randomNumber = Random.Range(1, 100);
            timer = 0;
            if (randomNumber <= 40)
            {
                Instantiate(laser);
            }
            else if (randomNumber <= 80 && randomNumber >= 41)
            {
                Instantiate(wall);
            }
            else
            {
                Instantiate(coin);
            }

        }
        
    }
}
