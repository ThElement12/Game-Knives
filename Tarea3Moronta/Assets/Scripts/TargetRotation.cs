using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetRotation : MonoBehaviour
{
    Vector3 VelocidadAngular = new Vector3(0, 100);
    Vector3 Velocidad = new Vector3(10, 0);
    int direction;
    int count = 30;
    public bool isDead = false;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        direction = Random.Range(-1, 2);
    }

    // Update is called once per frame
    void Update()
    {
        if(ControlKniveHit.Dificultad == "Facil")
        {
            if (count == 0)
            {
                direction = 1;
                count = 50;
            }
            else
               gameObject.transform.Rotate(Vector3.forward * VelocidadAngular.y * direction * Time.deltaTime);
               count--;
        }
        else if(ControlKniveHit.Dificultad == "Medio")
        {
            if (count == 0)
            {
                direction = Random.Range(-1, 2);
                count = 50;
            }
            else
                gameObject.transform.Rotate(Vector3.forward * VelocidadAngular.y * direction * Time.deltaTime);
                count--;

        }
        else if(ControlKniveHit.Dificultad == "Dificil")
        {
            if (count == 0)
            {
                direction = Random.Range(-1, 2);
                count = 50;
            }
            else

                gameObject.transform.parent.transform.Translate(Vector3.right * Velocidad.x * direction * Time.deltaTime);
                gameObject.transform.Rotate(Vector3.forward * VelocidadAngular.y * direction * Time.deltaTime);
                count--;


        }
        



    }
}
