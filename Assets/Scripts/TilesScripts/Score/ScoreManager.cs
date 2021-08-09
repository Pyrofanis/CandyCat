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

    public static float score;
    private static float staticScoreAdj;
    // Start is called before the first frame update
    void Start()
    {
        staticScoreAdj = scoreAdjuster;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void AddScore(bool isItCombo)
    {
        if (!isItCombo)
            score += staticScoreAdj;
        else
            score += staticScoreAdj * 2;
    }
}
