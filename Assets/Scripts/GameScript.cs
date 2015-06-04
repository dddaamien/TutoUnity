using UnityEngine;
using System.Collections;

public class GameScript : MonoBehaviour 
{
    public Transform wallPrefab;
    public float wallFrq = 6;
    public Transform[] foodPrefab;
    public float foodFrq = 2;

    private float wallTime = 0f;
    private float foodTime = 0;

    public int score = 0;

    void Start ()
    {
        wallTime = wallFrq;
        foodTime = foodFrq;
    }

	void Update ()
    {
        //Gestion de l'apparition des objets
        wallTime -= Time.deltaTime;
        foodTime -= Time.deltaTime;

        if(wallTime <= 0f)
        {
            wallTime = Random.Range(wallFrq * (1 - (score / 1000)), 2 * (wallFrq * (1 - (score / 1000)))); //Géneration du temps avant la création du prochain objet
            var wallTransforn = Instantiate(wallPrefab) as Transform;
            wallTransforn.position = new Vector3(Camera.main.transform.position.x + 15f, -2.2f, 0f);
        }
        else if(foodTime <= 0f)
        {
            foodTime = Random.Range(foodFrq,2*foodFrq);
            var foodTransforn = Instantiate(foodPrefab[(int)Random.Range(0,foodPrefab.Length)]) as Transform;
            foodTransforn.position = new Vector3(Camera.main.transform.position.x + 15f, -2.3f, 0f);
        }
        //Copie du score
        if(GetComponentInChildren<PlayerScript>() != null) score=GetComponentInChildren<PlayerScript>().score;
    }
    
    void OnGUI ()
    {
        //Affichage du score
        GUI.TextArea(new Rect(10,Screen.height-30,130,20), "Score: " + score.ToString());
    }
}

