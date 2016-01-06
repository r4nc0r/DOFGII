using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyCollision : MonoBehaviour
{

    public int attackDamage = 50;
    GameObject Player;
    PlayerHealth playerHealth;
    private bool playerInRange;
    public GameObject Explosion;
    

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
            Color color = new Color(this.GetComponentInChildren<Renderer>().material.GetColor("_Color").r, this.GetComponentInChildren<Renderer>().material.GetColor("_Color").g, this.GetComponentInChildren<Renderer>().material.GetColor("_Color").b, 0.5f);
            Destroy(this.gameObject);
            GameObject explosion = (GameObject)Instantiate(Explosion, this.transform.position + new Vector3(0, 1, 0), Quaternion.identity);
            explosion.GetComponent<ParticleSystem>().startColor = color;
        }
    }
}

