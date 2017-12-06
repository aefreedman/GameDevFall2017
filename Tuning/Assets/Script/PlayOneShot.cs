using UnityEngine;

public class PlayOneShot : MonoBehaviour
{
    public AudioClip AudioClip;
    public AudioSource AudioSource;

    private void Start()
    {
    }

    private void Update()
    {
    }

    public void PlayAudioClip()
    {
        AudioSource.PlayOneShot(AudioClip);
    }
}