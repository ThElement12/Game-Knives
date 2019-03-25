using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorObstaculos : MonoBehaviour
{
    public GameObject obstaculo;
    float tiempoSpawn = 100;

    GameObject Obstaculo;

    // Start is called before the first frame update
    void Start()
    {
        if (ControlKniveHit.Dificultad == "Medio")
            tiempoSpawn = 100;
        else if (ControlKniveHit.Dificultad == "Dificil")
            tiempoSpawn = 50;


    }

    // Update is called once per frame
    void Update()
    {
        if(ControlKniveHit.Dificultad == "Medio" || ControlKniveHit.Dificultad == "Dificil")
        {
            if(tiempoSpawn <= 0)
            {
             tiempoSpawn = 100;
             Obstaculo = Instantiate(obstaculo, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + Random.Range(-2.107f,2.108f)), Quaternion.identity);
            }
            else
            {
             tiempoSpawn--;
            }
        }
        
    }
}
