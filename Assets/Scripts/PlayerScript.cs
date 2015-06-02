using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour 
{
	//puissance du saut
    public float jumpHeight;
    public bool isJumping = false;
    public int score = 0; //à déplacer dans un script parent et mettre en privé
    private Animator animation;

	// Use this for initialization
	void Start () 
	{
        animation = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKey("space") || Input.GetKey("up"))
        {
            if (isJumping == false)
            {
                SoundEffectsHelper.Instance.MakeJumpSound(); // Jouer le bruit du saut
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpHeight);
                isJumping = true;                
            }
        }
        animation.SetBool("isJumping", isJumping);
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isJumping = false;
        }
    }

	//Suppression de l'objet si collision
    void OnTriggerEnter2D(Collider2D collider)
    {
        FoodScript food = collider.gameObject.GetComponent<FoodScript>(); // On récupère les attributs de la nourriture
        if (food != null)
        {
            if(food.isWall == false) //nourriture
            {
                score += food.goodness; //Màj du score
                if (food.goodness > 0) SoundEffectsHelper.Instance.MakeGoodSound(); //Jouer ce son si c'est un bon aliment
                else SoundEffectsHelper.Instance.MakeBadSound();
                Destroy(collider.gameObject);
            }
            else //mur
            {                
                Destroy(gameObject);
                SpecialEffectsHelper.Instance.Explosion(transform.position); // Effet visuel
                SoundEffectsHelper.Instance.MakeDeathSound(); // Effet sonore
            }
        }
        if(score < 0)
        {
            Destroy(gameObject);
            SpecialEffectsHelper.Instance.Explosion(transform.position);
            SoundEffectsHelper.Instance.MakeDeathSound(); // Effet sonore
        }
    }

    void OnDestroy()
    {
        transform.parent.gameObject.AddComponent<GameOverScript>();
    }
}
