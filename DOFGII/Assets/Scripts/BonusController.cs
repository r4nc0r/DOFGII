using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BonusController : MonoBehaviour {

    private PlayerController playercontroller;
    private PlayerHealth playerhealth;
    public GameObject BonusItem;
    private int pointCounter = 0;
    public Text PointText;
    private int moneyCount = 0;
    public Text MoneyText;

    public void Start()
    {
        playercontroller = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        playerhealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();

        pointCounter = playercontroller.PlayerPoints;
        moneyCount = playercontroller.PlayerMoney;
        MoneyText.text = moneyCount.ToString();
        PointText.text = pointCounter.ToString();
    }
    //public int Money { get { return moneyCount; } }
    public void spawnBonus(Vector3 spawnPosition)
    {
        if ((int)Random.Range(0, 100) % 2 == 0)
        {
            Instantiate(BonusItem, spawnPosition + new Vector3(0, 1, 0), Quaternion.identity);
        }
    }
    public void showPoints()
    {
        pointCounter++;
        PointText.text = pointCounter.ToString();
        playercontroller.PlayerPoints = pointCounter;
    }
    public void showMoney()
    {
        moneyCount++;
        MoneyText.text = moneyCount.ToString();
        playercontroller.PlayerMoney = moneyCount;
    }
    public void addHealth(int healing)
    {
        playerhealth.GetHealing(500);
    }
}
