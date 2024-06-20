using UnityEngine;

public class SceneMusic : MonoBehaviour
{
    public AudioClip backgroundMusic;

    void Start()
    {
        if (MusicManager.instance != null && backgroundMusic != null)
        {
            MusicManager.instance.PlayMusic(backgroundMusic);
        }
    }
}
