using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootRange : MonoBehaviour
{
    Enemy me;
    private void Start()
    {
        me = GetComponentInParent<Enemy>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {

            me.inFiringRange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
      me.inFiringRange = false;
    }
}
