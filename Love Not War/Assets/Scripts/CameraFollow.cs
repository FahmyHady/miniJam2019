using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float speed;

    Vector3 offset;
    // Update is called once per frame
    private void Start()
    {
        offset = new Vector3(0, 30, 40);
    }
    void Update()
    {
        transform.position = player.position + offset;
        print(transform.position + "  " + player.position);
    }
}
