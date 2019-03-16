using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioColor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        Material colorObjeto = other.transform.GetComponent<Renderer>().material;
        int colorAleatorio = Random.Range(1, 4);
        switch(colorAleatorio)
        {
            case 1:
                colorObjeto.color = Color.red;
                break;

            case 2:
                colorObjeto.color = Color.blue;
                break;

            case 3:
                colorObjeto.color = Color.yellow;
                break;

            case 4:
                colorObjeto.color = Color.green;
                break;

        }
    }



}
