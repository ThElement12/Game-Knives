using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlKnive : MonoBehaviour
{
    GameObject knife;
    public enum Estate
    {
        Start,
        Playing,
        End
    }
    public static Estate kniveState;
    // Start is called before the first frame update
    void Start()
    {
        kniveState = Estate.Playing;
    }

    // Update is called once per frame
    void Update()
    {
        switch (kniveState)
        {
            case Estate.Playing:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    knife = GameObject.FindGameObjectWithTag("Knife");
                    knife.GetComponent<Shoot>().isShooting = true;
                } 
                break;
        }
    }
}
