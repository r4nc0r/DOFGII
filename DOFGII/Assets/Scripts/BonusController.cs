using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BonusController : MonoBehaviour {

    public GameObject BonusItem;
    private int counter = 0;
    public Text PointText;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void spawnBonus(Vector3 spawnPosition)
    {
        Instantiate(BonusItem, spawnPosition, Quaternion.identity);
    }
    public void showPoints()
    {
        counter++;
        PointText.text = "Points" + counter.ToString();
    }
}
