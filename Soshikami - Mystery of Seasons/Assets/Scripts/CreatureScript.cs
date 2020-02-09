﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureScript : MonoBehaviour
{
    // movement stats
    public float speed;
    private float waitTime;
    public float startWaitTime;

    public Transform[] moveSpots;
    private int randomSpot;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    public bool facingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        randomSpot = Random.Range(0, moveSpots.Length);

        //moveSpots.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpots.Length);
                Vector3 target = moveSpots[randomSpot].position;

                waitTime = startWaitTime;

                // Move right, face right
                if (transform.position.x <= target.x && facingRight != true)
                {   
                    Flip();
                }
                // Move left, face left
                else if (transform.position.x >= target.x && facingRight == true)
                {
                    Flip();
                }
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

}