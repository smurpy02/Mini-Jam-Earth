using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public EnemySpawnManager spawnManager;
    public WinTimer timer;
    public Rotate earthRotate;

    public List<GameObject> tutorialPanels;

    void Start()
    {
        spawnManager.enabled = false;
        timer.enabled = false;
        earthRotate.enabled = false;
    }

    public void EndTutorial()
    {
        foreach(GameObject panel in tutorialPanels)
        {
            panel.SetActive(false);
        }

        spawnManager.enabled = true;
        timer.enabled = true;
        earthRotate.enabled = true;
    }
}
