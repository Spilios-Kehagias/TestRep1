using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckpoint : MonoBehaviour
{
    
    private Animator animator;


    //[SerializeField] private Sprite checkPointTaken;
    //[SerializeField] private AudioSource audioSource;
    //[SerializeField] private AudioClip pickupClip;

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == true)
        {
            collision.GetComponent<PlayerState>().ChangeRespawnPosition(gameObject);
            //GetComponent<SpriteRenderer>().sprite = checkPointTaken;
            //audioSource.PlayOneShot(pickupClip);
            animator.SetTrigger("Touched");
            
        }


    }
}
