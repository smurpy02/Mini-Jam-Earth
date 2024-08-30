using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ValidPlacementCheck : MonoBehaviour
{
    int colliders;
    public bool isValid { get { return colliders <= 0; } }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Obstacle")) colliders++;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("Obstacle")) colliders--;
    }
}
