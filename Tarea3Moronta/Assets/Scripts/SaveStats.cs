using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using UnityEngine;
using System.Linq;

public class SaveStats : MonoBehaviour
{
    static string rutaXMLFacil, rutaXMLMedio, rutaXMLDificil;
    public static PlayerStats CurrentGame;
    bool guardado = false;

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
       
    }

    // Update is called once per frame
    void Update()
    {
        if (ControlKniveHit.kniveState == ControlKniveHit.Estate.End && !guardado)
        {
            CrearHighStore();
            SaveState();
            guardado = true;
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

        using (FileStream fstream = new FileStream(rutaXMLFacil, FileMode.Open))
        {
           
            if(fstream != null)
                playersStatsFacil = (List<PlayerStats>)dcSerializer.ReadObject(fstream);
            
        }
        using (FileStream fstream = new FileStream(rutaXMLMedio, FileMode.Open))
        {
            if (fstream != null)
                playersStatsMedio = (List<PlayerStats>)dcSerializer.ReadObject(fstream);

        }
        using (FileStream fstream = new FileStream(rutaXMLDificil, FileMode.Open))
        {
            if (fstream != null)
                playersStatsDificil = (List<PlayerStats>)dcSerializer.ReadObject(fstream);

        }
    }
    public void CrearHighStore()
    {
        switch (CurrentGame.Dificultad)
        {
            case "Facil":
                if (playersStatsFacil[playersStatsFacil.Count - 1].Points < CurrentGame.Points || playersStatsFacil.Count < 10)
                {

                    playersStatsFacil.Add(CurrentGame);
                    playersStatsFacil = playersStatsFacil.OrderByDescending(o => o.Points).ToList();

                    if (playersStatsFacil.Count > 10)
                    {
                        playersStatsFacil.Remove(playersStatsFacil[playersStatsFacil.Count]);
                    }
                }
                break;
            case "Medio":
                if (playersStatsMedio[playersStatsMedio.Count - 1].Points < CurrentGame.Points || playersStatsMedio.Count < 10)
                {

                    playersStatsMedio.Add(CurrentGame);
                    playersStatsMedio = playersStatsMedio.OrderByDescending(o => o.Points).ToList();

                    if (playersStatsMedio.Count > 10)
                    {
                        playersStatsMedio.Remove(playersStatsMedio[playersStatsMedio.Count]);
                    }
                }
                break;

            case "Dificil":
                if (playersStatsDificil[playersStatsDificil.Count - 1].Points < CurrentGame.Points || playersStatsDificil.Count < 10)
                {

                    playersStatsDificil.Add(CurrentGame);
                    playersStatsDificil = playersStatsDificil.OrderByDescending(o => o.Points).ToList();

                    if (playersStatsDificil.Count > 10)
                    {
                        playersStatsDificil.Remove(playersStatsDificil[playersStatsDificil.Count]);
                    }
                }

                break;
        }    
    }
}