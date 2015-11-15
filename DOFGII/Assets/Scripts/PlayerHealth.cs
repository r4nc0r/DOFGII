using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int StartingHealth = 100;
    public int CurrentHealth;
    public Slider HealthSlider;
    GameObject Player;

    void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        CurrentHealth = StartingHealth;
    }

    public void TakeDamage(int amount)
    {
        CurrentHealth -= amount;
        HealthSlider.value = CurrentHealth;

        if (CurrentHealth <= 0)
        {
            Player.SetActive(false);
        }

    }

}
