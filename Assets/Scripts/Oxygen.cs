using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Oxygen : MonoBehaviour
{
    [SerializeField] private float oxygenPercent = 100f;
    [SerializeField] private bool writeOxygenPercentToConsole = true;
    [SerializeField] private GameObject[] oxygenBatteryLevels;
    [SerializeField] private bool depleteOxygen;
    [SerializeField] private float oxygenDepletionRate;

    private void Start()
    {
        foreach (GameObject batteryLevel in oxygenBatteryLevels)
        {
            batteryLevel.SetActive(false);
        }
    }

    private void Update()
    {
        OxygenUI();
        if (writeOxygenPercentToConsole)
        {
            Debug.Log("Oxygen Percent : " + oxygenPercent);
        }
        if (depleteOxygen)
        {
            DecreaseOxygen(oxygenDepletionRate);
        }
    }

    public float GetOxygenPercent()
    {
        return oxygenPercent;
    }

    public void setOxygen(float n) {
        oxygenPercent = n;
    }

    public void IncreaseOxygen(float n)
    {
        oxygenPercent = Mathf.Clamp(oxygenPercent + n, 0, 100);
    }

    public void DecreaseOxygen(float n)
    {
        oxygenPercent = Mathf.Clamp(oxygenPercent - n * Time.deltaTime, 0, 100);
    }

    public void ResetOxygen()
    {
        oxygenPercent = 0;
    }
    public void OxygenUI()
    {
        double amountOfBars = Math.Round(oxygenPercent / 12.5);
        if (writeOxygenPercentToConsole)
        {
            Debug.Log("Amount of Oxygen UI Bars" + amountOfBars);
        }

        for (int i = 0; i < oxygenBatteryLevels.Length; i++)
        {
            if (amountOfBars > i)
            {
                oxygenBatteryLevels[i].SetActive(true);
            } else
            {
                oxygenBatteryLevels[i].SetActive(false);
            }
        }
    }

    public void DepleteNowTrue() {
        depleteOxygen = true;
    }
}
