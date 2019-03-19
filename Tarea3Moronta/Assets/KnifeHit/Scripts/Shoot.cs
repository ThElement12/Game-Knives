using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public bool isShooting = false;
    Vector3 Velocidad = Vector3.zero;
    Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
        position = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (!isShooting) 
        {
            Velocidad.y = 3f;
            position.y += Velocidad.y * Time.deltaTime;
            gameObject.transform.Translate(position);
        }

    }
}
