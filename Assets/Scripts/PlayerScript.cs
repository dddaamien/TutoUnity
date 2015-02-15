﻿using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour 
{
	//vitesse de déplacement
	public Vector2 speed = new Vector2(50,50);

	//stockage du mouvement
	private Vector2 movement;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		//entrée utilisateur
		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");

		movement = new Vector2 (speed.x * inputX,
		                     speed.y * inputY);

        bool shoot = Input.GetButton("Fire1");
        shoot |= Input.GetButton("Fire2");
        if(shoot)
        {
            WeaponScript weapon = GetComponent<WeaponScript>();
            if(weapon!=null)
            {
                //si ce n'est pas un ennemi
                weapon.Attack(false);
            }
        }
	}

	void FixedUpdate()
	{
		rigidbody2D.velocity = movement;
	}
}
