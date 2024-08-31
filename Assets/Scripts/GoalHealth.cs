using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GoalHealth : Health
{
    public Transform healthBar;
    public AudioSource damageSound;

    public Movement playerMovement;
    public List<GameObject> deactivate;
    public GameObject deathScreen;

    public Transform cameraTransform;

    public override void Die()
    {
        playerMovement.moveEnabled = false;
        
        foreach(GameObject go in deactivate)
        {
            go.SetActive(false);
        }

        deathScreen.SetActive(true);
    }

    public override void TakeDamage()
    {
        damageSound.Play();
        cameraTransform.DOShakePosition(0.2f);
        Vector3 scale = Vector3.one;
        scale.x = (float)currentHealth / max;
        healthBar.transform.localScale = scale;
    }

    void Update()
    {
        Heal(0.2f * Time.deltaTime);
    }
}
