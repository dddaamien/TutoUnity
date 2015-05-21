using UnityEngine;
using System.Collections;

public class FoodScript : MonoBehaviour 
{

    //Valeur nutritive de l'aliment (+bon / -mauvais)
    public int goodness = 10;


    // Use this for initialization
    void Start()
    {
        //destruction de l'objet après 10sec
        Destroy(gameObject, 10);

    }
}
