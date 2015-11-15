using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyCollision : MonoBehaviour {

  public int attackDamage = 50;
  GameObject Player;
  PlayerHealth playerHealth;
  private bool playerInRange;
  private int counter;
  public Text Points;
  public GameObject BonusItem;

  void Start()
  {
    counter=0;
  }
  void Awake()
  {
   
    Player = GameObject.FindGameObjectWithTag("Player");
    playerHealth = Player.GetComponent<PlayerHealth>();
    //bonusItem = GameObject.FindGameObjectWithTag("BonusItem");  
  }
  void OnTriggerEnter(Collider other)
  {
    if (other.tag == Player.tag)
    {
      counter++;
      playerInRange = true;
    }
    else if (other.tag == "Bolt")
    {
      counter++;
      Destroy(other.gameObject);
      Destroy(gameObject);
    }
  }
  void Update()
  { 
    if (playerInRange)
    {
      playerInRange = false;
      Attack();
      Destroy(this.gameObject);
            spawnBonus();
    }
  }
  void Attack()
  {
    if (playerHealth.CurrentHealth > 0)
    {
      playerHealth.TakeDamage(attackDamage);
    }
  }
    void spawnBonus()
    {
        Instantiate(BonusItem, this.transform.position, Quaternion.identity);
    }
  void showPoints()
  {
        Points.text = "Points" + counter.ToString();
  }
}

