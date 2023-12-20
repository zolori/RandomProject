using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;

    private AudioSource audioSource;

    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

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
