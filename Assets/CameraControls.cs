using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    public Rigidbody2D playerBody;
    public BuildStructures buildStructures;

    public float defaultScale;
    public float movingScale;
    public float buildingScale;

    Vector3 startPosition;

    float size;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if(size != Camera.main.orthographicSize)
        {
            Camera.main.DOOrthoSize(size, 1);
        }

        if (buildStructures.isBuilding)
        {
            transform.position = startPosition;
            size = buildingScale;
        }
        else
        {
            transform.position = playerBody.transform.position - Vector3.forward * 10;

            if (playerBody.velocity == Vector2.zero)
            {
                size = defaultScale;
            }
            else
            {
                size = movingScale;
            }
        }

    }
}
