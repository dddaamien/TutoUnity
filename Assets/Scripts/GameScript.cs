﻿using UnityEngine;
using System.Collections;

public class GameScript : MonoBehaviour 
{
    public Transform wallPrefab;
    public float wallFrq = 6;
    public Transform[] foodPrefab;
    public float foodFrq = 2;

    private float wallCooldown = 0f;
    private float foodCooldown = 0;

    public int score = 0;

    void Start ()
    {
        wallCooldown = wallFrq;
        foodCooldown = foodFrq;
    }

	void Update ()
    {
        //Gestion de l'apparition des objets
        wallCooldown -= Time.deltaTime;
        foodCooldown -= Time.deltaTime;

        if(wallCooldown <= 0f)
        {
            wallCooldown = Random.Range(wallFrq,2*wallFrq); //Géneration du temps avant la création du prochain objet
            var wallTransforn = Instantiate(wallPrefab) as Transform;
            wallTransforn.position = new Vector3(Camera.main.transform.position.x + 10f, -2.75f, 0f);
        }
        else if(foodCooldown <= 0f)
        {
            foodCooldown = Random.Range(foodFrq,2*foodFrq);
            var foodTransforn = Instantiate(foodPrefab[(int)Random.Range(0,foodPrefab.Length)]) as Transform;
            foodTransforn.position = new Vector3(Camera.main.transform.position.x + 10f, -2.75f, 0f);
        }
        //Copie du score
        score=GetComponentInChildren<PlayerScript>().score;
    }
    
    void OnGUI ()
    {
        //Affichage du score
        GUI.TextArea(new Rect(10,Screen.height-30,130,20), "Score: " + score.ToString());
    }
}

