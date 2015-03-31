using UnityEngine;
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

        var dist = (transform.position - Camera.main.transform.position).z;
        var leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).x;
        var rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist)).x;
        var topBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).y;
        var bottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, dist)).y;

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, leftBorder, rightBorder), Mathf.Clamp(transform.position.y, topBorder, bottomBorder), transform.position.z);

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
    void OnDestroy()
    {
        transform.parent.gameObject.AddComponent<GameOverScript>();
    }
}
