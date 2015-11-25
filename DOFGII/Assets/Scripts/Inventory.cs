using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class Inventory : MonoBehaviour {

    public  Weapon[] weapons = new Weapon[3];

    public static Weapon CurrentWeapon;

    public Image SelectedImage;
    public Text WeaponName;
    public Text WeaponPreis;
    private int position = 0;
    private GameObject player;
    private PlayerController pc;
    private int playerMoney;
    private int playerPoints;

    // Use this for initialization
    void Start()
    {
       
    }

    void Awake()
    {
        playerMoney = SceneBuffer.PlayerMoney;
        playerPoints = SceneBuffer.PlayerPoints;
    }
   
    //Update is called once per frame
    void Update()
    {
    }

    public void BuyWeapon()
    {
        int weaponPrice = Convert.ToInt32(weapons[position].Price);
        if (playerMoney >= weaponPrice)
        {
            CurrentWeapon = weapons[position];
            playerMoney -= weaponPrice;
            BackToMiniGame();
        }
        else
        {
            if (UnityEditor.EditorUtility.DisplayDialog("Weapon Shop", "Not enough money!!!", "OK"))
            {
            }
            
        }
    }

    public void RightDirection()
    {
        if (position < weapons.Length - 1)
        {
            position++;
            
            WeaponName.text = weapons[position].Name;
            WeaponPreis.text = weapons[position].Price;
            SelectedImage.sprite = weapons[position].WeaponSprite;
        }

    }

    public void LeftDirection()
    {
        if (position > 0)
        {
            position--;
            SelectedImage.sprite = weapons[position].WeaponSprite;
            WeaponName.text = weapons[position].Name;
            WeaponPreis.text = weapons[position].Price;

        }
    }
    public void BackToMiniGame()
    {
        if (CurrentWeapon == null)
        {
            CurrentWeapon = weapons[0];
        }
        SceneBuffer.PlayerMoney = playerMoney;
        SceneBuffer.PlayerPoints = playerPoints;
        Application.LoadLevel("Main");
    }

}
