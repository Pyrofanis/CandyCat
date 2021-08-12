using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingConditions : MonoBehaviour
{
    [SerializeField]
    [Range(0,300)]
    private float maxTimer;

    [Header("Ending Panel")]
    [SerializeField]
    private GameObject objectToEnable;

    private float timer;
    public static float uiTimerIndicator;
    private void Update()
    {
        UpdateIndication();
        TimerChecker();
 
    }
    private void UpdateIndication()
    {
        uiTimerIndicator = Mathf.Abs(maxTimer - timer);
    }
    private void TimerChecker()
    {
        timer += Time.deltaTime;
        if (timer >= maxTimer)
        {
            objectToEnable.SetActive(true);
            timer = maxTimer;
        }
    }
}
