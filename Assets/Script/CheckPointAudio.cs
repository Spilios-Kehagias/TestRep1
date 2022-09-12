using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointAudio : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip pickupClip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == true)
        {
            audioSource.PlayOneShot(pickupClip);
        }
    }
}
