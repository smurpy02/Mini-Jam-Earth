using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DestroyTiles : MonoBehaviour
{
    Rigidbody2D body;
    Tilemap tilemap;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        tilemap = FindAnyObjectByType<Tilemap>();
    }

    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    Tilemap tilemap = other.gameObject.GetComponentInChildren<Tilemap>();

    //    if(tilemap == null)
    //    {
    //        return;
    //    }

    //    Vector3 position = transform.position + (Vector3)body.velocity.normalized * 0.5f;
    //    Vector3Int tile = tilemap.WorldToCell(position);
    //    Debug.DrawLine(transform.position, position, Color.red, 100);
    //    Debug.Log("tile " + tile);
    //    tilemap.SetTile(tile, null);
    //}

    void Update()
    {
        Vector3 position = transform.position + (Vector3)body.velocity.normalized * 0.5f;
        Vector3Int tile = tilemap.WorldToCell(position);
        Debug.DrawLine(transform.position, position, Color.red, 100);
        tilemap.SetTile(tile, null);
    }
}
