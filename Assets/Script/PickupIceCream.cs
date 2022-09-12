using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupIceCream : MonoBehaviour
{
    [SerializeField] private int amountToCollect = 1;
    [SerializeField] private GameObject portalToOpenWhenQuestIsComplete;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private float timer = 0f;
    [SerializeField] private float timeBeforeDeletion = 1f;
    private bool removeGameObject;

    [SerializeField] ParticleSystem particles;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip pickupClip;

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
            collision.GetComponent<PlayerState>().IceCreamPickup();
            spriteRenderer.sprite = null;
            particles.Play();
            audioSource.PlayOneShot(pickupClip);
            removeGameObject = true;

            if (collision.GetComponent<PlayerState>().iceaCreamAmount >= amountToCollect)
            {
                collision.GetComponent<PlayerQuest>().isQuestComplete = true;
                portalToOpenWhenQuestIsComplete.SetActive(false);
            }
        }
    }
}
