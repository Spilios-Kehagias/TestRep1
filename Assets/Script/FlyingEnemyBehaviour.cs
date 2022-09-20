using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyBehaviour : MonoBehaviour
{
    public GameObject Point1;
    public GameObject Point2;
    public float speed = 3f;
    public GameObject nextPoint;
    public int damage = 1;

    void Start()
    {
        {
            nextPoint = Point1;
        }
    }


    void Update()
    {
        {
            MoveToPosition(nextPoint);
        }
    }

    private void MoveToPosition(GameObject moveToTarget)
    {
        gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, moveToTarget.transform.position, speed * Time.deltaTime);

        if (gameObject.transform.position == moveToTarget.transform.position)
        {
            ChangeTarget();
        }
    }

    private void ChangeTarget()
    {
        if (nextPoint == Point1)
        {
            nextPoint = Point2;
        }
        else
        {
            nextPoint = Point1;
        }
    }
    
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") == true)
        {
            collision.gameObject.GetComponent<PlayerState>().DoHarm(damage);
        }
    }
}
