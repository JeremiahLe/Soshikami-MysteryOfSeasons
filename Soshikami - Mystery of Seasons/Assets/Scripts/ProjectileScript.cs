﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public float projectileLifespan = 0;
    //public float projectileSpeed;
    // Start is called before the first frame update
    void Start()
    {
        //Vector2.MoveTowards(transform.position, AttackScript.mousePos, projectileSpeed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        projectileLifespan -= Time.deltaTime;

        if (projectileLifespan <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DestroyProjectile"))
        {
            Destroy(gameObject);
        }

       
    }
}
