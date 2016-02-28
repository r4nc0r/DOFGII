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
    private Weapon currentWeapon;

    public RectTransform ErrorMesage;

    /// <summary>
    /// Setze CurrentWeapon auf aktuelle verwendete Klasse.
    /// Lese Infos zu Währung und Punktestand aus
    /// </summary>
    void Awake()
    {
        Cursor.visible = true;
        playerMoney = SceneBuffer.PlayerMoney*factor;
        playerPoints = SceneBuffer.PlayerPoints;

        if (SceneBuffer.PlayerWeapon == null)
        {
            currentWeapon = weapons[1];
        }
        else
        {
            currentWeapon = SceneBuffer.PlayerWeapon;
        }
        
        PlayerCurrentWeaponImage.sprite = currentWeapon.WeaponSprite;
        PlayerMoney.text = "Money: " + playerMoney;
        PlayerPoints.text = "Points: " + playerPoints;

    }
   
    /// <summary>
    /// Prüft ob genügend Währung vorhanden um sich eine neue Waffe kaufen zukönnen
    /// </summary>
    public void BuyWeapon()
    {
        int weaponPrice = Convert.ToInt32(weapons[position].Price);
        if (playerMoney >= weaponPrice)
        {
            currentWeapon = weapons[position];
            playerMoney = (playerMoney - weaponPrice) / factor;
            BackToMiniGame();
        }
        else
        {
            ErrorMesage.gameObject.SetActive(true);
        }
    }

    /// <summary>
    /// Zeigt nächstes WaffenImage und dessen Infos (rechts klichen)
    /// </summary>
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

    /// <summary>
    /// Zeigt nächstes WaffenImage an und dessen Infos (links klicken)
    /// </summary>
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

    /// <summary>
    /// Zurück zur Hauptszene 
    /// </summary>
    public void BackToMiniGame()
    {
        if (currentWeapon == null)
        {
            currentWeapon = weapons[1];
        }
        SceneBuffer.PlayerMoney = playerMoney;
        SceneBuffer.PlayerPoints = playerPoints;
        SceneBuffer.PlayerWeapon = currentWeapon;
        Application.LoadLevel("Main");
    }

    /// <summary>
    /// Setzt WaffenInfos des nächsten WaffenImage
    /// </summary>
    private void ChangeWeapon()
    {
        SelectedImage.sprite = weapons[position].WeaponSprite;
        WeaponName.text = weapons[position].Name +": ";
        WeaponPreis.text = weapons[position].Price + " Coins";
    }

}
