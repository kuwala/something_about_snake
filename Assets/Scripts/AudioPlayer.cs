using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioClip FabReality;
    public AudioClip Home7;
    public AudioClip Home10;

    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void PlayFab()
    {
        audioSource.Stop();
        audioSource.clip = FabReality;
        audioSource.Play();
        //FadeIn(audioSource, 1f);
    }

    public void PlayHome7()
    {
        audioSource.Stop();
        audioSource.clip = Home7;
        audioSource.Play();
    }
    public void PlayHome10()
    {
        audioSource.Stop();
        audioSource.clip = Home10;
        audioSource.Play();
    }

    public static IEnumerator FadeOut(AudioSource audioSource, float FadeTime)
    {
        float startVolume = audioSource.volume;
        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;
            yield return null;
        }
        audioSource.Stop();
    }
    public static IEnumerator FadeIn(AudioSource audioSource, float FadeTime)
    {
        audioSource.Play();
        audioSource.volume = 0f;
        while (audioSource.volume < 1)
        {
            audioSource.volume += Time.deltaTime / FadeTime;
            yield return null;
        }
    }
}
