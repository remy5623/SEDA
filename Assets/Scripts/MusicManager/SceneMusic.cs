using UnityEngine;

public class SceneMusic : MonoBehaviour
{
    public AudioClip backgroundMusic;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = backgroundMusic;
        audioSource.loop = true;
        audioSource.Play();
    }

    void OnDestroy()
    {
        // Õ£÷π“Ù¿÷≤¢œ˙ªŸ AudioSource
        if (audioSource != null)
        {
            audioSource.Stop();
            Destroy(audioSource);
        }
    }
}