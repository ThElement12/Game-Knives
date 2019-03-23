using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetRotation : MonoBehaviour
{
    Vector3 Velocidad = new Vector3(0, 100);
    int direction;
    int count = 30;
    public bool isDead = false;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        direction = Random.Range(-1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (count == 0)
        {
            direction = Random.Range(-1, 2);
            count = 50;
        }
        else
            count--;
        gameObject.transform.Rotate(Vector3.forward * Velocidad.y * direction * Time.deltaTime);

    }
}
