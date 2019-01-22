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

    void Start()
    {
        timer = 0.0f; //init val
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == enemyTagName)
        {
            var enemyWeapon = other.gameObject.GetComponentInChildren<EnemyWeapon>();

            if (Input.GetKeyUp(fireBtn))
            { //
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
                        var pullDirection = this.transform.position - enemyWeapon.gameObject.transform.position;
                        enemyWeapon.gameObject.GetComponent<Rigidbody>().position += pullDirection.normalized * 0.1f;
                    }
                }
                else if (timer >= holdTime)
                {
                    if (enemyWeapon)
                        Destroy(enemyWeapon.gameObject);
                }
            }
        }


    }

    private void OnTriggerExit(Collider other)
    {
        if (Input.GetKeyUp(fireBtn) && other.tag == enemyTagName)
        {
            var enemyWeapon = other.gameObject.GetComponentInChildren<EnemyWeapon>();
            timer = 0;
            if (enemyWeapon)
                enemyWeapon.gameObject.GetComponent<EnemyWeapon>().returnToOrigin();
        }
    }
}
