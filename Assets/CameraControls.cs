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

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (buildStructures.isBuilding)
        {
            transform.position = startPosition;
            Camera.main.orthographicSize = buildingScale;
        }
        else
        {
            transform.position = playerBody.transform.position - Vector3.forward * 10;

            if (playerBody.velocity == Vector2.zero)
            {
                Camera.main.orthographicSize = defaultScale;
            }
            else
            {
                Camera.main.orthographicSize = movingScale;
            }
        }

    }
}
