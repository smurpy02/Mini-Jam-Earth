using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulse : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(RepeatPulse());
    }

    IEnumerator RepeatPulse()
    {
        yield return transform.DOScale(Vector3.one * 1.1f, 2).SetEase(Ease.InQuad).WaitForCompletion();

        yield return transform.DOScale(Vector3.one, 2).SetEase(Ease.InQuad).WaitForCompletion();

        StartCoroutine(RepeatPulse());
    }
}
