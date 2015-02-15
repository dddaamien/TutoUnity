using UnityEngine;
using System.Collections;

public class ShotScript : MonoBehaviour 
{
    //Points de dégat infligé par le projectile
    public int damage = 10;
    //provenance du tir
    public bool isEnemyShot = false;

	// Use this for initialization
	void Start () 
    {
	    //destruction du tir après 20sec
        Destroy(gameObject, 20);

	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

}
