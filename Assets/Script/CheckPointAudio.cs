using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointAudio : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip pickupClip;

    private float timer = 0f;
    [SerializeField] private float timeBeforeDeletion = 1f;
    private bool removeGameObject;

    private void Update()
    {
        if (removeGameObject == true)
        {
            timer += Time.deltaTime;
            if (timer >= timeBeforeDeletion)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == true)
        {
            audioSource.PlayOneShot(pickupClip);
            Destroy(gameObject.GetComponent<Collider2D>());
        }
    }
}
