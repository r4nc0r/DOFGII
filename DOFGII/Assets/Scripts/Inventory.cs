using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    public  Weapon[] weapons = new Weapon[3];

    public static Weapon aktuelleWeapon;

    public Image SelectedImage;
    public Text WeaponName;
    public Text WeaponPreis;
    private int position = 0;


    // Use this for initialization
    void Start()
    {
        //aktuelleWeapon = weapons[0];
        //WeaponPreis.text = aktuelleWeapon.Preis;
        //WeaponName.text = aktuelleWeapon.Name;
    }

    void Awake()
    {
        //aktuelleWeapon = weapons[0];
        //WeaponPreis.text = aktuelleWeapon.Preis;
        //WeaponName.text = aktuelleWeapon.Name;
    }

   
    //Update is called once per frame
    void Update()
    {
    }

    public void BuyWeapon()
    {
        aktuelleWeapon = weapons[position];
        Application.LoadLevel("Main");
    }

    public void RightDirection()
    {
        if (position < weapons.Length - 1)
        {
            position++;
            
            WeaponName.text = weapons[position].Name;
            WeaponPreis.text = weapons[position].Preis;
            SelectedImage.sprite = weapons[position].sprite;
        }

    }

    public void LeftDirection()
    {
        if (position > 0)
        {
            position--;
            SelectedImage.sprite = weapons[position].sprite;
            WeaponName.text = weapons[position].Name;
            WeaponPreis.text = weapons[position].Preis;

        }
    }
    public void BackToMiniGame()
    {
        Application.LoadLevel("Main");
    }

}
