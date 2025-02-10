using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class LightFlicker : MonoBehaviour
{
    [Header("Drag All Lights that need to flicker here!")]
    public Light[] lights;

    private void Start()
    {
        StartCoroutine(Flicker());
    }

    private IEnumerator Flicker()
    {

        while (true)
        {

            System.Random random = new System.Random();


            yield return new WaitForSeconds(random.Next(0, 100) * .01f);

            foreach (Light light in lights)
            {
                light.enabled = false;
            }

            yield return new WaitForSeconds(random.Next(0, 100) * .01f);

            foreach (Light light in lights)
            {
                light.enabled = true;
            }

        }


    }

    private void OnDestroy()
    {
        StopCoroutine(Flicker());
    }

}
