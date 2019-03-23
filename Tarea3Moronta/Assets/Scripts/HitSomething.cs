using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSomething : MonoBehaviour
{
    public GameObject Knive;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (gameObject.tag == "Target")
        {
            if (other.gameObject.tag == "Knife")
            {
                other.gameObject.GetComponent<Shoot>().isShooting = false;
                other.gameObject.tag = "KnifeHit";
                other.gameObject.transform.parent = gameObject.transform;
                ControlKniveHit.points++;
                if (ControlKniveHit.knives > 0)
                {
                    Instantiate(Knive);
                }
                else if (ControlKniveHit.knives == 0)
                {
                    ControlKniveHit.LastHit = true;
                }
            }
        }

        else if (gameObject.tag == "KnifeHit")
        {
            if(other.gameObject.tag == "Knife")
            {
                
                GameObject.FindGameObjectWithTag("Target").GetComponent<TargetRotation>().isDead = true;
                ControlKniveHit.kniveState = ControlKniveHit.Estate.End;
            }
        }
    }
}
