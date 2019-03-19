using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public bool isShooting = false;
    Vector3 Velocidad = new Vector3(0, 1);
    Vector3 Aceleracion = new Vector3(0, 1);
    Vector3 position = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        position = gameObject.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (isShooting) 
        {
            //Velocidad += Aceleracion;
            position.y += Velocidad.y * Time.time;
            gameObject.transform.Translate(position * Time.deltaTime);
        }

    }
}
