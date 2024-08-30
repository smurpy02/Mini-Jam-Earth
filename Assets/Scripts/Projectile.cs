using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : DoDamage
{
    public Rigidbody2D body;
    public float speed;

    void Start()
    {
        body.velocity = transform.right * speed;
    }
}
