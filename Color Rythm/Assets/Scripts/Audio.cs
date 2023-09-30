using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioSource hitSFX;
    public AudioSource missSFX;
   

    public void Hit()
    {
        hitSFX.Play();
    }

    public void Miss()
    {
        missSFX.Play();
    }

}
