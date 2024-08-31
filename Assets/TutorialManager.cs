using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public EnemySpawnManager spawnManager;
    public WinTimer timer;
    public Rotate earthRotate;

    public GameObject tutorial;

    void Start()
    {
        spawnManager.enabled = false;
        timer.enabled = false;
        earthRotate.enabled = false;
    }

    public void EndTutorial()
    {
        tutorial.SetActive(false);
        spawnManager.enabled = true;
        timer.enabled = true;
        earthRotate.enabled = true;
    }
}
