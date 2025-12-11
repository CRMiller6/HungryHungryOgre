using UnityEngine;

public class BugButPitch : MonoBehaviour
{
    public AudioSource sfxSource;
    public AudioClip sound;

    
    public float minPitch = 0.95f;
    public float maxPitch = 1.05f;

    public void PlayButtonSound()
    {
        if (sfxSource == null || sound == null)
            return;

        // Random slight pitch variation
        sfxSource.pitch = Random.Range(minPitch, maxPitch);

        sfxSource.PlayOneShot(sound);
    }
}
