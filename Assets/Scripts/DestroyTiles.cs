using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DestroyTiles : MonoBehaviour
{
    Rigidbody2D body;
    Tilemap tilemap;

    public AudioSource digSound;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        tilemap = FindAnyObjectByType<Tilemap>();
    }

    void Update()
    {
        Vector3 position = transform.position + (Vector3)body.velocity.normalized * 0.5f;
        Vector3Int tile = tilemap.WorldToCell(position);
        Debug.DrawLine(transform.position, position, Color.red, 100);

        if(tilemap.GetTile(tile) != null)
        {
            digSound.Play();
        }

        tilemap.SetTile(tile, null);
    }
}
