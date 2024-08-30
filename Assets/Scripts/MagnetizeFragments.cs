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

            if (distance < magnetStrengthDistance)
            {
                StartCoroutine(PickupItem(fragment.transform, false));
            }
        }

        foreach (GameObject blueprint in GameObject.FindGameObjectsWithTag("Blueprint"))
        {
            float distance = Vector3.Distance(transform.position, blueprint.transform.position);

            if (distance < magnetStrengthDistance)
            {
                StartCoroutine(PickupItem(blueprint.transform, true));
            }
        }
    }

    IEnumerator PickupItem(Transform item, bool blueprint)
    {
        yield return item.DOMove(transform.position, magnetPickupTime).SetEase(Ease.Linear).WaitForCompletion();

        if (item != null)
        {
            Destroy(item.gameObject);

            if (blueprint)
            {
                BuildStructures.blueprints++;
            }
            else
            {
                BuildStructures.resources++;
            }
        }
    }
}
