using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class BossMovement : MonoBehaviour
{
    Transform core;

    public float circlingRadius;
    public float randomRadius;

    public List<Transform> bodies;

    void Start()
    {
        core = GameObject.FindGameObjectWithTag("Core").transform;
        StartCoroutine(DoMoving());

        foreach (Transform body in bodies)
        {
            body.parent = null;
        }
    }

    void Update()
    {
        float offset = 0f;

        foreach (Transform body in bodies)
        {
            if (body != null)
            {
                Vector3 target = transform.position - transform.right * offset;
                body.position = Vector3.Lerp(body.position, target, Time.deltaTime * 2);

                offset += 0.6f;
            }
        }
    }

    IEnumerator DoMoving()
    {
        StartCoroutine(Circle());

        yield return null;
    }

    IEnumerator ChooseRandomMove(int previous)
    {
        int choice = Random.Range(0, 3);

        if (choice == previous || choice == 3)
        {
            StartCoroutine(ChooseRandomMove(choice));
        }
        else
        {
            switch (choice)
            {
                case 0:
                    StartCoroutine(Circle()); break;
                case 1:
                    StartCoroutine(Chase()); break;
                case 2:
                    StartCoroutine(RandomPoints()); break;
            }
        }

        yield return null;
    }

    IEnumerator Circle()
    {
        Vector3 target = core.position + Vector3.up * circlingRadius;
        yield return MoveToPosition(target);

        target = core.position + (Vector3.up * 0.75f + Vector3.right * 0.75f) * circlingRadius;
        yield return MoveToPosition(target);

        target = core.position + Vector3.right * circlingRadius;
        yield return MoveToPosition(target);

        target = core.position + (Vector3.right * 0.75f + Vector3.down * 0.75f) * circlingRadius;
        yield return MoveToPosition(target);

        target = core.position + Vector3.down * circlingRadius;
        yield return MoveToPosition(target);

        target = core.position + (Vector3.down * 0.75f + Vector3.left * 0.75f) * circlingRadius;
        yield return MoveToPosition(target);

        target = core.position + Vector3.left * circlingRadius;
        yield return MoveToPosition(target);

        target = core.position + (Vector3.left * 0.75f + Vector3.up * 0.75f) * circlingRadius;
        yield return MoveToPosition(target);

        StartCoroutine(ChooseRandomMove(0));
    }

    IEnumerator Chase()
    {
        Vector3 target = GameObject.FindGameObjectWithTag("Player").transform.position;
        yield return MoveToPosition(target);

        StartCoroutine(ChooseRandomMove(1));
    }

    IEnumerator RandomPoints()
    {
        for (int i = 0; i < Random.Range(2, 5); i++)
        {
            Vector3 target = Random.insideUnitCircle * randomRadius;
            yield return MoveToPosition(target);
        }

        StartCoroutine(ChooseRandomMove(2));
    }

    IEnumerator MoveToPosition(Vector3 target)
    {
        transform.rotation = Rotations.GetRotation(transform.position, target);
        yield return transform.DOMove(target, Vector3.Distance(transform.position, target) * 0.5f).SetEase(Ease.Linear).WaitForCompletion();
    }
}
