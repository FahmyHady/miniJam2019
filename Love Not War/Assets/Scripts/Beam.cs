using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour
{
    static public float range;
    public int holdTime; //Max key holding time
    float timer;
    public KeyCode fireBtn;
    public string enemyTagName; //Enemy tag
    EnemyWeapon enemyWeapon;
     public Enemy enemy;
    void Start()
    {
        timer = 0.0f; //init val
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == enemyTagName)
        {
             enemyWeapon = other.gameObject.GetComponentInChildren<EnemyWeapon>();

            if (Input.GetKeyUp(fireBtn))
            { 
                timer = 0;
                if (enemyWeapon)
                    enemyWeapon.returnToOrigin();
            }

            if (Input.GetKey(fireBtn))
            {
                if (timer < holdTime)
                {
                    timer += Time.deltaTime;
                    if (enemyWeapon)
                    {
                        enemyWeapon.weaponPulled = true;
                        var pullDirection = this.transform.position - enemyWeapon.gameObject.transform.position;
                        enemyWeapon.gameObject.GetComponent<Rigidbody>().position += pullDirection.normalized * 0.1f;
                    }
                }
                else if (timer >= holdTime)
                {
                    if (enemyWeapon)
                    {
                        enemy = other.gameObject.GetComponentInParent<Enemy>();
                        enemy.onTransform();
                        Destroy(enemyWeapon.gameObject);
                    }
                }
            }
        }
       

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == enemyTagName)
        {
            var enemyWeapon = other.gameObject.GetComponentInChildren<EnemyWeapon>();
            timer = 0;
            if (enemyWeapon)
                enemyWeapon.gameObject.GetComponent<EnemyWeapon>().returnToOrigin();
        }
    }
}
