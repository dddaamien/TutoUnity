using UnityEngine;
using System.Collections;

public class GameOverScript : MonoBehaviour 
{
    const int buttonH = 30;
    const int buttonW = 100;

    void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width / 2 - buttonW * 2, Screen.height / 2 - buttonH / 2, buttonW, buttonH), "Réessayer..."))
        {
            Application.LoadLevel("Stage1");
        }

        if (GUI.Button(new Rect(Screen.width / 2 + buttonW, Screen.height / 2 - buttonH / 2, buttonW, buttonH), "Menu principal"))
        {
            Application.LoadLevel("Menu");
        }
    }
	
}
