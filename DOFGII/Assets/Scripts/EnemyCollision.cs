using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyCollision : MonoBehaviour
{

    public int attackDamage = 50;
    GameObject Player;
    PlayerHealth playerHealth;
    private bool playerInRange;
    

    void Start()
    {
    
    }
    void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = Player.GetComponent<PlayerHealth>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == Player.tag)
        {
            playerInRange = true;
            Attack();
        }
    }

    void Attack()
    {
        if (playerHealth.CurrentHealth > 0)
        {
            playerHealth.TakeDamage(attackDamage);
            Destroy(this.gameObject);
        }
    }
}

