using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlKniveHit : MonoBehaviour
{
    GameObject knife;
    public GameObject Target, newKnife;
    public TextMesh PointTxt, NameTxt;
    //public TextMesh KnivesTxt;
    public GameObject _KnivePunto;
    public static string playername;

    GameObject[] KnivesPuntos = new GameObject[7];

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
    GameObject actualTarget;
    GameObject knivepunto;
    // Start is called before the first frame update
    void Start()
    {
        points = 0;
        knives = 7;
        cargarKunaiPuntos();        
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
                    Destroy(KnivesPuntos[knives-1].gameObject);
                    knives--;
                }

                if (knives == 0 && LastHit)
                {
                    cargarKunaiPuntos();
                    actualTarget = GameObject.FindGameObjectWithTag("Target");
                    actualTarget.GetComponent<TargetRotation>().isDead = true;
                    actualTarget.GetComponent<Animator>().SetBool("isDie", actualTarget.GetComponent<TargetRotation>().isDead);
                    destruirKunai();
                    Destroy(actualTarget, 1.5f);
                    Invoke("InstantiateNew", 1.5f);
                    knives = 7;
                    LastHit = false;
                }
                //KnivesTxt.text = "Cuchillos: " + knives.ToString();
                PointTxt.text = "Puntos: " + points.ToString();
                NameTxt.text = name;
                break;
            case Estate.End:
                SceneManager.LoadScene("EndKnifeHit");
                break;
        }
    }
    void cargarKunaiPuntos()
    {
        int i;
        float posx = -7.22f, posy = 3.88f;

        for(i = 0; i < KnivesPuntos.Length; i++)
        {
            knivepunto = Instantiate(_KnivePunto, new Vector3(posx, posy - i), Quaternion.Euler(new Vector3(0,0,90)));
            KnivesPuntos[i] = knivepunto;
            
        }
    }
    void destruirKunai()
    {
       
        foreach(Transform child in actualTarget.transform)
        {
            Destroy(child.gameObject);
        }
    }

    void InstantiateNew()
    {
        Instantiate(Target);
        Instantiate(newKnife);
    }
}
