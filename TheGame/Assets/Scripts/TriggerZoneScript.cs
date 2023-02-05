using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class TriggerZoneScript : MonoBehaviour
{
    public List<AudioClip> clip = new List<AudioClip>();
    public AudioSource audioSource ;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") {
            if (clip.Count > 0) {
                int idx = Random.Range(0, clip.Count - 1);
                audioSource.clip=clip[idx];
                audioSource.Play();
            }
        }
    }
}
