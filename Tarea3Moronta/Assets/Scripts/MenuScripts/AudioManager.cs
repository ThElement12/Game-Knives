using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource HoverSound, ClickSound, Fondo;
    public static AudioSource _Fondo;

    public static bool play = true;

    private void Awake()
    {
        _Fondo = Fondo;
    }

    public void PlayHoverSound()
    {
        if (play)
        {
            HoverSound.Play();
        }
       
    }

    public void PlayClickedSound()
    {
        if (play)
        {
            ClickSound.Play();
        }

        
    }
    public static void stopPlay(bool Play)
    {
        play = Play;
    }
}
