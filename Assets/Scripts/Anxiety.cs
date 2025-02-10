using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Anxiety : MonoBehaviour
{
    [SerializeField] float anxietyPercent = 0f;
    [SerializeField] private bool writeAnxietyPercentToConsole = true;

    [SerializeField] private Text anxietyUIPercent;

    private void Update()
    {
        anxietyUIPercent.text = Math.Round(anxietyPercent, 0).ToString() + "%";
        if (writeAnxietyPercentToConsole)
        {
        Debug.Log("Anxiety Percent : " + anxietyPercent);
        }
    }

    public float GetAnxietyPercent()
    {
        return anxietyPercent;
    }

    public void IncreaseAnxiety(float n)
    {
        anxietyPercent = Mathf.Clamp(anxietyPercent + n * Time.deltaTime, 0, 100);
    }

    public void DecreaseAnxiety(float n)
    {
        anxietyPercent = Mathf.Clamp(anxietyPercent - n * Time.deltaTime, 0, 100);
    }

    public void ResetAnxiety()
    {
        anxietyPercent = 0;
    }

}
