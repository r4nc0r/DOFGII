using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    public  Weapon[] weapons = new Weapon[3];

    public static Weapon CurrentWeapon;

    public Image SelectedImage;
    public Text WeaponName;
    public Text WeaponPreis;
    private int position = 0;
    


    // Use this for initialization
    void Start()
    {
       
    }

    void Awake()
    {
     
    }

   
    //Update is called once per frame
    void Update()
    {
    }

    public void BuyWeapon()
    {
        CurrentWeapon = weapons[position];
        BackToMiniGame();
    }

    public void RightDirection()
    {
        if (position < weapons.Length - 1)
        {
            position++;
            
            WeaponName.text = weapons[position].Name;
            WeaponPreis.text = weapons[position].Preis;
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
            WeaponPreis.text = weapons[position].Preis;

        }
    }
    public void BackToMiniGame()
    {
        if (CurrentWeapon == null)
        {
            CurrentWeapon = weapons[0];
        }
        GameController.SetCounter(-5);
        Application.LoadLevel("Main");
    }

}
