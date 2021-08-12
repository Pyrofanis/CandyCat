using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
[RequireComponent(typeof(ScoreManager))]
public class UiManager : MonoBehaviour
{
    [Header("Scores TXT")]
    [SerializeField]
    private TextMeshProUGUI scoreTXT;

    [Header("Scores TXT")]
    [SerializeField]
    private TextMeshProUGUI highScoreTXT;


    [Header("Scores TXT")]
    [SerializeField]
    private TextMeshProUGUI timerTXT;

    [Header("Scores String")]
    [SerializeField]
    private string scoresString;
    [SerializeField]
    private GameObject tutorialPanel;
    [SerializeField]
    private Button tutorialButton;
    private bool enableTutorial;
    private void Start()
    {
        ControllerSupport.inputActions.Controlls.ResetButtons.performed +=_=> RestartScene();
        ControllerSupport.inputActions.Controlls.ExitButton.performed +=_=> QuitGame();
        ControllerSupport.inputActions.Controlls.HelpButton.performed +=_=> EnableTutorial();
        enableTutorial = false;
    }
    private void LateUpdate()
    {
        scoreTXT.text = scoresString + ScoreManager.score.ToString("0");

        highScoreTXT.text = ScoreManager.staticHighScoreSO.highScore.ToString("0");
        timerTXT.text = EndingConditions.uiTimerIndicator.ToString("0.0");
    }
    private void EnableTutorial()
    {
        enableTutorial = !enableTutorial;
        tutorialPanel.SetActive(enableTutorial);
        tutorialButton.Select();
    }
    public void RestartScene()
    {
        //mobileControlls html
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //both
        ScoreManager.score = 0;

    }
    public void QuitGame()
    {
        //pc controlls
        Application.Quit();
    }

}
