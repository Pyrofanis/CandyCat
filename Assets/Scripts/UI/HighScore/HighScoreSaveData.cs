using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HighScoreSaveData
{
    public float HighScore;
    public HighScoreSaveData(HighScoreScriptable highScoreScriptable)
    {
        highScoreScriptable.highScore = HighScore;
    }
}
