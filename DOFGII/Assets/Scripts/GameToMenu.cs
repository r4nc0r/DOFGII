using UnityEngine;
using System.Collections;

public class GameToMenu : MonoBehaviour {

	  //Reset Values and load MainMenu:
	  void Start ()
    {
        SceneBuffer.PlayerMoney = 0;
        SceneBuffer.PlayerPoints = 0;
        StartEndController.level = 0;
        Application.LoadLevel("MainMenu");
    } 
}
