using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorBehaviour : MonoBehaviour
{
    public GameObject Point1;
    public GameObject Point2;
    public float speed = 2f;
    public GameObject nextPoint;

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
}
