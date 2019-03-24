using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource HoverSound, ClickSound, Fondo;
    public static AudioSource _Fondo;

    private void Awake()
    {
        _Fondo = Fondo;
    }

    public void PlayHoverSound()
    {
        HoverSound.Play();
    }

    public void PlayClickedSound()
    {
        ClickSound.Play();
    }
  
}
