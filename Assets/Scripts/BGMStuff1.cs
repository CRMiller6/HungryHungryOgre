using UnityEngine;
using TMPro;
public class BGMStuff : MonoBehaviour
{
    public AudioSource bgmSource;

    public AudioClip trackA;
    public AudioClip trackB;

    private float timeA = 108f;
    private float timeB = 62f;

    private float timer;
    private bool playingA = true;

    void Start()
    {
        // start track A
        PlayTrack(trackA);
        timer = timeA;
    }

    void Update()
    {
        AutoSwitch();
    }

    void AutoSwitch()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            if (playingA)
            {
                PlayTrack(trackB);
                timer = timeB;
            }
            else
            {
                PlayTrack(trackA);
                timer = timeA;
            }

            playingA = !playingA;
        }
    }

    void PlayTrack(AudioClip clip)
    {
        if (clip == null) return;

        bgmSource.clip = clip;
        bgmSource.Play();
    }

    public void SetVolume(float value)
{
    if (bgmSource != null)
        bgmSource.volume = value;
}
public GameObject optionsMenu;

public void ToggleOptionsMenu()
{
    optionsMenu.SetActive(!optionsMenu.activeSelf);
}
public void CloseOptionsMenu()
{
    optionsMenu.SetActive(false);
}
}
