using UnityEngine;
using System.Collections;

public class GoldCoinHandler : MonoBehaviour {

    BonusController bonusController;

    void Awake()
    {
        bonusController = GameObject.FindGameObjectWithTag("BonusController").GetComponent<BonusController>();
    }
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 45) * Time.deltaTime);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            bonusController.showMoney();
            Destroy(gameObject);
        }
    }
}
