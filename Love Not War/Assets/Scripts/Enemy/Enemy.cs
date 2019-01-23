using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float chaseSpeed;
    public float Speed;
    public bool Patrol;
    Renderer myrender;
    Animator animator;
   public GameObject bullet;
    public GameObject Hippy;
    AudioSource shooting;
    internal bool canShoot;
    internal bool inFiringRange;
    EnemyWeapon enemyWeapon;

    internal GameObject  player;
    private float timeBtwShots;
    public float startTimeBtwShots;
    Rigidbody mybody;
    bool hitWall;
    internal void onTransform()
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
            shooting.Play();
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
        shooting = GetComponent<AudioSource>();
        enemyWeapon = GetComponentInChildren<EnemyWeapon>();

        animator = GetComponentInChildren<Animator>();
        myrender = gameObject.GetComponent<Renderer>();
        mybody = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (player)
        {
         
                playerDetected();

        }
        else
        {
            if (Patrol==true)
            {
                mybody.velocity = mybody.transform.forward * Speed;
                animator.SetBool("Speed", true);
            }
           
        }
        if (hitWall)
        {

            patrol();
        }
    }

 
}
