using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateAstroDrag : MonoBehaviour
{
    public List<GameObject> objectsList;
    public AudioClip soundClip; // Sound clip to play

    private AudioSource audioSource;

    private bool used = false;

    private void Awake()
    {
        // Get the AudioSource component from the same GameObject or add one if it's not present
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!used) {
                ActivateObjects();
                // Destroy(gameObject);
                used = true;
                PlaySound();
            }
        }
    }

    // private void OnTriggerExit(Collider other)
    // {
    //     if (other.CompareTag("Player"))
    //     {
    //         if (!used) {
    //             ActivateObjects();
    //             // Destroy(gameObject);
    //             used = true;
    //         }
    //     }
    // }

    public void ActivateObjects()
    {
        foreach (GameObject obj in objectsList)
        {
            LerpAndDelete lerpScript = obj.GetComponent<LerpAndDelete>();
            if (lerpScript != null)
            {
                lerpScript.lerpToTarget = true;
            }
        }
    }

    public void PlaySound()
    {
        if (soundClip != null)
        {
            audioSource.PlayOneShot(soundClip);
        }
    }
}


// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class activateAstroDrag : MonoBehaviour
// {
//     public List<GameObject> objectsList;

//     private void OnTriggerEnter(Collider other)
//     {
//         if (other.CompareTag("Player"))
//         {
//             ActivateObjects();
//         }
//     }

//     private void OnTriggerExit(Collider other)
//     {
//         if (other.CompareTag("Player"))
//         {
//             ActivateObjects();
//             Destroy(gameObject);
//         }
//     }

//     public void ActivateObjects()
//     {
//         foreach (GameObject obj in objectsList)
//         {
//             LerpAndDelete lerpScript = obj.GetComponent<LerpAndDelete>();
//             if (lerpScript != null)
//             {
//                 lerpScript.lerpToTarget = true;
//             }
//         }
//     }
// }
