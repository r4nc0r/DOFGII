using UnityEngine;
using System.Collections;

public class CoinScript : MonoBehaviour
{
    GameObject Player;
    //PlayerController playerController;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        //playerController = Player.GetComponent<PlayerController>();

    }
    void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        //playerController = Player.GetComponent<PlayerController>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == Player.tag)
        {
            //playerController.Money++;
            //playerController.SetMoneyText();
            Destroy(gameObject);
        }
    }
}