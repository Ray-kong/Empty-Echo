using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundSceneController : MonoBehaviour
{
    public AudioClip soundClip; // The sound clip to play
    public string nextSceneName; // The name of the scene to load next

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(PlaySoundAndWait());
    }

    IEnumerator PlaySoundAndWait()
    {
        // Play the sound
        audioSource.clip = soundClip;
        audioSource.Play();

        // Wait until the sound finishes playing
        yield return new WaitForSeconds(soundClip.length);

        // Load the next scene
        SceneManager.LoadScene(nextSceneName);
    }
}
