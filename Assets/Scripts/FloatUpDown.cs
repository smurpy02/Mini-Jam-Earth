using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatUpDown : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Float());
    }

    IEnumerator Float()
    {
        yield return transform.DOMove(Vector3.up * 0.15f, 1.5f).SetEase(Ease.Linear).WaitForCompletion();
        yield return transform.DOMove(-Vector3.up * 0.15f, 1.5f).SetEase(Ease.Linear).WaitForCompletion();

        StartCoroutine(Float());
    }
}
