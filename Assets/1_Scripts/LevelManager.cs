using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;


public class LevelManager : MonoBehaviour
{
    public float timeRemaining;
    public bool timerOn = false;
    public Text timerText;
    public Text cubeCounterText;
    public int cubeCounter;

    private void Start() 
    {
        cubeCounter = 0;
        timerOn = true;
    }

    private void Update() 
    {
       CalculateRemainingTime();
       AdjustCubeCounterToText(); 
    }

    public void CalculateRemainingTime()
    {
        if (timerOn)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimer(timeRemaining);
            }
            else
            {
                Debug.Log("You are out of time!");
                timeRemaining = 0;
                timerOn = false;
            }
        }
    }

    public void UpdateTimer(float currentTime)
    {
        currentTime += 1;
        float minutes = Mathf.FloorToInt(currentTime/60);
        float seconds = Mathf.FloorToInt(currentTime%60);

        timerText.text = string.Format("{0:00} : {1:00}",minutes,seconds);
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Cube"))
        {
            cubeCounter++;
        }
    }

    public void AdjustCubeCounterToText()
    {
        cubeCounterText.text = cubeCounter.ToString();
    }
}
