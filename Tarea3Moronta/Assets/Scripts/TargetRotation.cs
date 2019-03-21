using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetRotation : MonoBehaviour
{
    Vector3 Velocidad = new Vector3(0, 100);
    int direction;
    // Start is called before the first frame update
    void Start()
    {
        direction = Random.Range(0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        direction = Random.Range(0,1);
        switch (direction)
        {
            case 0:
                gameObject.transform.Rotate(Vector3.forward * Velocidad.y * Time.deltaTime);
                break;
            case 1:
                gameObject.transform.Rotate(Vector3.forward * -Velocidad.y * Time.deltaTime);
                break;
            default:
                gameObject.transform.Rotate(Vector3.forward * Velocidad.y * Time.deltaTime);
                break;
        }
        
    }
}
