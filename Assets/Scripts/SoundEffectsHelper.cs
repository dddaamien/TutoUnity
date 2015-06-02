using UnityEngine;
using System.Collections;

public class SoundEffectsHelper : MonoBehaviour 
{
    public static SoundEffectsHelper Instance;

    public AudioClip goodSound;
    public AudioClip badSound;
    public AudioClip jumpSound;
    public AudioClip deathSound;

    void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError("Erreur du chargement audio");
        }
        Instance = this;
    }

    public void MakeGoodSound()
    {
        AudioSource.PlayClipAtPoint(goodSound, transform.position);
    }

    public void MakeBadSound()
    {
        AudioSource.PlayClipAtPoint(badSound, transform.position);
    }

    public void MakeJumpSound()
    {
        AudioSource.PlayClipAtPoint(jumpSound, transform.position);
    }

    public void MakeDeathSound()
    {
        AudioSource.PlayClipAtPoint(deathSound, transform.position);
    }

}
