using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomFloat : MonoBehaviour
{
    public Rigidbody2D body;
    public float speed;

    void Start()
    {
        body.velocity = Random.insideUnitCircle.normalized * speed;
    }
}
