using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIButtonSound : MonoBehaviour, IPointerDownHandler
{
    public AudioClip ClickedSound;

    private Button button { get { return GetComponent<Button>(); } }
    private AudioSource source;

    void Start()
    {
        source = gameObject.AddComponent<AudioSource>();
        source.playOnAwake = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        PlayClickSound();
    }

    void PlayClickSound()
    {
        if (ClickedSound != null)
        {
            source.enabled = true; // »∑±£ AudioSource ∆Ù”√
            source.PlayOneShot(ClickedSound);
        }
    }
}
