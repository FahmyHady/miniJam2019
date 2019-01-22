using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    Vector3 initPos;

    void Awake()
    {
        initPos = transform.localPosition;
    }

    public void returnToOrigin()
    {
        this.transform.localPosition = initPos;
    }
}
