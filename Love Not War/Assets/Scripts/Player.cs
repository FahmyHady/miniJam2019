using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
  
    public float hp;
    public float speed=5f;
    public float Rotatespeed=100f;
    private Animator anim;
    Vector3 YAxis, XAxis;
    Vector3 heading;


    void Start()
    {
        YAxis = Camera.main.transform.forward;
        YAxis.y = 0;
        YAxis = Vector3.Normalize(YAxis);
        XAxis = Quaternion.Euler(new Vector3(0, 90, 0)) * YAxis;
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
            Move();
    }
    
    void Move()
    {
        ///Movement01
        if (Input.anyKey)
        {
            Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            Vector3 xMovement = XAxis * speed * Time.deltaTime * Input.GetAxis("Horizontal");
            Vector3 YMovement = YAxis * speed * Time.deltaTime * Input.GetAxis("Vertical");

            heading = Vector3.Normalize(xMovement + YMovement);
            transform.forward = heading;
            transform.position += xMovement;
            transform.position += YMovement;
            anim.SetBool("Speed", true);
        }
        else
        {
            anim.SetBool("Speed", false);
        }

        
    }
   
}
