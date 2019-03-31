using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoParallax : MonoBehaviour
{
    Vector3 Velocidad;
    // Start is called before the first frame update
    void Start()
    {
        Velocidad = new Vector3(transform.localScale.x, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Velocidad * Time.deltaTime);
        if (transform.position.x >= 14)
            Destroy(gameObject);
        
    }
}
