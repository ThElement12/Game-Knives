using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBola : MonoBehaviour
{

    //Asignando a la bola una velocidad constante de bajada
    Vector3 Velocidad = Vector3.zero;
    Vector3 posicion = Vector3.zero;

    //float tiempoSalto;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        posicion.x = Velocidad.x * Time.deltaTime + Physics.gravity.x * (Mathf.Pow(Time.deltaTime, 2) / 2);
        posicion.y = Velocidad.y * Time.deltaTime + Physics.gravity.y * (Mathf.Pow(Time.deltaTime, 2) / 2);

        gameObject.transform.Translate(posicion);

        Velocidad += Physics.gravity * Time.deltaTime;

        if (Input.GetButtonDown("Fire1"))
        {
            posicion = Vector3.zero;
            Velocidad = new Vector3(0,7);
        }
    }
}
