using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    public Rigidbody2D playerBody;
    public BuildStructures buildStructures;

    public Transform camPosition;

    public float defaultScale;
    public float movingScale;
    public float buildingScale;

    Vector3 startPosition;

    float size;

    bool changeSize = false;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if(changeSize)
        {
            changeSize = false;
            Camera.main.DOOrthoSize(size, 1);
        }

        if (buildStructures.isBuilding)
        {
            camPosition.position = startPosition;
            if(size != buildingScale) { changeSize = true; size = buildingScale; }
        }
        else
        {
            camPosition.position = playerBody.transform.position - Vector3.forward * 10;

            if (playerBody.velocity == Vector2.zero)
            {
                if (size != defaultScale) { changeSize = true; size = defaultScale; }
            }
            else
            {
                if (size != movingScale) { changeSize = true; size = movingScale; }
            }
        }

    }
}
