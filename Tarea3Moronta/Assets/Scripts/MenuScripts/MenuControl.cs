using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuControl : MonoBehaviour
{
    const float SCALEFACTOR = 1.2f;
    AudioManager _audioManager;
    static GameObject menuItems;
    static GameObject Sonido, Facil, Medio, Dificil;

    static bool playSound = true;

    private void Awake()
    {
      _audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        menuItems = GameObject.Find("MenuItems");
        Sonido = GameObject.Find("Sonido");
        Facil = GameObject.Find("Facil");
        Medio = GameObject.Find("Medio");
        Dificil = GameObject.Find("Dificil");
     
        
    }
  
    private void Update()
    {
        if(SceneManager.GetActiveScene().name == "KnifeHitMenu")
        {
            if (Sonido.GetComponent<Toggle>().isOn)
               playSound = true;
            else
               playSound = false;
        }
        

        if (!playSound)
        {
            AudioManager._Fondo.Stop();
        }
        else if (!AudioManager._Fondo.isPlaying)
        {
            AudioManager._Fondo.Play();
        }
        

    }
    private void OnMouseEnter()
    {
        if(playSound)
            _audioManager.PlayHoverSound();

        gameObject.transform.localScale *= SCALEFACTOR;
    }

    private void OnMouseExit()
    {
        //_audioManager.PlayExitSound();
        gameObject.transform.localScale /= SCALEFACTOR;
    }

    private void OnMouseUp()
    {
        if(playSound)
           _audioManager.PlayClickedSound();

        switch (gameObject.name)
        {
            
            case "Play":
                SeleccionDificultad();
                GameObject.Find("Main Camera").GetComponent<CanvasController>().showCanvas(true);
                SceneManager.LoadScene("KnifeHit");

                
                break;
            case "Options":
                IniciarOpciones(false);
                GameObject.Find("Main Camera").GetComponent<CanvasController>().showCanvas();
                gameObject.transform.localScale /= SCALEFACTOR;
                break;
            case "Quit":
                Application.Quit(0);
                break;
            case "Main_Menu":
                SceneManager.LoadScene("KnifeHitMenu");
                break;
        }
    }
    public static void IniciarOpciones(bool active)
    {
        menuItems.SetActive(active);
    }
    public void SeleccionDificultad()
    {
        if (Facil.GetComponent<Toggle>().isOn)
            ControlKniveHit.Dificultad = "Facil";

        else if (Medio.GetComponent<Toggle>().isOn)
            ControlKniveHit.Dificultad = "Medio";
        else
            ControlKniveHit.Dificultad = "Dificil";
    }
}
