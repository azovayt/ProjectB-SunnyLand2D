using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform posA, posB;
    public int enemySpeed;
    Vector2 targetPos;
    private SpriteRenderer sp;
    
    void Start()
    {
        targetPos = posB.position;
        sp = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, posA.position) < .1f)
        {
            targetPos = posB.position;
            sp.flipX = true;
        }
        else if (Vector2.Distance(transform.position, posB.position) < .1f)
        {
            targetPos = posA.position;
            sp.flipX = false;
        }
        transform.position = Vector2.MoveTowards(transform.position, targetPos, enemySpeed * Time.deltaTime);
    }
}
