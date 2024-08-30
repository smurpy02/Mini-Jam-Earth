using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MagnetizeFragments : MonoBehaviour
{
    public float magnetStrengthDistance;
    public float magnetPickupTime;

    void Update()
    {
        foreach (GameObject fragment in GameObject.FindGameObjectsWithTag("Fragment"))
        {
            float distance = Vector3.Distance(transform.position, fragment.transform.position);

            Debug.Log("frag distance " + distance);

            if (distance < magnetStrengthDistance)
            {
                StartCoroutine(PickupFragment(fragment.transform));
            }
        }
    }

    IEnumerator PickupFragment(Transform fragment)
    {
        Debug.Log("f1 " + fragment);
        yield return fragment.DOMove(transform.position, magnetPickupTime).SetEase(Ease.Linear).WaitForCompletion();
        Debug.Log("f2 " + fragment);

        Destroy(fragment.gameObject);
        BuildStructures.resources++;
    }
}
