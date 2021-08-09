using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
[RequireComponent(typeof(ScoreManager))]
public class UiManager : MonoBehaviour
{
    [Header("Scores TXT")]
    [SerializeField]
    private TextMeshProUGUI scoreTXT;

    [Header("Scores String")]
    [SerializeField]
    private string scoresString;
  
    private void LateUpdate()
    {
        scoreTXT.text = scoresString + ScoreManager.score.ToString("0");

    }

}
