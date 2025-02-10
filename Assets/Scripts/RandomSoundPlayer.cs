using UnityEngine;

public class RandomSoundPlayer : MonoBehaviour
{
    public AudioClip[] soundEffects;
    public float minInterval = 2f;
    public float maxInterval = 5f;

    private AudioSource audioSource;
    private float nextPlayTime;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        SetNextPlayTime();
    }

    void Update()
    {
        if (Time.time >= nextPlayTime)
        {
            PlaySoundEffect();
            SetNextPlayTime();
        }
    }

    void PlaySoundEffect()
    {
        if (soundEffects.Length > 0)
        {
            int randomIndex = Random.Range(0, soundEffects.Length);
            AudioClip soundEffect = soundEffects[randomIndex];
            audioSource.PlayOneShot(soundEffect);
        }
    }

    void SetNextPlayTime()
    {
        float interval = Random.Range(minInterval, maxInterval);
        nextPlayTime = Time.time + interval;
    }
}
