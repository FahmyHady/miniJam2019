﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float chaseSpeed;
    public float Speed;
    public Material material;
    Renderer myrender;
    Animator animator;
   public GameObject bullet;
    public GameObject Hippy;

    internal bool canShoot;
    internal bool inFiringRange;
    EnemyWeapon enemyWeapon;

    internal GameObject  player;
    private float timeBtwShots;
    public float startTimeBtwShots;
    Rigidbody mybody;
    bool hitWall;
    void onTransform()
    {

        Instantiate(Hippy, transform.position,transform.rotation);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag != "Ground")
        {
            hitWall = true;

        }
    }
    void followPlayer()
    {
     
            gameObject.transform.LookAt(player.transform);
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, chaseSpeed);
        
      


    }
    void Shoot()
    {

        if (timeBtwShots <= 0)
        {

            Instantiate(bullet, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;

        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

    internal void playerDetected()
    {
        mybody.velocity = Vector3.zero;
        if (!inFiringRange)
        {
            animator.SetBool("Speed", true);

            followPlayer();
        }
        else if (inFiringRange && !enemyWeapon.weaponPulled)
        {
            animator.SetBool("Speed", false);

            Shoot();
        }

    }
    void patrol()
    {
        transform.Rotate(0, 90,0);
        hitWall = false;
    }

    void Start()
    {
        enemyWeapon = GetComponentInChildren<EnemyWeapon>();

        animator = GetComponent<Animator>();
        myrender = gameObject.GetComponent<Renderer>();
        Speed = 10;
        chaseSpeed = 0.1f;
        mybody = gameObject.GetComponent<Rigidbody>();
       mybody.velocity = mybody.transform.forward*Speed;
    }

    void Update()
    {
        if (player)
        {
         
                playerDetected();

        }
        else
        {
            mybody.velocity = mybody.transform.forward * Speed;
            animator.SetBool("Speed", true);
        }
        if (hitWall)
        {

            patrol();
        }
    }

 
}
