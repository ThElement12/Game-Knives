using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlKniveHit : MonoBehaviour
{
    GameObject knife;
    public GameObject Target, newKnife;
    public TextMesh PointTxt;
    public enum Estate
    {
        Start,
        Playing,
        End
    }
    public static bool LastHit;
    public static int points;
    public static Estate kniveState;
    public static int knives;
    // Start is called before the first frame update
    void Start()
    {
        points = 0;
        knives = 5;
        LastHit = false;
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

                if (knives == 0 && LastHit)
                {
                    Destroy(GameObject.FindGameObjectWithTag("Target"));
                    Instantiate(Target);
                    Instantiate(newKnife);
                    knives = 5;
                    LastHit = false;
                }
                PointTxt.text = "Puntos: " + points.ToString();
                break;
            case Estate.End:
                SceneManager.LoadScene("EndKnifeHit");
                break;
        }
    }
}
