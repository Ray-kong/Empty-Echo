using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverToScene : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(RemoveLastElevenCharacters(SceneManager.GetActiveScene().name));
        }
    }

    public string RemoveLastElevenCharacters(string inputString)
    {
        if (inputString.Length <= 11)
        {
            return string.Empty; // or you can return the inputString as it is
        }
        else
        {
            return inputString.Substring(0, inputString.Length - 11);
        }
    }
}



// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.SceneManagement;

// public class GameOverToScene : MonoBehaviour
// {
//     public float reloadTime = 0f; // Duration of time in seconds
//     private float timer;

//     private void Update()
//     {
//         // Start the timer
//         if (timer <= 0f)
//         {
//             timer = reloadTime;
//         }

//         // Update the timer
//         timer -= Time.deltaTime;

//         // Check for input after the specified duration
//         // if (timer <= 0f && (Input.anyKeyDown || Input.GetMouseButton(0)))
//         if (Input.anyKeyDown || Input.GetMouseButton(0))
//         {
//             // Reload the scene
//             SceneManager.LoadScene(RemoveLastElevenCharacters(SceneManager.GetActiveScene().name));
//         }
//     }


//     public string RemoveLastElevenCharacters(string inputString)
//     {
//         if (inputString.Length <= 11)
//         {
//             return string.Empty; // or you can return the inputString as it is
//         }
//         else
//         {
//             return inputString.Substring(0, inputString.Length - 11);
//         }
//     }

// }
