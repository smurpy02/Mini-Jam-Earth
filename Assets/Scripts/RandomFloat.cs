using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomFloat : MonoBehaviour
{
    public Rigidbody2D body;
    public float speed;

    Vector3 dir;

    void Start()
    {
        dir = transform.right;
        //body.velocity = Random.insideUnitCircle.normalized * speed;
    }

    void Update()
    {
        body.velocity = dir * speed;
    }
}
