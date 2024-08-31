using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShakeOnSpawn : MonoBehaviour
{
    public float duration;
    public float strength;

    void Start()
    {
        Camera.main.DOShakePosition(duration, strength);
    }
}
