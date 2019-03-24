using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endScreen : MonoBehaviour
{
    public TextMesh puntaje;
    // Start is called before the first frame update
    void Start()
    {
        puntaje.text = "Puntaje: " + ControlKniveHit.points.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
