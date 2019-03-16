using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    Vector3 velocidad = Vector3.zero;
    Vector3 aceleracion = Physics.gravity;
    Vector3 newPosition = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        newPosition.y = (velocidad.y * Time.deltaTime) + (aceleracion.y * Mathf.Pow(Time.deltaTime, 2)) / 2;
    }
}
