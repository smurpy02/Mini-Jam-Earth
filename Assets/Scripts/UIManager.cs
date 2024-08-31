using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject status;
    public GameObject settings;

    public void Retry()
    {
        BuildStructures.resources = 50;
        BuildStructures.blueprints = 0;
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

    public void Begin()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Menu()
    {
        Debug.Log("menu");
        SceneManager.LoadSceneAsync(0);
    }
}
