using UnityEngine;

public class RadioMusicController : MonoBehaviour
{
    public SpriteToggleOnClick toggleScript;
    public AudioSource musicSource; // Link to the AudioSource component
    public bool requiredState = true; // true for new sprite, false for original sprite

    public void InvokeIfStateMatches()
    {
        if (toggleScript != null && toggleScript.IsNew == requiredState)
        {
            // turn on the music if the required sprite is active
            if (musicSource != null && !musicSource.isPlaying)
                musicSource.Play();
        }
        else
        {
            // turn off the music if the required sprite is not active
            if (musicSource != null && musicSource.isPlaying)
                musicSource.Stop();
        }
    }
}