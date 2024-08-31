using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public InputActionReference forward;
    public float speed;
    public Rigidbody2D body;
    public AudioSource moveSound;

    public bool moveEnabled;

    void Update()
    {
        transform.rotation = Rotations.GetRotation(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));

        if (forward.action.IsPressed() && moveEnabled)
        {
            body.velocity = transform.right * speed;
        }
        else
        {
            body.velocity = Vector3.zero;
        }

        moveSound.volume = (body.velocity.magnitude / speed) + 0.2f;
    }
}
