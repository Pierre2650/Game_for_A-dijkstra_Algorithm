using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MobHealth : MonoBehaviour
{
    private int maxHealth = 1;
    private int health;
    private Animator myAni;

    [Header("UI")]
    public ScoreManager scoreManager;
    public bool isDead = false;
    public char difficulty;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        switch (difficulty)
        {
            case 'E':
                maxHealth = Random.Range(1, 4);
                break;
            case 'M':
                maxHealth = 1;
                break;
            case 'H':
                maxHealth = Random.Range(3, 6);
                break;
            default:
                maxHealth = 1;
                break;

        }
        health = maxHealth;
        myAni = GetComponent<Animator>();
    }

  

    public void hurt(int dmg)
    {

        health -= dmg;

        if (health <= 0) { dead(); return; }

    }
 
    private  void dead()
    {
        isDead = true;
        GetComponent<CapsuleCollider2D>().enabled = false;

        switch (difficulty)
        {
            case 'E':
                scoreManager.updateScore();
                break;
            case 'M':

                for (int i = 0; i < 3; i++)
                {
                    scoreManager.updateScore();

                }
                break;
            case 'H':

                for (int i = 0; i < 5; i++)
                {
                    scoreManager.updateScore();

                }
                break;
            default:
                scoreManager.updateScore();
                break;

        }

        StartCoroutine(waitToDestroy());
        
    }

    private IEnumerator waitToDestroy()
    {
        myAni.SetTrigger("Sparkle");
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }


}
