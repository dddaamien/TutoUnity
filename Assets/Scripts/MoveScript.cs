﻿using UnityEngine;
using System.Collections;

public class MoveScript : MonoBehaviour 
{
	//vitesse de déplacement
	public Vector2 speed = new Vector2(5,5);
	//direction de l'objet
	public Vector2 direction = new Vector2 (-1, 0);

	//stockage du mouvement
	private Vector2 movement;
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		movement = new Vector2 (speed.x * direction.x,
		                        speed.y * direction.y);
	}
	
	void FixedUpdate()
	{
		rigidbody2D.velocity = movement;
	}
}
