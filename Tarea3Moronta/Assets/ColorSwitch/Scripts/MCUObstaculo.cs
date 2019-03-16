using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCUObstaculo : MonoBehaviour
{
    Vector3 rotacion = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        rotacion = new Vector3(0, 0, Random.Range(1, 3));
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(rotacion);
    }
}
