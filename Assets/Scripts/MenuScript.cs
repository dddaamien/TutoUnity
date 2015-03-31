using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour 
{
    void OnGUI()
    {
        if(GUI.Button(new Rect(Screen.width/2, Screen.height/2,84,60),"Start"))
        {
            Application.LoadLevel("Stage1");
        }
    }

}
