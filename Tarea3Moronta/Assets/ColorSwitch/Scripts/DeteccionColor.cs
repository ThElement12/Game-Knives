using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeteccionColor : MonoBehaviour
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

        Material colorObjeto = other.gameObject.GetComponent<Renderer>().material;
        Material colorCuerpo = transform.gameObject.GetComponent<Renderer>().material;

        if(colorObjeto.color == colorCuerpo.color)
        {
            return;
        }else
        {
            Destroy(other.gameObject);
        }

    }

}
