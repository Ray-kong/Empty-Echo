using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLog : MonoBehaviour
{
    public AudioClip soundClip;
    private bool hasPlayed = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && !hasPlayed)
        {
            float distance = Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position);
            if (distance <= 2f)
            {
                AudioSource.PlayClipAtPoint(soundClip, transform.position);
                hasPlayed = true;
            }
        }
    }
}
