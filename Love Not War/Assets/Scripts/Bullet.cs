﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed=200f;
    public float damage=10f;

    private Transform player;
    private Vector3 target;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector3(player.position.x, player.position.y, player.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);//target for fixed position || player.position to follow player
        if (transform.position.x == target.x && transform.position.z == target.z) 
        { DestroyProjectile(); }
    }

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("Player"))
        {
            damage = Mathf.Round(Random.Range(10f, 15f));
            other.gameObject.GetComponent<Health>().TakeDamage(damage);
            DestroyProjectile();

        }
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
