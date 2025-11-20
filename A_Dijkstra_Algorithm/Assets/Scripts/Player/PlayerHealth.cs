using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    private int lifes = 3;
    private int  health;

    public bool isDead = true;

    public MobSpawner mSpawner;

    [Header("UI")]
    public Slider healthSlider;
    public PlayerLifesManager lifesManager;
    public GameOverUIManager gameOverUIManager;

    [Header("Animation")]
    public AnimationCurve healthCurve;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
    }

 

    public void hurt(int dmg)
    {
        //Debug.Log("Hurt");
        if (health <= 0) { LifeLost(); return; }
        StartCoroutine(healthBarAnimation(health, health - dmg));
        health -= dmg;

    }


    private void LifeLost()
    {
        lifes--;
        if (lifes == 0) { gameOver();  } else { mSpawner.destroyAllMobs(true); }
            StartCoroutine(healthBarAnimation(health, maxHealth));
        health = maxHealth;
        lifesManager.removeLife();
        
    }

    private void gameOver()
    {
        isDead = true;
        gameOverUIManager.gameOver();
        lifes = 3;
    }
    private IEnumerator healthBarAnimation(int start, int end)
    {
        float startF = (float)start / (float)maxHealth;
        float endF = (float)end / (float)maxHealth;

        float elapsed = 0f, duration = 0.3f, percentage;

        while (elapsed < duration) {
        
            percentage = elapsed / duration;

            healthSlider.value = Mathf.Lerp(startF, endF, healthCurve.Evaluate(percentage));

            elapsed += Time.deltaTime;
            yield return null;
        }

        healthSlider.value = endF;

    }
}
