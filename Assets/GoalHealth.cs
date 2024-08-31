using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GoalHealth : Health
{
    public Transform healthBar;
    public AudioSource damageSound;

    public override void Die()
    {
        Debug.Log("THE END");
    }

    public override void TakeDamage()
    {
        damageSound.Play();
        Camera.main.transform.DOShakePosition(0.2f);
        Vector3 scale = Vector3.one;
        scale.x = (float)currentHealth / max;
        healthBar.transform.localScale = scale;
    }

    void Update()
    {
        Heal(0.2f * Time.deltaTime);
    }
}
