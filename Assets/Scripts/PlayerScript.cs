using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour 
{
	//puissance du saut
    public float jump = 50;
    public int score = 0; //à déplacer dans un script parent et mettre en privé

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKey("space") || Input.GetKey("up"))
        {
            rigidbody2D.AddForce(new Vector2(0,jump));
        }
	}

	//Suppression de l'objet si collision
    void OnTriggerEnter2D(Collider2D collider)
    {
        FoodScript food = collider.gameObject.GetComponent<FoodScript>(); // On récupère les attributs de la nourriture
        if (food != null)
        {
            score += food.goodness;
            Destroy(collider.gameObject);
            SpecialEffectsHelper.Instance.Explosion(collider.gameObject.transform.position);
        }
        else
        {
            Destroy(gameObject);
            SpecialEffectsHelper.Instance.Explosion(transform.position);
        }
        
    }

    void OnDestroy()
    {
        transform.parent.gameObject.AddComponent<GameOverScript>();
    }
}
