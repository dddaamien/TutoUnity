using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour 
{
    //Prefab du projectile
    public Transform shotPrefab;
    //cadence de tir
    public float shootRate = 0.25f;

    private float shootCooldown;

	// Use this for initialization
	void Start () 
    {
        shootCooldown = 0f;
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if(shootCooldown>0)
        {
            shootCooldown -= Time.deltaTime;
        }
	}

    public void Attack(bool isEnemy)
    {
        if(CanAttack)
        {
            shootCooldown = shootRate;
            //Création du projectile
            var shotTransform = Instantiate(shotPrefab) as Transform;
            //Position
            shotTransform.position = transform.position;
            //Propriétés du scripte
            ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();
            if(shot!=null)
            {
                shot.isEnemyShot = isEnemy;
            }
            MoveScript move = shotTransform.gameObject.GetComponent<MoveScript>();
            if(move!=null)
            {
                move.direction = this.transform.right;
            }
        }
    }

    public bool CanAttack
    {
        get
        {
            return shootCooldown<=0f;
        }
    }
}
