using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupCoin : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip pickupClip;

    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator animator;
    [SerializeField] private ParticleSystem particles;

    private bool canPickupCoin = true;

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
        if(collision.CompareTag("Player") == true)
        {
            if (canPickupCoin == true)
            {
                collision.GetComponent<PlayerState>().CoinPickup();
                audioSource.PlayOneShot(pickupClip);
                spriteRenderer.sprite = null;
                animator.enabled = false;
                particles.Play();
                removeGameObject = true;
                canPickupCoin = false;
            }      
            
        }
    }
}
