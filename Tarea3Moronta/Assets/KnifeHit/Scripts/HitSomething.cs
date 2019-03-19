using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSomething : MonoBehaviour
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
        if (gameObject.tag == "Target")
        {
            if (other.gameObject.tag == "Knife")
            {
                other.gameObject.GetComponent<Shoot>().isShooting = false;
                other.gameObject.transform.parent = gameObject.transform;
            }
        }

        else if (gameObject.tag == "Knife")
        {
            if(other.gameObject.tag == "Knife")
            {
                Destroy(GameObject.FindGameObjectWithTag("Target"));
            }
        }
    }
}
