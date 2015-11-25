using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class Inventory : MonoBehaviour {

    public  Weapon[] weapons = new Weapon[3];

    public Image SelectedImage;
    public Image PlayerCurrentWeaponImage;
    public Text WeaponName;
    public Text WeaponPreis;
    public Text PlayerMoney;
    public Text PlayerPoints;

    private int position = 0;
    private int playerMoney;
    private int playerPoints;
    private const int factor = 2;
    private Weapon CurrentWeapon;

    void Awake()
    {
        playerMoney = SceneBuffer.PlayerMoney*factor;
        playerPoints = SceneBuffer.PlayerPoints;

        if (SceneBuffer.PlayerWeapon == null)
        {
            CurrentWeapon = weapons[0];
        }
        else
        {
            CurrentWeapon = SceneBuffer.PlayerWeapon;
        }
        
        PlayerCurrentWeaponImage.sprite = CurrentWeapon.WeaponSprite;
        PlayerMoney.text = "Money: " + playerMoney;
        PlayerPoints.text = "Points: " + playerPoints;

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

            playerMoney = (playerMoney - weaponPrice) / factor;
            BackToMiniGame();
        }
        else
        {
            UnityEditor.EditorUtility.DisplayDialog("Weapon Shop", "Not enough money!!!", "OK");
        }
    }

    public void RightDirection()
    {
        if (position < weapons.Length - 1)
        {
            position++;
            ChangeWeapon();
        }
    }

    public void LeftDirection()
    {
        if (position > 0)
        {
            position--;
            ChangeWeapon();
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
        SceneBuffer.PlayerWeapon = CurrentWeapon;
        Application.LoadLevel("Main");
    }

    private void ChangeWeapon()
    {
        SelectedImage.sprite = weapons[position].WeaponSprite;
        WeaponName.text = "Name: " + weapons[position].Name;
        WeaponPreis.text = "Price: " + weapons[position].Price + " Coins";
    }

}
