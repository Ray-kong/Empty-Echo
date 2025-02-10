using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voiceline : MonoBehaviour
{

    private BoxCollider collider;
    private AudioSource audioSource;
    private int acc = 0;


    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<BoxCollider>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && acc < 1)
        {
            Debug.Log("Playing Voiceline");
            audioSource.Play();
            acc++;
        }
    }
}
