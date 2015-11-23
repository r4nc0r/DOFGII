using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BonusController : MonoBehaviour {

    private PlayerController playercontroller;
    public GameObject BonusItem;
    private int pointCounter = 0;
    public Text PointText;
    private int moneyCount = 0;
    public Text MoneyText;

    public void Start()
    {
        playercontroller = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
    //public int Money { get { return moneyCount; } }
    public void spawnBonus(Vector3 spawnPosition)
    {
        Instantiate(BonusItem, spawnPosition+ new Vector3(0,1,0), Quaternion.identity);
    }
    public void showPoints()
    {
        pointCounter++;
        PointText.text = "Points " + pointCounter.ToString();
        playercontroller.PlayerPoints = pointCounter;
    }
    public void showMoney()
    {
        moneyCount++;
        MoneyText.text = "Money " + moneyCount.ToString();
        playercontroller.PlayerMoney = moneyCount;
    }
}
