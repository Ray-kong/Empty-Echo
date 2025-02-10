using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialHelper1 : MonoBehaviour
{
    public bool isIntro = false;
    // variables for checking button usage
    public bool checkingForMouse;
    private bool hasLookedAround = false;
    public KeyCode[] desiredKeys = { KeyCode.A, KeyCode.D };
    private bool hasPressedButtons = false;

    //Audio logging variables
    public AudioClip soundClip; // Sound clip to play
    private AudioSource audioSource; // Reference to the AudioSource component
    private bool isSoundFinished; // Boolean to track if the sound has finished playing

    // this is is the UI prompt that tells the player what to do
    public GameObject UIprompt;

    // next tutorial phase / stage
    public GameObject NextStage;

    //key we're testing the player on
    public string keyphase;

    public bool willDepleteOxygen = false;



    private GameObject player;
    private TutorialPlayerScript tutorialPlayerScript;
    private Oxygen oxygen;


    private void Start()
    {
        //player button enabler
        player = GameObject.FindGameObjectWithTag("Player");
        tutorialPlayerScript = player.GetComponent<TutorialPlayerScript>();
        oxygen = player.GetComponent<Oxygen>();


        // This sets up the audio variable components
        audioSource = GetComponent<AudioSource>();
        isSoundFinished = false;
        PlaySound();

        // Check the duration of the sound clip in seconds
        float soundDuration = soundClip.length;
        Debug.Log("Sound duration: " + soundDuration + " seconds");

        if (willDepleteOxygen) {
            oxygen.DepleteNowTrue();
        }

    }

    private void Update() {

        if (checkingForMouse && isSoundFinished) {
            mouseChecker();
        } else if (isSoundFinished) {
            buttonChecker();
        }

        GuiEnabler();

        if ((hasLookedAround || hasPressedButtons) && isSoundFinished) {
            Invoke("TutorialStageDone", 1);
        }

        if (isIntro) {
            hasLookedAround = true;
            hasPressedButtons = true;
        }


    }


    private void mouseChecker() {
        // Check if the player has used the mouse to look around
        if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
        {
            hasLookedAround = true;
            Debug.Log("Player has looked around.");
        }
    }

    private void buttonChecker() {
        foreach (KeyCode key in desiredKeys)
        {
            if (Input.GetKeyDown(key))
            {
                Debug.Log("The desired key " + key.ToString() + " has been pressed!");
                hasPressedButtons = true;
            }
        }
    }

    private void PlaySound()
    {
        audioSource.clip = soundClip;
        audioSource.Play();
        float soundDuration = soundClip.length; // Get the duration of the sound clip
        Invoke("SetSoundFinished", soundDuration); // Schedule the function call after the sound duration
    }

    private void SetSoundFinished()
    {
        isSoundFinished = true;

    }

    private void GuiEnabler() {
        if (isSoundFinished) {
            // UIprompt.SetActive(true);
            tutorialPlayerScript.OutsideSourceEnabler(keyphase);
            Invoke("GuiEnablerHelper", 1);  // simply used to get a delay going
        }
    }

    private void GuiEnablerHelper(){
        if (!(hasLookedAround || hasPressedButtons)) {
            UIprompt.SetActive(true);

        } else {
            UIprompt.SetActive(false);
        }
    }

    private void TutorialStageDone() {
        NextStage.SetActive(true);
    }

}
