using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BonusController : MonoBehaviour {

    private PlayerController playerController;
    private PlayerHealth playerHealth;
    public GameObject BonusItem;
    public Text PointText;
    private int moneyCount = 0;
    public Text MoneyText;

    static public int pointCounter { get; set; }

    public void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();

        pointCounter = playerController.PlayerPoints;
        moneyCount = playerController.PlayerMoney;
        MoneyText.text = moneyCount.ToString();
        PointText.text = pointCounter.ToString();

       
    }
    public void spawnBonus(Vector3 spawnPosition)
    {
        if ((int)Random.Range(0, 100) % 2 == 0)
        {
            Instantiate(BonusItem, spawnPosition + new Vector3(0, 1, 0), Quaternion.identity);
        }
    }
    public  void showPoints()
    {
        
        PointText.text = pointCounter.ToString() + "/" + EnemyController.lvlPoints[StartEndController.level-1].ToString();
        playerController.PlayerPoints = pointCounter;
    }
    public void showMoney()
    {
        moneyCount++;
        MoneyText.text = moneyCount.ToString();
        playerController.PlayerMoney = moneyCount;
    }
    public void addHealth(int healing)
    {
        playerHealth.GetHealing(500);
    }
}
