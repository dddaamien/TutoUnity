using UnityEngine;
using System.Collections;

public class GameOverScript : MonoBehaviour 
{
    void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2, 80, 30), "Try again.."))
        {
            Application.LoadLevel("Stage1");
        }

        if (GUI.Button(new Rect(Screen.width / 3, Screen.height / 3, 80, 30), "Menu principal"))
        {
            Application.LoadLevel("Menu");
        }
    }
	
}
