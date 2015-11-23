﻿using UnityEngine;
using System.Collections;

public class BonusItemHandler : MonoBehaviour
{
    public GameObject[] BonusItems;
    GameObject player;
    int bonusItemIndex = 0;
    Vector3 posAdd = new Vector3(0, 0, 0);
    Quaternion rotation = new Quaternion(0, 0, 0, 0);
    private int randomVar;
    private int badCount;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }
    /// <summary>
    /// When BonusItems is destroyed, this function spawns a random
    /// item such as coins, enemys or something like that
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bolt" || other.tag == player.tag)
        {
            //Bolt have to be destroyed otherwise bolt collider destroys the spawned 
            //enemy objects
            if (other.tag == "Bolt")
                Destroy(other);

            badCount = ((int)Random.Range(1, 4));
            randomVar = Random.Range(0, 101);
            rotation = transform.rotation;
            Destroy(gameObject);
            if (randomVar >= 0 && randomVar <= 25)
            {
                //Enemy 1
                bonusItemIndex = 0;
                rotation = Quaternion.AngleAxis(180, new Vector3(1, 0, 0));
            }
            else if(randomVar >= 25 && randomVar <= 50)
            {
                //Enemy 2
                bonusItemIndex = 1;
            }
            else if (randomVar >= 50  && randomVar <= 75)
            {
                //Enemy 3
                bonusItemIndex = 2;
            }
            else if (randomVar >= 75 && randomVar <= 100)
            {
                //Coin
                badCount = 1;
                bonusItemIndex = 3;
            }

            for (int i = 0; i < badCount; i++)
            {
                posAdd.x += i;
                posAdd.z += i;
                Instantiate(BonusItems[bonusItemIndex], transform.position + posAdd, rotation);
            }
            
        }
    }
}
