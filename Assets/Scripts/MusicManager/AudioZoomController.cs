using UnityEngine;
using System.Collections;

public class AudioZoomController : MonoBehaviour
{
    public AudioClip musicClip1;
    public AudioClip musicClip2;
    public Camera orthoCam;
    public float fadeDuration = 1.0f;

    private AudioSource audioSource1;
    private AudioSource audioSource2;

    private float minZoom;
    private float maxZoom;

    void Start()
    {
        // Initialize AudioSources
        audioSource1 = gameObject.AddComponent<AudioSource>();
        audioSource1.clip = musicClip1;
        audioSource1.loop = true;
        audioSource1.Play();

        audioSource2 = gameObject.AddComponent<AudioSource>();
        audioSource2.clip = musicClip2;
        audioSource2.loop = true;
        audioSource2.Play();

        if (orthoCam != null)
        {
            minZoom = orthoCam.GetComponent<CameraPan>().minZoomDistance;
            maxZoom = orthoCam.GetComponent<CameraPan>().maxZoomDistance;
        }
    }

    void Update()
    {
        if (orthoCam != null)
        {
            float zoomLevel = orthoCam.orthographicSize;

            // Calculate the volumes based on zoom level
            float volume1 = Mathf.InverseLerp(maxZoom, minZoom, zoomLevel);
            float volume2 = 1 - volume1;

            StartCoroutine(FadeAudioSource.StartFade(audioSource1, fadeDuration, volume1));
            StartCoroutine(FadeAudioSource.StartFade(audioSource2, fadeDuration, volume2));
        }
    }
}

public static class FadeAudioSource
{
    public static IEnumerator StartFade(AudioSource audioSource, float duration, float targetVolume)
    {
        float currentTime = 0;
        float startVolume = audioSource.volume;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(startVolume, targetVolume, currentTime / duration);
            yield return null;
        }
        yield break;
    }
}
