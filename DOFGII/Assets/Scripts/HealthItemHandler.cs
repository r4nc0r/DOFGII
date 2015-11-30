using UnityEngine;
using System.Collections;

public class HealthItemHandler : MonoBehaviour
{

    BonusController bonusController;

    void Awake()
    {
        bonusController = GameObject.FindGameObjectWithTag("GameController").GetComponent<BonusController>();
    }
    void Update()
    {
        transform.Rotate(new Vector3(0, 45, 0) * Time.deltaTime);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            bonusController.addHealth(500);
            Destroy(gameObject);
        }
    }
}