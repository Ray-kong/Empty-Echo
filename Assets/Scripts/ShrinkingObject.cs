using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShrinkingObject : MonoBehaviour
{
    public float shrinkRate = 0.1f; // Rate at which objects shrink per frame
    public float fovIncreaseRate = 1f; // Rate at which FOV increases per frame
    public List<GameObject> objectsToShrink = new List<GameObject>(); // Objects to be shrunk
    public bool willActivateNextScene;
    public string sceneName; // Name of the scene to start


    public AudioClip soundClip; // The sound clip to play
    private AudioSource audioSource;


    private bool isShrinking = false;
    private Camera mainCamera;

    private void Awake()
    {
        // Get the main camera reference
        mainCamera = Camera.main;

        // Get the AudioSource component attached to the same GameObject
        audioSource = GetComponent<AudioSource>();

        // Set the AudioClip to play
        audioSource.clip = soundClip;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player collided with the trigger collider
        if (other.CompareTag("Player"))
        {
            // Call the method to start shrinking the objects
            StartShrinking();
            PlaySound();
            Invoke("StartScene", 3);
        }
    }

    private void StartShrinking()
    {
        // Check if already shrinking or no objects to shrink
        if (isShrinking || objectsToShrink.Count == 0)
            return;

        isShrinking = true;
        StartCoroutine(ShrinkObjects());
    }

    private IEnumerator ShrinkObjects()
    {
        while (objectsToShrink.Count > 0)
        {
            // Shrink each object in the list
            for (int i = 0; i < objectsToShrink.Count; i++)
            {
                GameObject obj = objectsToShrink[i];
                Vector3 newScale = obj.transform.localScale;

                // Shrink the object on its local z and y axes only
                newScale.z -= shrinkRate;
                newScale.y -= shrinkRate;

                // Apply the new scale to the object
                obj.transform.localScale = newScale;

                // Remove the object from the list if it has reached the minimum scale
                if (newScale.z <= 0f || newScale.y <= 0f)
                {
                    objectsToShrink.RemoveAt(i);
                    i--;
                }
            }

            // Increase the field of view of the main camera
            mainCamera.fieldOfView += fovIncreaseRate;

            yield return null; // Wait for the next frame
        }

        isShrinking = false;
    }

    public void StartScene()
    {
        if (willActivateNextScene) {
            SceneManager.LoadScene(sceneName);
        }
    }

    public void PlaySound()
    {
        // Play the sound clip
        audioSource.Play();
    }
}


// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class ShrinkingObject : MonoBehaviour
// {
//     public float shrinkRate = 0.1f; // Rate at which objects shrink per frame
//     public List<GameObject> objectsToShrink = new List<GameObject>(); // Objects to be shrunk

//     private bool isShrinking = false;

//     private void OnTriggerEnter(Collider other)
//     {
//         // Check if the player collided with the trigger collider
//         if (other.CompareTag("Player"))
//         {
//             // Call the method to start shrinking the objects
//             StartShrinking();
//         }
//     }

//     private void StartShrinking()
//     {
//         // Check if already shrinking or no objects to shrink
//         if (isShrinking || objectsToShrink.Count == 0)
//             return;

//         isShrinking = true;
//         StartCoroutine(ShrinkObjects());
//     }

//     private IEnumerator ShrinkObjects()
//     {
//         while (objectsToShrink.Count > 0)
//         {
//             // Shrink each object in the list
//             for (int i = 0; i < objectsToShrink.Count; i++)
//             {
//                 GameObject obj = objectsToShrink[i];
//                 Vector3 newScale = obj.transform.localScale;

//                 // Shrink the object on its local z and y axes only
//                 newScale.z -= shrinkRate;
//                 newScale.y -= shrinkRate;

//                 // Apply the new scale to the object
//                 obj.transform.localScale = newScale;

//                 // Remove the object from the list if it has reached the minimum scale
//                 if (newScale.z <= 0f || newScale.y <= 0f)
//                 {
//                     objectsToShrink.RemoveAt(i);
//                     i--;
//                 }
//             }

//             yield return null; // Wait for the next frame
//         }

//         isShrinking = false;
//     }
// }
