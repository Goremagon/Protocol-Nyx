using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioSource sfxSource;
    public AudioClip shootClip;
    public AudioClip explosionClip;

    void Awake()
    {
        if (Instance == null) { Instance = this; DontDestroyOnLoad(gameObject); }
        else { Destroy(gameObject); }

        if (sfxSource == null)
        {
            sfxSource = GetComponent<AudioSource>();
        }
    }

    public void PlayShoot() { if (sfxSource != null && shootClip != null) sfxSource.PlayOneShot(shootClip); }
    public void PlayExplosion() { if (sfxSource != null && explosionClip != null) sfxSource.PlayOneShot(explosionClip); }
}
