using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSomething : MonoBehaviour
{
    public GameObject Knive;
    


    private void OnTriggerStay(Collider other)
    {
        if (gameObject.tag == "Target")
        {
            if (other.gameObject.tag == "Knife")
            {
                if(MenuControl.playSound)
                 GetComponent<AudioSource>().Play();

                other.gameObject.GetComponent<Shoot>().isShooting = false;
                other.gameObject.tag = "KnifeHit";
                other.gameObject.transform.parent = gameObject.transform;
                ControlKniveHit.GastarAmmo();
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
                
                Destroy(GameObject.FindGameObjectWithTag("Target"));
                ControlKniveHit.kniveState = ControlKniveHit.Estate.End;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Zona Muerta")
        {
            ControlKniveHit.kniveState = ControlKniveHit.Estate.End;
        }
    }
}
