using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameOverUIManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject startGameUI;
    public MobSpawner spawner;
    public PlayerInput input;
    public PlayerHealth PlayerHealth;

    public void gameOver()
    {
        StartCoroutine(waitToRestart());
    }
    private IEnumerator waitToRestart()
    {
        spawner.stopSpawn = true;
        input.enabled = false;
        spawner.destroyAllMobs(false);
        gameOverUI.SetActive(true);

        yield return new WaitForSeconds(3f);

        gameOverUI.SetActive(false);
        startGameUI.SetActive(true);
        PlayerHealth.isDead = false;
    }
}
