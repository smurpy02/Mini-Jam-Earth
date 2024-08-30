using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RandomScatter : MonoBehaviour
{
    public float scatterMaxDistance;

    void Start()
    {
        transform.DOMove(transform.position + (Vector3)Random.insideUnitCircle * scatterMaxDistance, 0.5f).SetEase(Ease.OutSine);
    }
}
