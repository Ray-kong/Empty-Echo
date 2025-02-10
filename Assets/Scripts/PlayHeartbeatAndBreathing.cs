using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayHeartbeatAndBreathing : MonoBehaviour
{
    private Anxiety anxiety;
    private AudioSource audio;
    [SerializeField] private float anxietyLevelThatAudioPlays = 90f;
    // Start is called before the first frame update
    void Start()
    {
        anxiety = GameObject.FindGameObjectWithTag("Player").GetComponent<Anxiety>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (anxiety.GetAnxietyPercent() > anxietyLevelThatAudioPlays)
        {
            audio.Play();
        }
        else
        {
            audio.Stop();
        }
    }
}
