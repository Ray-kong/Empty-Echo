using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelBar : MonoBehaviour
{
    public Slider slider;

    public void setMax(int fuel) {
        slider.maxValue = fuel;
        slider.value = fuel;
    }

    public void setFuel(int fuel) {
        slider.value = fuel;
        Debug.Log("this worked");
    }

}
