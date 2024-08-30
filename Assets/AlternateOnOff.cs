using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AlternateOnOff : MonoBehaviour
{
    public GameObject target;
    public float intervals;

    bool active = true;

    void Start()
    {
        StartCoroutine(Switch());
    }

    IEnumerator Switch()
    {
        yield return new WaitForSeconds(intervals);

        active = !active;

        target.SetActive(active);

        StartCoroutine(Switch());
    }
}
