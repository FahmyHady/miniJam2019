using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_Range : MonoBehaviour, Powerups
{
    public float increaseAmount;
    public float expirationTime;
    public string playerTagName;
    bool isInEffect;
    float timer;

    //Interface implementation--------------------//
    public void effect()
    {
        FindObjectOfType<Player>().GetComponentInChildren<Beam>().GetComponent<SphereCollider>().radius += increaseAmount;
    }

    public void expire()
    {
        FindObjectOfType<Player>().GetComponentInChildren<Beam>().gameObject.GetComponent<SphereCollider>().radius -= increaseAmount;
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
        else if (isInEffect && timer >= expirationTime)
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
        }
    }

    private void Start()
    {
        timer = 0.0f;
        isInEffect = false;
    }
}
