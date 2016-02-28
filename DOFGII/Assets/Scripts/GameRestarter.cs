using UnityEngine;
using System.Collections;

public class GameRestarter : MonoBehaviour
{
  	//Resets the Level Counter and Loads Main Game Loop
	  void Start ()
    {
        SceneBuffer.PlayerMoney = 0;
        SceneBuffer.PlayerPoints = 0;
        StartEndController.level = 0;
        Application.LoadLevel("Main");
    }
}
