using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class TriggerZoneScript : MonoBehaviour
{
    public List<AudioClip> clipCroco = new List<AudioClip>();
    public List<AudioClip> clipSplash = new List<AudioClip>();
    public AudioSource audioSource;

    void Start()
    {
        GetComponent<AudioSource>();
    }

    public void PlaySoundObstacle()
    {
        if (clipCroco.Count > 0) {
            int idx = Random.Range(0, clipCroco.Count);
            audioSource.clip=clipCroco[idx];
            audioSource.Play();
        }
    }
    
    public void PlaySoundSplash()
    {
        if (clipSplash.Count > 0) {
            int idx = Random.Range(0, clipSplash.Count);
            audioSource.clip=clipSplash[idx];
            audioSource.Play();
        }
    }
}
