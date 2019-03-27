using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using UnityEngine;
using System.Linq;

public class SaveStats : MonoBehaviour
{
    string rutaXML;
    public static PlayerStats CurrentGame;

    public static List<PlayerStats> playersStatsDificil = new List<PlayerStats>();
    public static List<PlayerStats> playersStatsMedio = new List<PlayerStats>();
    public static List<PlayerStats> playersStatsFacil = new List<PlayerStats>();
    // Start is called before the first frame update
    void Start()
    {
        CurrentGame = new PlayerStats();
        rutaXML = Application.persistentDataPath + "/HighScores.xml";
        CurrentGame.PlayerName = ControlKniveHit.playername;
        CurrentGame.Points = ControlKniveHit.points;
        Debug.Log(rutaXML);
    }

    // Update is called once per frame
    void Update()
    {
        if (ControlKniveHit.kniveState == ControlKniveHit.Estate.End)
        {
            SaveState();
        }
    }

    public void SaveState()
    {
        DataContractSerializer dcSerializer = new DataContractSerializer(typeof(PlayerStats));

        using (FileStream fstream = new FileStream(rutaXML, FileMode.Create))
        {
            dcSerializer.WriteObject(fstream, CurrentGame);
        }


    }

    public void LoadState()
    {
        DataContractSerializer dcSerializer = new DataContractSerializer(typeof(PlayerStats));

        using (FileStream fstream = new FileStream(rutaXML, FileMode.Open))
        {
            CurrentGame = (PlayerStats)dcSerializer.ReadObject(fstream);
        }
    }
    public void crearHighStore()
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