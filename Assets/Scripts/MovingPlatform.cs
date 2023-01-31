using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public List<Transform> points;
    int goalPoint = 0;
    public float moveSpeed = 1;

    private void Update(){
        MoveToNextPoint();
    }

    void MoveToNextPoint(){
        transform.position = Vector2.MoveTowards(transform.position, points[goalPoint].position, Time.deltaTime * moveSpeed);
        if (Vector2.Distance(transform.position, points[goalPoint].position) < 0.1f)
        {
            if (goalPoint == points.Count -1)
            {
                goalPoint = 0;
            }
            else
            {
                goalPoint++;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.SetParent(this.transform);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.SetParent(null);
        }
    }
}
