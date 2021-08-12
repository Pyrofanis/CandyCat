using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public class HighScoreSaveSystem
{
    public static void SaveData(HighScoreScriptable highScoreScriptable)
    {
        BinaryFormatter binary = new BinaryFormatter();
        string path = Application.dataPath + "CrazyCatManSaveData.data";
        FileStream stream = new FileStream(path, FileMode.Create);
        HighScoreSaveData scoreSaveData = new HighScoreSaveData(highScoreScriptable);
        binary.Serialize(stream, scoreSaveData);
    }
    public static HighScoreSaveData  LoadData()
    {

        string path = Application.dataPath + "CrazyCatManSaveData.data";
        if (File.Exists(path))
        {
            BinaryFormatter binary = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            HighScoreSaveData scoreSaveData = binary.Deserialize(stream) as HighScoreSaveData;
            stream.Close();
            return scoreSaveData;

        }
        else
        {
            return null;
        }
    }
}
