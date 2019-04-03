using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlKniveHit : MonoBehaviour
{
    GameObject knife;
    public GameObject Target, newKnife;
    public TextMesh PointTxt, NameTxt, powerUpTxt;
    //public TextMesh KnivesTxt;
    public GameObject _KnivePunto;
    public static string playername;
    public static string Dificultad;
    static GameObject[] KnivesPuntos = new GameObject[7];

    public enum Estate
    {
        Start,
        Playing,
        End
    }


    public static bool LastHit;
    public static int points;
    public static Estate kniveState;
    public static int knives, powercount;
    public static bool ispowerActive;
    GameObject actualTarget;
    GameObject knivepunto;
    // Start is called before the first frame update
    void Start()
    {
        //powerUpTxt.SetActive(false);
        points = 0;
        knives = 7;
        cargarKunaiPuntos();        
        LastHit = false;
        kniveState = Estate.Playing;
    }

    // Update is called once per frame
    void Update()
    {
        if (!MenuControl.playSound)
        {
            AudioManager._Fondo.Stop();
            
        }
        

        switch (kniveState)
        {
            case Estate.Playing:
                
                if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0)) && knives > 0 )
                {
                    knife = GameObject.FindGameObjectWithTag("Knife");
                    if(knife != null)
                     knife.GetComponent<Shoot>().isShooting = true;
                    if(powercount == 0)
                    {
                        HitSomething.pointPlus = 1;
                    }
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
                if (playername == "moronta")
                    NameTxt.text = playername + " sensei";
                else if (playername == "joseph" || playername == "ruben")
                    NameTxt.text = playername + " -sama";
                else
                    NameTxt.text = playername;

                if (ispowerActive)
                {
                    powerUpTxt.text = "Kunais x2: " + powercount.ToString();  
                }
                else if (!ispowerActive)
                {
                    powerUpTxt.text = "";
                }
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
        
        Instantiate(Target, GameObject.Find("Movimiento").transform);
       // Target.transform.SetParent();
        Instantiate(newKnife);
    }
    public static void GastarAmmo()
    {
        Destroy(KnivesPuntos[knives - 1].gameObject);
        if(powercount > 0)
        {
            powercount--;
        }
        else if(powercount == 0)
        {
            HitSomething.pointPlus = 1;
            ispowerActive = false;
        } 
        knives--;
    }
}
