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
        Cursor.visible = true;
        playerMoney = SceneBuffer.PlayerMoney*factor;
        playerPoints = SceneBuffer.PlayerPoints;

        if (SceneBuffer.PlayerWeapon == null)
        {
            CurrentWeapon = weapons[1];
        }
        else
        {
            CurrentWeapon = SceneBuffer.PlayerWeapon;
        }
        
        PlayerCurrentWeaponImage.sprite = CurrentWeapon.WeaponSprite;
        PlayerMoney.text = "Money: " + playerMoney;
        PlayerPoints.text = "Points: " + playerPoints;

    }
   
    /// <summary>
    /// 
    /// </summary>
    public void BuyWeapon()
    {
        int weaponPrice = Convert.ToInt32(weapons[position].Price);
        if (playerMoney >= weaponPrice)
        {
            CurrentWeapon = weapons[position];
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
        else
        {
            position = 0;
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
        else
        {
            position = weapons.Length - 1;
            ChangeWeapon();
        }
    }
    public void BackToMiniGame()
    {
        if (CurrentWeapon == null)
        {
            CurrentWeapon = weapons[1];
        }
        SceneBuffer.PlayerMoney = playerMoney;
        SceneBuffer.PlayerPoints = playerPoints;
        SceneBuffer.PlayerWeapon = CurrentWeapon;
        Application.LoadLevel("Main");
    }

    private void ChangeWeapon()
    {
        SelectedImage.sprite = weapons[position].WeaponSprite;
        WeaponName.text = weapons[position].Name +": ";
        WeaponPreis.text = weapons[position].Price + " Coins";
    }

}
