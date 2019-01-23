using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartRotate : MonoBehaviour
{
 

    void Update()
    {
        transform.RotateAround(Vector3.forward, 0.1f);

    }
}
