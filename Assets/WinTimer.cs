using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinTimer : MonoBehaviour
{
    public float timeToWin = 360;
    public Transform bar;

    public GameObject explosion;
    public GoalHealth goalHealth;
    public Transform core;

    float timer;

    bool win = false;

    void Start()
    {
        timer = timeToWin;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        Vector3 scale = Vector3.one;
        scale.x = timer / timeToWin;
        bar.localScale = scale;

        if(timer <= 0 && !win)
        {
            win = true;
            StartCoroutine(Win());
        }
    }

    IEnumerator Win()
    {
        goalHealth.enabled = false;
        Instantiate(explosion, core.position, Quaternion.identity) ;

        yield return new WaitForSeconds(6);

        SceneManager.LoadSceneAsync(2);
    }
}
