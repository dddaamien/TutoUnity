using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour 
{
    void OnGUI()
    {
        if(GUI.Button(new Rect(Screen.width/2, Screen.height/2,84,60),"Jouer :-)"))
        {
            Application.LoadLevel("Stage1");
        }
        if (GUI.Button(new Rect(Screen.width-80, 10, 70, 25), "Quitter :-("))
        {
            Application.Quit();
        }
    }

}
