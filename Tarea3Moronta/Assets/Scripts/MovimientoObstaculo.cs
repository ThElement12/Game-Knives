using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoObstaculo : MonoBehaviour
{
    Vector3 aceleracion = Vector3.zero;
    Vector3 velocidad = Vector3.zero;

    bool moviendose = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (moviendose)
        {
            aceleracion.x = Random.Range(0.1f, 0.2f);
            velocidad += aceleracion;
            gameObject.transform.Translate(velocidad * Time.deltaTime);
        }       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Knife")
        {

            other.gameObject.GetComponent<Shoot>().isShooting = false;
            moviendose = false;
            gameObject.GetComponent<Animator>().SetBool("IsDead", true);
            Invoke("destruir", 0.5f);
        }
        else if(other.gameObject.tag == "Salidas")
        {
            Destroy(gameObject);
        }
    }
    void destruir()
    {

        Destroy(GameObject.FindGameObjectWithTag("Target"));
        ControlKniveHit.kniveState = ControlKniveHit.Estate.End;
    }


}
