using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour 
{
	//puissance du saut
    public float jumpHeight;
    public bool isJumping = false;
    public int score = 0;
    private Animator animation;

	// Use this for initialization
	void Start () 
	{
        animation = this.GetComponent<Animator>();
        Time.timeScale = 1f; // On remet le jeu à sa vitesse normale
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
        if (Input.GetKeyDown("escape")) //Pause
        {
            if (Time.timeScale == 0f) Time.timeScale = 1f;
            else Time.timeScale = 0f;
        }
        if (Input.GetKeyDown("f")) Time.timeScale = 2; // Mode rapide
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
                FinPartie();
            }
        }
        if(score < 0)
        {
            FinPartie();
        }
    }

    void FinPartie()
    {
        SoundEffectsHelper.Instance.MakeDeathSound(); // Effet sonore
//      SpecialEffectsHelper.Instance.Explosion(transform.position); // Effet visuel
        transform.parent.gameObject.AddComponent<GameOverScript>();
        Time.timeScale = 0f; // Met le jeu en pause
        Destroy(gameObject);
    }
}
