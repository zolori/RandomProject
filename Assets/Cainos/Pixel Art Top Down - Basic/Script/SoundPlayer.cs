using UnityEngine;

public class SoundPlayer : MonoBehaviour
{

    private AudioSource audioSource;

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySoundEffect(AudioClip soundEffect)
    {
        audioSource.clip = soundEffect;
        audioSource.Play();
    }

    public void PlayMusic(AudioClip musicClip)
    {
        audioSource.clip = musicClip;
        audioSource.Play();
    }

    public void StopMusic()
    {
        audioSource.Stop();
    }
}
