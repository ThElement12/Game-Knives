using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    const float SCALEFACTOR = 1.2f;
    AudioManager _audioManager;
    private void Awake()
    {
      _audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }
    private void OnMouseEnter()
    {
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
        _audioManager.PlayClickedSound();
        switch (gameObject.name)
        {
            case "Play":
                SceneManager.LoadScene("KnifeHit");
                break;
            case "Options":
                IniciarOpciones();
                GameObject.Find("Main Camera").GetComponent<CanvasController>().showCanvas();
                break;
            case "Quit":
                Application.Quit(0);
                break;
            case "Main_Menu":
                SceneManager.LoadScene("KnifeHitMenu");
                break;
        }
    }
    void IniciarOpciones()
    {
        foreach(GameObject item in GameObject.FindGameObjectsWithTag("Menu Item"))
        {
            item.SetActive(false);
        }
    }
}
