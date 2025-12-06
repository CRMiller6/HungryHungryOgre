using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.Timeline;
using UnityEngine.UI; // For the standard UI Dropdown
                      // using TMPro; // If using TextMeshPro Dropdown

public class BGMSuff : MonoBehaviour
    {
        public AudioSource bgmscource;
        public TMP_Dropdown dropdown; // Assign this in the Inspector
        public AudioClip trackA;
        public AudioClip trackB;
        void Start()
        {
            dropdown.onValueChanged.AddListener(OnDropdownChanged);
            OnDropdownChanged(dropdown.value);

            
        }

        void OnDropdownChanged(int index)
    {
        switch (index)
        { 
            case 0: //TrackA
                PlayTrack(trackA);
                break;
                
            case 1: //TrackB
                PlayTrack(trackB);
                break;
                
            case 2: //no bgm
                bgmscource.Stop();
                break;
        }
    }
    void PlayTrack(AudioClip clip)
    {
        if (clip == null);
        bgmscource.clip = clip;
        bgmscource.Play();
    }

    }