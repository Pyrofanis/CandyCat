using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [Header("Score Per Tile")]
    [Tooltip("By how much the score increases per tile if combo is double")]
    [SerializeField]
    [Range(0,5)]
    private float scoreAdjuster;

    [Header("HighScoreData")]
    [SerializeField]
    private HighScoreScriptable highScoreSO;

    public static float score;
    public static HighScoreScriptable staticHighScoreSO;
    private static float staticScoreAdj;


    private void Awake()
    {
        HighScoreSaveData data = HighScoreSaveSystem.LoadData();
        if (data.HighScore>-highScoreSO.highScore)
        highScoreSO.highScore = data.HighScore;
        staticHighScoreSO = highScoreSO;
    }
    // Start is called before the first frame update
    void Start()
    {
        staticScoreAdj = scoreAdjuster;
        
    }

    // Update is called once per frame
    void Update()
    {
        AddHighScore();
    }
    public static void AddScore(bool isItCombo)
    {
        if (!isItCombo)
            score += staticScoreAdj;
        else
            score += staticScoreAdj * 2;
    }
    private void AddHighScore()
    {
        if (score >= staticHighScoreSO.highScore)
        {
            staticHighScoreSO.highScore = score;
        }
    }
    private void OnApplicationQuit()
    {
        HighScoreSaveSystem.SaveData(highScoreSO);
    }
}
