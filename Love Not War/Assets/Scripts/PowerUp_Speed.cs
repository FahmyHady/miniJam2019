using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_Speed : MonoBehaviour, Powerups
{
    public float increaseAmount;
    public float expirationTime;
    public string playerTagName;
    bool isInEffect;
    float timer;

    //Interface implementation--------------------//
    public void effect()
    {
        FindObjectOfType<Player>().speed += increaseAmount;
    }

    public void expire()
    {
        FindObjectOfType<Player>().speed -= increaseAmount;
        Destroy(this.gameObject);
    }
    //-------------------------------------------//

    private void Update()
    {
        if (isInEffect && timer < expirationTime)
        {
            timer += Time.deltaTime;
            Debug.Log(timer);
        }
        else if(isInEffect && timer >= expirationTime)
        {
            isInEffect = false;
            timer = 0.0f;
            expire();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == playerTagName)
        {
            this.effect();
            GetComponent<Renderer>().enabled = false;
            isInEffect = true;
            //Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        timer = 0.0f;
        isInEffect = false;
    }
}
