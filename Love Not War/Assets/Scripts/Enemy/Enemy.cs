using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float chaseSpeed;
    public float Speed;
    public Material material;
    Renderer myrender;
    Animation surprised;

    internal bool canShoot;
    internal bool inFiringRange;
    internal GameObject  player;
    Rigidbody mybody;
    bool hitWall;
    void onTransform()
    {

        myrender.material = material;
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
    { Instantiate(new Bullet(),transform); }
    internal void playerDetected()
    {
        mybody.velocity = Vector3.zero;
        if (!inFiringRange)
        {
            followPlayer();
        }
        else if (inFiringRange)
        {
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
        surprised = GetComponent<Animation>();
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
        { mybody.velocity = mybody.transform.forward * Speed;
        }
        if (hitWall)
        {

            patrol();
        }
    }

 
}
