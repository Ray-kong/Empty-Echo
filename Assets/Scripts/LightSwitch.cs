using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public bool toggle;
    public GameObject lightSource, lightSwitch;


    void Start()
    {
        if (lightSource.activeSelf)
        {
            toggle = true;
        }
        else toggle = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player")) { 
            
        }
    }
}
