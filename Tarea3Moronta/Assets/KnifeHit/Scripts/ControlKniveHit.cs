using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlKniveHit : MonoBehaviour
{
    GameObject knife;
    public enum Estate
    {
        Start,
        Playing,
        End
    }
    public static Estate kniveState;
    public static int knives;
    // Start is called before the first frame update
    void Start()
    {
        knives = 50;
        kniveState = Estate.Playing;
    }

    // Update is called once per frame
    void Update()
    {
        switch (kniveState)
        {
            case Estate.Playing:
                if (Input.GetKeyDown(KeyCode.Space) && knives > 0)
                {
                    knife = GameObject.FindGameObjectWithTag("Knife");
                    knife.GetComponent<Shoot>().isShooting = true;
                    knives--;
                } 
                break;
            case Estate.End:

                break;
        }
    }
}
