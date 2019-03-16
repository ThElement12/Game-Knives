using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBola : MonoBehaviour
{

    //Asignando a la bola una velocidad constante de bajada
    Vector3 Velocidad = Vector3.zero;// = new Vector3 (0f,-10f);

    Vector3 Movimiento;
    //float tiempoSalto;
    bool salto = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Movimiento.y = Velocidad.y * Time.deltaTime + (Physics.gravity.y * Mathf.Pow(Time.deltaTime, 2) / 2);
        if (salto == true)
        {
            Velocidad.y = 50f;
            salto = false;
        }
        else 
        {
            Velocidad.y = -5f;
        }
        transform.Translate(Movimiento);
        
        if(Input.GetButtonDown("Fire1"))
        {
            Saltar();
        }
        
        //   Velocidad = Physics.gravity * Time.deltaTime;
    }

    void Saltar()
    {
        salto = true;
        //transform.GetComponent<Rigidbody>().AddForce(new Vector3(0, 1f, 0),ForceMode.Impulse);
    }

}
