using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorObstaculos : MonoBehaviour
{
    public GameObject obstaculo;
    float tiempoSpawn = 5f;

    GameObject Obstaculo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(tiempoSpawn <= 0)
        {
            tiempoSpawn = 5;
            Obstaculo = Instantiate(obstaculo, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + Random.Range(-2.107f,2.108f)), Quaternion.identity);
        }
        else
        {
            tiempoSpawn--;
        }
    }
}
