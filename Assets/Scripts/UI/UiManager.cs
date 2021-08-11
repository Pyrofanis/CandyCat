using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    private void Start()
    {
        ControllerSupport.inputActions.Controlls.Escape.performed +=_=> RestartScene();
    }
    private void LateUpdate()
    {
        scoreTXT.text = scoresString + ScoreManager.score.ToString("0");

    }
    public void RestartScene()
    {
        //mobileControlls html
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //both
        ScoreManager.score = 0;
        //pc controlls
        //Application.Quit();
    }

}
