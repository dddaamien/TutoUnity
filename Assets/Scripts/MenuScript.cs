using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour 
{
    public GUIStyle guiQuitter;
    public GUIStyle guiStart;
    void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width / 2 - 64, Screen.height / 2 - 64, 128, 64), "", guiStart))
        {
            Application.LoadLevel("Stage1");
        }
        if (GUI.Button(new Rect(Screen.width / 2 - 64, Screen.height / 2 + 32, 128, 64), "",guiQuitter))
        {
            Application.Quit();
        }
    }

}
