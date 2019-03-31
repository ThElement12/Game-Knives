using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class SaveStats : MonoBehaviour
{
    static string rutaXMLFacil, rutaXMLMedio, rutaXMLDificil;
    public static PlayerStats CurrentGame;
    public static bool Guardado = false;
    public static bool Cargado = false;

    public static List<PlayerStats> playersStatsDificil = new List<PlayerStats>();
    public static List<PlayerStats> playersStatsMedio = new List<PlayerStats>();
    public static List<PlayerStats> playersStatsFacil = new List<PlayerStats>();

    


    // Start is called before the first frame update
    void Start()
    {
        CurrentGame = new PlayerStats();
        rutaXMLFacil = Application.persistentDataPath + "/HighScoresFacil.xml";
        rutaXMLMedio = Application.persistentDataPath + "/HighScoresMedio.xml";
        rutaXMLDificil = Application.persistentDataPath + "/HighScoresDificil.xml";
        CurrentGame.PlayerName = ControlKniveHit.playername;
        CurrentGame.Points = ControlKniveHit.points;
        CurrentGame.Dificultad = ControlKniveHit.Dificultad;
       
    }

    // Update is called once per frame
    void Update()
    {
        
        if (SceneManager.GetActiveScene().name == "EndKnifeHit" && !Guardado && CurrentGame.PlayerName != null)
        {
            CrearHighScore();
            SaveState();
            Guardado = true;
        }
        else if (SceneManager.GetActiveScene().name == "KnifeHitMenu" && !Cargado)
        {
            LoadState();
            Cargado = true;
        }
    }

    public static void SaveState()
    {
        DataContractSerializer dcSerializer = new DataContractSerializer(typeof(List<PlayerStats>));

        using (FileStream fstream = new FileStream(rutaXMLFacil, FileMode.Create))
        {
            dcSerializer.WriteObject(fstream, playersStatsFacil);
            
        }
        using (FileStream fstream = new FileStream(rutaXMLMedio, FileMode.Create))
        {
            dcSerializer.WriteObject(fstream, playersStatsMedio);

        }
        using (FileStream fstream = new FileStream(rutaXMLDificil, FileMode.Create))
        {
            dcSerializer.WriteObject(fstream, playersStatsDificil);

        }
        
    }

    public static void LoadState()
    {
        DataContractSerializer dcSerializer = new DataContractSerializer(typeof(List<PlayerStats>));
        Debug.Log("Cargo");

        try
        {
            using (FileStream fstream = new FileStream(rutaXMLFacil, FileMode.Open))
            {


                playersStatsFacil = (List<PlayerStats>)dcSerializer.ReadObject(fstream);

            }
            
        }
        catch (FileNotFoundException)
        {

        }
        try
        {
            using (FileStream fstream = new FileStream(rutaXMLMedio, FileMode.Open))
            {

                playersStatsMedio = (List<PlayerStats>)dcSerializer.ReadObject(fstream);

            }
        }
        catch (FileNotFoundException)
        {     
        }
        try
        {
            using (FileStream fstream = new FileStream(rutaXMLDificil, FileMode.Open))
            {

                playersStatsDificil = (List<PlayerStats>)dcSerializer.ReadObject(fstream);

            }
        }
        catch (FileNotFoundException)
        {   
        }
        
    }
    public void CrearHighScore()
    {
        switch (CurrentGame.Dificultad)
        {
            case "Facil":
                playersStatsFacil.Add(CurrentGame);
                playersStatsFacil = playersStatsFacil.OrderByDescending(o => o.Points).ToList();

                if (playersStatsFacil.Count > 10)
                {
                    playersStatsFacil.Remove(playersStatsFacil[playersStatsFacil.Count - 1]);
                }
               
                break;
            case "Medio":
                playersStatsMedio.Add(CurrentGame);
                playersStatsMedio = playersStatsMedio.OrderByDescending(o => o.Points).ToList();

                if (playersStatsMedio.Count > 10)
                {
                    playersStatsMedio.Remove(playersStatsMedio[playersStatsMedio.Count - 1]);
                }
                break;

            case "Dificil":
                playersStatsDificil.Add(CurrentGame);
                playersStatsDificil = playersStatsDificil.OrderByDescending(o => o.Points).ToList();
                if (playersStatsDificil.Count > 10)
                {
                    playersStatsDificil.Remove(playersStatsDificil[playersStatsDificil.Count - 1]);
                }

              break;
        }    
    }
}