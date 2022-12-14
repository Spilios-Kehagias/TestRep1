using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKillBox : MonoBehaviour
{
    GameObject gameObjectToKill;

    private void Start()
    {
        gameObjectToKill = gameObject.transform.parent.gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == true)
        {
            if (collision.gameObject.GetComponent<PlayerMovem>().isFalling() == true)
            {
                gameObject.GetComponentInParent<EnemySlimeMovement>().KillMe();
            }
        }
    }
}
