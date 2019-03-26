using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using UnityEngine;

public class SaveStats : MonoBehaviour
{
    string rutaXML;
    public static PlayerStats CurrentGame;
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
        if(ControlKniveHit.kniveState == ControlKniveHit.Estate.End)
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
}
