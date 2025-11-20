using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class StartUIManager : MonoBehaviour
{
    public GameObject UI;
    public PlayerInput input;
    public MobSpawner spawner;
    public PlayerLifesManager lifesManager;
    public ScoreManager scoreManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void startGame()
    {
        lifesManager.resetLifes();
        scoreManager.resetScore();
        input.enabled = true;
        spawner.stopSpawn = false;
        UI.SetActive(false);
    }
}
