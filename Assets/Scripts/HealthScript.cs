using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour 
{
    //Points de vie
    public int hp = 100;
    //ennemi ou joueur
    public bool isEnemy = true;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        ShotScript shot = collider.gameObject.GetComponent<ShotScript>();
        if (shot != null)
        {
            //si tir adverse, comptabiliser les dommages + supprimer projectile
            if (shot.isEnemyShot != isEnemy)
            {
                hp -= shot.damage;
                Destroy(shot.gameObject);
                if (hp <= 0) Destroy(gameObject);
            }
        }
    }
}
